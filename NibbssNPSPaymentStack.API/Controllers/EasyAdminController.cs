
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NibbssNPSPaymentStack.API.Models.Model;
using NibbssNPSPaymentStack.Business.Contract;
using NibbssNPSPaymentStack.Business.Models;
using NibssNPSPaymentStack.Data;
using NibssNPSPaymentStack.Data.Models.Model;
using NibssNPSPaymentStack.Data.Models.ModelView;
using System;

namespace EasyPay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize] // Add authorization if needed
    public class EasyAdminController : ControllerBase // Changed from Controller to ControllerBase
    {
        private readonly INibssNPSPayments _npsPayment;
        private readonly NPSDBContext _npsdbcontext;
        private readonly ILogger<EasyAdminController> _logger;
        private readonly NpsSettings _settings;
        private readonly UserManager<IdentityUser> _userManager;

        public EasyAdminController(
            INibssNPSPayments npsPayment,
            ILogger<EasyAdminController> logger,
            IOptions<NpsSettings> options,
            NPSDBContext npsdbcontext,
            UserManager<IdentityUser> userManager)
        {
            _npsPayment = npsPayment;
            _logger = logger;
            _npsdbcontext = npsdbcontext;
            _settings = options.Value;
            _userManager = userManager;
        }

        [HttpGet("AllEndpoints")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<object>>> GetAllEndpoints(
      CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching all available endpoints from NPS database.");

                var result = await _npsdbcontext.AvailableEndpoints
                    .Select(r => new
                    {
                        RouteTemplate = r.RouteTemplate,
                        Description = r.Description
                    })
                    .ToListAsync(cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve available endpoints.");
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //                  "An error occurred while retrieving endpoints.");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }




        [HttpGet("EnabledEndpoints")] // Changed from HttpPost to HttpGet
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetEnabledEndpoints()
        {
            var result = await _npsdbcontext.AvailableEndpoints
                .Where(r => r.IsEnabled == true)
                .Select(r => new
                {
                    RouteTemplate = r.RouteTemplate,
                    Description = r.Description
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("GetRegisteredUsers")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<object>>> GetRegisteredUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            if (users == null || !users.Any())
                return NotFound("No registered users found");

            return Ok(users);
        }

        [HttpGet("GetRegisteredUsersByUsername")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<object>>> GetRegisteredByUsername1([FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("Username cannot be empty.");

            var users = await _userManager.Users
                .Where(a => a.UserName == username)
                .ToListAsync();

            if (users == null || !users.Any())
                return NotFound($"User '{username}' not found");

            return Ok(users);
        }




        [HttpPost("ProfileUser")]
        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]

        public async Task<ActionResult<UsersSetup>> CreateUser([FromBody] UsersSetup1 createDto)
        {
            // 1. Validate input
            if (string.IsNullOrWhiteSpace(createDto.Email))
                return BadRequest("Email cannot be empty.");


            var realClientIp = HttpContext.Connection.RemoteIpAddress?.ToString();

            _logger.LogInformation("IP of Requesting Server is {realclientip}", realClientIp);


            // 2. Check if user exists in AspNetUsers
            var user = await _userManager.Users
                .FirstOrDefaultAsync(a => a.Email == createDto.Email);

            if (user == null)
                return BadRequest($"Email '{createDto.Email}' is not Register.");

            // 3. Check if username already exists in UsersSetup
            var existingUserByUsername = await _npsdbcontext.UsersSetup
                .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUserByUsername != null)
                return BadRequest($"Username '{createDto.Email}' already exists in UsersSetup.");

            // 4. Check if email already exists in UsersSetup
            if (!string.IsNullOrWhiteSpace(createDto.Email))
            {
                var existingUserByEmail = await _npsdbcontext.UsersSetup
                    .FirstOrDefaultAsync(u => u.Email == createDto.Email);

                if (existingUserByEmail != null)
                    return BadRequest($"Email '{createDto.Email}' already exists in UsersSetup.");
            }

            // 5. Create new UsersSetup record
            var newUser = new UsersSetup
            {
                Username = user.UserName,
                Email = user.Email,
                ApiKey = GenerateApiKey(),
                IsActive = false,
                RateLimitRequestsPerMinute = createDto.RateLimitRequestsPerMinute,
                RateLimitBurst = createDto.RateLimitBurst,
                AllowedEndpoints = createDto.AllowedEndpoints,
                CreatedAt = DateTime.UtcNow,
                Description = createDto.Description,
                ContactPhonenumber = createDto.ContactPhonenumber,
                BusinessName = createDto.BusinessName,
                FirstName = createDto.FirstName,
                LastName = createDto.LastName
            };

            await _npsdbcontext.UsersSetup.AddAsync(newUser);
            await _npsdbcontext.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetUser), new { UserName = newUser.Username }, newUser);
            return Ok(newUser);
        }

      
        [HttpGet("GetProfiledUsernames")]
        [ProducesResponseType(typeof(IEnumerable<UsersSetup>), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsersSetup>>> GetAllUsers()
        {
            var users = await _npsdbcontext.UsersSetup.ToListAsync();
            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")] // Fixed route to include id
        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<UsersSetup>> GetUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("User ID cannot be empty");

            var user = await _npsdbcontext.UsersSetup.FindAsync(id);

            if (user == null)
                return NotFound($"User with ID {id} not found");

            return Ok(user);
        }

        [HttpGet("GetUserByUsername/{username}")]
        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<UsersSetup>> GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("Username cannot be empty");

            var user = await _npsdbcontext.UsersSetup
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return NotFound($"User with username {username} not found");

            return Ok(user);
        }

        [HttpGet("GetUserByEmail/{email}")]
        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<UsersSetup>> GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email cannot be empty");

            var user = await _npsdbcontext.UsersSetup
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return NotFound($"User with email {email} not found");

            return Ok(user);
        }
        [Authorize]
        [HttpGet("GetActiveUsers")]
        [ProducesResponseType(typeof(IEnumerable<UsersSetup>), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsersSetup>>> GetActiveUsers()
        {
            var users = await _npsdbcontext.UsersSetup
                .Where(u => u.IsActive == true)
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("GetInactiveUsers")]
        [ProducesResponseType(typeof(IEnumerable<UsersSetup>), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsersSetup>>> GetInactiveUsers()
        {
            var users = await _npsdbcontext.UsersSetup
                .Where(u => u.IsActive == false)
                .ToListAsync();

            return Ok(users);
        }

        //[HttpPut("UpdateUser/{id}")] // Fixed route
        //[ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<UsersSetup>> UpdateUser(string id, [FromBody] UsersSetup updateDto)
        //{
        //    if (string.IsNullOrWhiteSpace(id))
        //        return BadRequest("User ID cannot be empty");

        //    var user = await _npsdbcontext.UsersSetup.FindAsync(id);

        //    if (user == null)
        //        return NotFound($"User with ID {id} not found");

        //    // Update fields if provided
        //    if (!string.IsNullOrEmpty(updateDto.Username) && updateDto.Username != user.Username)
        //    {
        //        var existingUser = await _npsdbcontext.UsersSetup
        //            .FirstOrDefaultAsync(u => u.Username == updateDto.Username);

        //        if (existingUser != null)
        //            return BadRequest($"Username '{updateDto.Username}' already exists");

        //        user.Username = updateDto.Username;
        //    }

        //    if (!string.IsNullOrEmpty(updateDto.Email) && updateDto.Email != user.Email)
        //    {
        //        var existingUser = await _npsdbcontext.UsersSetup
        //            .FirstOrDefaultAsync(u => u.Email == updateDto.Email);

        //        if (existingUser != null)
        //            return BadRequest($"Email '{updateDto.Email}' already exists");

        //        user.Email = updateDto.Email;
        //    }

        //    if (!string.IsNullOrEmpty(updateDto.ApiKey))
        //        user.ApiKey = updateDto.ApiKey;

        //    if (updateDto.IsActive != user.IsActive)
        //        user.IsActive = updateDto.IsActive;

        //    if (updateDto.RateLimitRequestsPerMinute > 0)
        //        user.RateLimitRequestsPerMinute = updateDto.RateLimitRequestsPerMinute;

        //    if (updateDto.RateLimitBurst > 0)
        //        user.RateLimitBurst = updateDto.RateLimitBurst;

        //    if (!string.IsNullOrEmpty(updateDto.AllowedEndpoints))
        //        user.AllowedEndpoints = updateDto.AllowedEndpoints;

        //    if (!string.IsNullOrEmpty(updateDto.Description))
        //        user.Description = updateDto.Description;

        //    _npsdbcontext.UsersSetup.Update(user);
        //    await _npsdbcontext.SaveChangesAsync();

        //    return Ok(user);
        //}

        [HttpPatch("ActivateUser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult> ActivateUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("User ID cannot be empty");

            var user = await _npsdbcontext.UsersSetup.FindAsync(id);

            if (user == null)
                return NotFound($"User with ID {id} not found");

            user.IsActive = true;
            _npsdbcontext.UsersSetup.Update(user);
            await _npsdbcontext.SaveChangesAsync();

            return Ok(new { message = "User activated successfully", userId = id });
        }

        [HttpPatch("DeactivateUser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult> DeactivateUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("User ID cannot be empty");

            var user = await _npsdbcontext.UsersSetup.FindAsync(id);

            if (user == null)
                return NotFound($"User with ID {id} not found");

            user.IsActive = false;
            _npsdbcontext.UsersSetup.Update(user);
            await _npsdbcontext.SaveChangesAsync();

            return Ok(new { message = "User deactivated successfully", userId = id });
        }

        [HttpPatch("UpdateExpireDate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateExpireDate(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("User ID cannot be empty");

            var user = await _npsdbcontext.UsersSetup.FindAsync(id);

            if (user == null)
                return NotFound($"User with ID {id} not found");

            user.ExpiredAt = DateTime.UtcNow;
            _npsdbcontext.UsersSetup.Update(user);
            await _npsdbcontext.SaveChangesAsync();

            return Ok(new
            {
                message = "Last accessed updated successfully",
                userId = id,
                ExpiredAt = user.ExpiredAt
            });
        }

        [HttpPut("UpdateApiKey/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateApiKey(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("User ID cannot be empty");

            var user = await _npsdbcontext.UsersSetup.FindAsync(id);

            if (user == null)
                return NotFound($"User with ID {id} not found");

            user.ApiKey = GenerateApiKey();
            _npsdbcontext.UsersSetup.Update(user);
            await _npsdbcontext.SaveChangesAsync();

            return Ok(new
            {
                message = "API Key updated successfully",
                userId = id,
                apiKey = user.ApiKey
            });
        }

        //[HttpDelete("DeleteUser/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> DeleteUser(string id)
        //{
        //    if (string.IsNullOrWhiteSpace(id))
        //        return BadRequest("User ID cannot be empty");

        //    var user = await _npsdbcontext.UsersSetup.FindAsync(id);

        //    if (user == null)
        //        return NotFound($"User with ID {id} not found");

        //    _npsdbcontext.UsersSetup.Remove(user);
        //    await _npsdbcontext.SaveChangesAsync();

        //    return Ok(new { message = "User deleted successfully", userId = id });
        //}

       private string GenerateApiKey()
        {
            //return Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            //    .Replace("=", "")
            //    .Substring(0, 32);

            return Guid.NewGuid().ToString("N").Substring(0, 16);
        }

        private UsersSetup MapToDto(UsersSetup user)
        {
            return new UsersSetup
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                ApiKey = user.ApiKey,
               // Roles = user.Roles,
                IsActive = user.IsActive,
                RateLimitRequestsPerMinute = user.RateLimitRequestsPerMinute,
                RateLimitBurst = user.RateLimitBurst,
                AllowedEndpoints = user.AllowedEndpoints,
                CreatedAt = user.CreatedAt,
                ExpiredAt = user.ExpiredAt,
                Description = user.Description
            };
        }
    }
}





















//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using NibbssNPSPaymentStack.API.Models.Model;
//using NibbssNPSPaymentStack.Business.Contract;
//using NibbssNPSPaymentStack.Business.Models;
//using NibssNPSPaymentStack.Data;
//using Microsoft.EntityFrameworkCore;
//using System;


//namespace NibbssNPSPaymentStack.API.Controllers
//{
//    public class NPSAdminController : Controller
//    {

//        private readonly INibssNPSPayments _npsPayment;
//        private readonly NPSDBContext _npsdbcontext;
//        private readonly ILogger<NPSAdminController> _logger;
//        private readonly NpsSettings _settings;
//        private readonly UserManager<IdentityUser> _userManager;
//        public NPSAdminController(INibssNPSPayments npsPayment, ILogger<NPSAdminController> logger, IOptions<NpsSettings> options, NPSDBContext npsdbcontext, UserManager<IdentityUser> userManager)
//        {
//            _npsPayment = npsPayment;
//            _logger = logger;
//            _npsdbcontext = npsdbcontext;
//            _settings = options.Value;
//            _userManager = userManager;
//        }



//        [HttpPost("AllEndpoints")]
//        [Consumes("application/xml", "text/xml")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        public async Task<ActionResult> AllEndpoints()
//        {
//            var result = _npsdbcontext.AvailableEndpoints
//       .Select(r => new
//       {
//           RouteTemplate = r.RouteTemplate,
//           Description = r.Description
//       })
//       .ToList();


//            return Ok(result);
//        }


//        [HttpPost("EnabledEndpoints")]
//        [Consumes("application/xml", "text/xml")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        public async Task<ActionResult> EnabledEndpoints()
//        {

//                    var result = _npsdbcontext.AvailableEndpoints
//                     .Where(r => r.IsEnabled == true)
//           .Select(r => new
//           {
//               RouteTemplate = r.RouteTemplate,
//               Description = r.Description
//           })
//           .ToList();

//                return Ok(result);
//            }


//        [HttpGet("Getregistered-Users")]
//        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult<IEnumerable<object>>> GetRegisteredUsers()
//        {
//            var users = _userManager.Users.ToList();


//            return Ok(users);
//        }

//         [HttpGet("Getregisteredusers-By-Username")]
//        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult<IEnumerable<object>>> GetRegisteredByUsername(string getname)
//        {
//            if (string.IsNullOrWhiteSpace(getname))
//                return BadRequest("Username cannot be empty.");

//            var users = _userManager.Users
//                .Where(a => a.UserName == getname)
//                .ToList();

//            return Ok(users);
//        }




//        // POST: api/UserProfile

//        [HttpPost("CreateUser")]
//        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<UsersSetup>> CreateUser([FromBody] UsersSetup createDto)
//        {
//            // 1. Validate input
//            if (string.IsNullOrWhiteSpace(createDto.Username))
//                return BadRequest("Username cannot be empty.");

//            // 2. Check if user exists in AspNetUsers
//            var user = await _userManager.Users
//                .FirstOrDefaultAsync(a => a.UserName == createDto.Username);

//            if (user == null)
//                return BadRequest($"Username '{createDto.Username}' does not exist in AspNetUsers.");

//            // 3. Check if username already exists in UsersSetup
//            var existingUserByUsername = await _npsdbcontext.UsersSetup
//                .FirstOrDefaultAsync(u => u.Username == user.UserName);

//            if (existingUserByUsername != null)
//                return BadRequest($"Username '{createDto.Username}' already exists in UsersSetup.");

//            // 4. Check if email already exists in UsersSetup (optional but good practice)
//            if (!string.IsNullOrWhiteSpace(createDto.Email))
//            {
//                var existingUserByEmail = await _npsdbcontext.UsersSetup
//                    .FirstOrDefaultAsync(u => u.Email == createDto.Email);

//                if (existingUserByEmail != null)
//                    return BadRequest($"Email '{createDto.Email}' already exists in UsersSetup.");
//            }

//            // 5. Create new UsersSetup record
//            var newUser = new UsersSetup
//            {
//                Username = user.UserName,
//                Email = user.Email, // Use email from AspNetUsers, not from DTO
//                ApiKey = GenerateApiKey(),
//                Roles = createDto.Roles,
//                IsActive = false, // Default to false until manually activated
//                RateLimitRequestsPerMinute = createDto.RateLimitRequestsPerMinute,
//                RateLimitBurst = createDto.RateLimitBurst,
//                AllowedEndpoints = createDto.AllowedEndpoints,
//                CreatedAt = DateTime.UtcNow,
//                Description = createDto.Description
//            };

//            await _npsdbcontext.UsersSetup.AddAsync(newUser);
//            await _npsdbcontext.SaveChangesAsync();
//            // return (User);  //
//            return CreatedAtAction(nameof(GetUser), new { username = newUser.Username }, newUser);
//        }











//        // GET: api/UserProfile
//        [HttpGet("Getprofiled-Usernames")]
//        [ProducesResponseType(typeof(IEnumerable<UsersSetup>), StatusCodes.Status200OK)]
//        public async Task<ActionResult<IEnumerable<UsersSetup>>> GetAllUsers()
//        {
//            var users = _npsdbcontext.UsersSetup.ToList();

//            return Ok(users);
//        }





//        // GET: api/UserProfile/{id}
//        [HttpGet("{id}")]
//        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult<UsersSetup>> GetUser(string id)
//        {
//            var user = await _npsdbcontext.UsersSetup.FindAsync(id);
//            if (user == null)
//                return NotFound($"User with ID {id} not found");

//            return Ok(user);
//        }




//        // GET: api/UserProfile/username/{username}
//        [HttpGet("username/{username}")]
//        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult<UsersSetup>> GetUserByUsername(string username)
//        {
//            var user = _npsdbcontext.UsersSetup
//                .FirstOrDefault(u => u.Username == username);

//            if (user == null)
//                return NotFound($"User with username {username} not found");

//            return Ok(user);
//        }

//        // GET: api/UserProfile/email/{email}
//        [HttpGet("email/{email}")]
//        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult<UsersSetup>> GetUserByEmail(string email)
//        {
//            var user = _npsdbcontext.UsersSetup
//                .FirstOrDefault(u => u.Email == email);

//            if (user == null)
//                return NotFound($"User with email {email} not found");

//            return Ok(MapToDto(user));
//        }

//        // GET: api/UserProfile/active
//        [HttpGet("active")]
//        [ProducesResponseType(typeof(IEnumerable<UsersSetup>), StatusCodes.Status200OK)]
//        public async Task<ActionResult<IEnumerable<UsersSetup>>> GetActiveUsers()
//        {
//            var users =  _npsdbcontext.UsersSetup
//                .Where(u => u.IsActive == true)
//                .ToList();

//            return Ok(users);
//        }

//        // GET: api/UserProfile/inactive
//        [HttpGet("inactive")]
//        [ProducesResponseType(typeof(IEnumerable<UsersSetup>), StatusCodes.Status200OK)]
//        public async Task<ActionResult<IEnumerable<UsersSetup>>> GetInactiveUsers()
//        {
//            var users =  _npsdbcontext.UsersSetup
//                .Where(u => u.IsActive == false)
//                .ToList();

//            return Ok(users);
//        }



//        // PUT: api/UserProfile/{id}
//        [HttpPut("UpdateUser{id}")]
//        [ProducesResponseType(typeof(UsersSetup), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<UsersSetup>> UpdateUser(string id, [FromBody] UsersSetup updateDto)
//        {
//            var user = await _npsdbcontext.UsersSetup.FindAsync(id);
//            if (user == null)
//                return NotFound($"User with ID {id} not found");

//            // Check if username is being changed and if it already exists
//            if (!string.IsNullOrEmpty(updateDto.Username) && updateDto.Username != user.Username)
//            {
//                var existingUser =  _npsdbcontext.UsersSetup
//                    .FirstOrDefault(u => u.Username == updateDto.Username);
//                if (existingUser != null)
//                    return BadRequest($"Username '{updateDto.Username}' already exists");
//                user.Username = updateDto.Username;
//            }

//            // Check if email is being changed and if it already exists
//            if (!string.IsNullOrEmpty(updateDto.Email) && updateDto.Email != user.Email)
//            {
//                var existingUser =  _npsdbcontext.UsersSetup
//                    .FirstOrDefault(u => u.Email == updateDto.Email);
//                if (existingUser != null)
//                    return BadRequest($"Email '{updateDto.Email}' already exists");
//                user.Email = updateDto.Email;
//            }

//            if (!string.IsNullOrEmpty(updateDto.ApiKey))
//                user.ApiKey = updateDto.ApiKey;



//            if (updateDto.IsActive)
//                user.IsActive = updateDto.IsActive;

//            //if (updateDto.RateLimitRequestsPerMinute"")
//            //    user.RateLimitRequestsPerMinute = updateDto.RateLimitRequestsPerMinute;


//            //if (updateDto.RateLimitBurst)
//            //    user.RateLimitBurst = updateDto.RateLimitBurst;

//            //if (!string.IsNullOrEmpty(updateDto.AllowedEndpoints))
//            //    user.AllowedEndpoints = updateDto.AllowedEndpoints;

//            if (!string.IsNullOrEmpty(updateDto.Description))
//                user.Description = updateDto.Description;

//            _npsdbcontext.UsersSetup.Update(user);
//            await _npsdbcontext.SaveChangesAsync();

//            return Ok(MapToDto(user));
//        }

//        // PATCH: api/UserProfile/{id}/activate
//        [HttpPatch("{id}/activate")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult> ActivateUser(string id)
//        {
//            var user = await _npsdbcontext.UsersSetup.FindAsync(id);
//            if (user == null)
//                return NotFound($"User with ID {id} not found");

//            user.IsActive = true;
//            _npsdbcontext.UsersSetup.Update(user);
//            await _npsdbcontext.SaveChangesAsync();

//            return Ok(new { message = "User activated successfully", userId = id });
//        }

//        // PATCH: api/UserProfile/{id}/deactivate
//        [HttpPatch("{id}/deactivate")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult> DeactivateUser(string id)
//        {
//            var user = await _npsdbcontext.UsersSetup.FindAsync(id);
//            if (user == null)
//                return NotFound($"User with ID {id} not found");

//            user.IsActive = false;
//            _npsdbcontext.UsersSetup.Update(user);
//            await _npsdbcontext.SaveChangesAsync();

//            return Ok(new { message = "User deactivated successfully", userId = id });
//        }

//        // PATCH: api/UserProfile/{id}/update-last-accessed
//        [HttpPatch("{id}/update-last-accessed")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult> UpdateLastAccessed(string id)
//        {
//            var user = await _npsdbcontext.UsersSetup.FindAsync(id);
//            if (user == null)
//                return NotFound($"User with ID {id} not found");

//            user.LastAccessed = DateTime.UtcNow;
//            _npsdbcontext.UsersSetup.Update(user);
//            await _npsdbcontext.SaveChangesAsync();

//            return Ok(new { message = "Last accessed updated successfully", userId = id, lastAccessed = user.LastAccessed });
//        }

//        // PUT: api/UserProfile/{id}/update-apikey
//        [HttpPut("{id}/update-apikey")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult> UpdateApiKey(string id)
//        {
//            var user = await _npsdbcontext.UsersSetup.FindAsync(id);
//            if (user == null)
//                return NotFound($"User with ID {id} not found");

//            user.ApiKey = GenerateApiKey();
//            _npsdbcontext.UsersSetup.Update(user);
//            await _npsdbcontext.SaveChangesAsync();

//            return Ok(new { message = "API Key updated successfully", userId = id, apiKey = user.ApiKey });
//        }

//        //// PUT: api/UserProfile/{id}/allowed-endpoints
//        //[HttpPut("{id}/allowed-endpoints")]
//        //[ProducesResponseType(StatusCodes.Status200OK)]
//        //[ProducesResponseType(StatusCodes.Status404NotFound)]
//        //public async Task<ActionResult> UpdateAllowedEndpoints(string id, [FromBody] UpdateAllowedEndpointsDto dto)
//        //{
//        //    var user = await _context.UsersSetup.FindAsync(id);
//        //    if (user == null)
//        //        return NotFound($"User with ID {id} not found");

//        //    user.AllowedEndpoints = dto.AllowedEndpoints;
//        //    _context.UsersSetup.Update(user);
//        //    await _context.SaveChangesAsync();

//        //    return Ok(new { message = "Allowed endpoints updated successfully", userId = id, allowedEndpoints = user.AllowedEndpoints });
//        //}

//        // DELETE: api/UserProfile/{id}
//        [HttpDelete("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult> DeleteUser(string id)
//        {
//            var user = await _npsdbcontext.UsersSetup.FindAsync(id);
//            if (user == null)
//                return NotFound($"User with ID {id} not found");

//            _npsdbcontext.UsersSetup.Remove(user);
//            await _npsdbcontext.SaveChangesAsync();

//            return Ok(new { message = "User deleted successfully", userId = id });
//        }

//        // Helper Methods
//        private string GenerateApiKey()
//        {
//            return Convert.ToBase64String(Guid.NewGuid().ToByteArray())
//                .Replace("=", "")
//                .Substring(0, 32);
//        }

//        private UsersSetup MapToDto(UsersSetup user)
//        {
//            return new UsersSetup
//            {
//               // UserId = user.Id,
//                Username = user.Username,
//                Email = user.Email,
//                ApiKey = user.ApiKey,
//                Roles = user.Roles,
//                IsActive = user.IsActive,
//                RateLimitRequestsPerMinute = user.RateLimitRequestsPerMinute,
//                RateLimitBurst = user.RateLimitBurst,
//                AllowedEndpoints = user.AllowedEndpoints,
//                CreatedAt = user.CreatedAt,
//                LastAccessed = user.LastAccessed,
//                Description = user.Description
//            };
//        }
//    }


//}
