using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NibbssNPSPaymentStack.Business.Contract;
using NibbssNPSPaymentStack.Business.Models;
using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.acmt024;
using NibbssNPSPaymentStack.Business.Models.Camt060;
using NibbssNPSPaymentStack.Business.Models.GetPartipants;
using NibbssNPSPaymentStack.Business.Models.Pacs002;
using NibbssNPSPaymentStack.Business.Models.Pacs003;
using NibbssNPSPaymentStack.Business.Models.Pacs008;
using NibbssNPSPaymentStack.Business.Models.Pacs028;
using NibbssNPSPaymentStack.Business.Models.Pain001;
using NibbssNPSPaymentStack.Business.Models.Pain008;
using NibbssNPSPaymentStack.Business.Models.Pain009;
using NibbssNPSPaymentStack.Business.Models.Pain010;
using NibbssNPSPaymentStack.Business.Models.pain011;
using NibbssNPSPaymentStack.Business.Models.Pain013;
using NibbssNPSPaymentStack.Business.Models.Response;
using NibbssNPSPaymentStack.Business.Utility;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace NibbssNPSPaymentStack.API.Controllers
{
    [Route("")]
    [ApiController]
    public class NPSOutwardController : ControllerBase
    {
        private readonly INibssNPSPayments _npsPayment;
        private readonly ILogger<NPSOutwardController> _logger;
        private readonly NpsSettings _settings;
        public NPSOutwardController(INibssNPSPayments npsPayment, ILogger<NPSOutwardController> logger, IOptions<NpsSettings> options)
        {
            _npsPayment = npsPayment;
            _logger = logger;
            _settings = options.Value   ;
        }

        [HttpGet("GetParticipant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomResult<List<ParticipantViewModel>>>> GetParticipant()
        {
            var partipantResponse = await _npsPayment.GetParticipant();

            if (!partipantResponse.Succeeded)
            {
                return BadRequest(partipantResponse);
            }

            return Ok(partipantResponse);
        }



        [HttpPost("Account-Verification")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Acmt023Response>>> AccountVerification([FromBody] AccountVerificationRequest payload)
        {
            var acmt023Response = await _npsPayment.ProcessAcmt023(payload);

            if (!acmt023Response.Succeeded)
            {
                return BadRequest(acmt023Response);
            }

            return Ok(acmt023Response);
        }




        [HttpGet("Account-Verification")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomResult<IEnumerable<GetAccountVerificationViewModel>>>> GetAccountVerification(int pageIndex, int pageSize)
        {
            var accountVerifications = await _npsPayment.GetAccountVerification(pageIndex, pageSize);

            return Ok(accountVerifications);
        }




        [HttpGet("Account-Verification/{MessageId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomResult<GetAccountDetailsByMessageIdViewModel>>> GetAccountVerificationByMessageId(string MessageId)
        {
            var accountVerification = await _npsPayment.GetAccountVerificationByMessageId(MessageId);

            return Ok(accountVerification);
        }




        [HttpPost("Credit-Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pacs008Response>>> CreditTransfer([FromBody] CreditTransferRequest payload)
        {

            var pacs008Response = await _npsPayment.ProcessPacs008(payload);

            if (!pacs008Response.Succeeded)
            {
                return BadRequest(pacs008Response);
            }

            return Ok(pacs008Response);
        }




        [HttpPost("Customer-Debit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pacs003Response>>> CustomerDebit([FromBody] Pacs003Request payload)
        {
            var Pacs003Response = await _npsPayment.ProcessPacs003(payload);

            if (!Pacs003Response.Succeeded)
            {
                return BadRequest(Pacs003Response);
            }

            return Ok(Pacs003Response);
        }





        [HttpPost("Debit-Mandate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pain009Response>>> DirectDebitMandate([FromBody] Pain009Request payload)
        {
            var pain009Response = await _npsPayment.ProcessPain009(payload);

            if (!pain009Response.Succeeded)
            {
                return BadRequest(pain009Response);
            }

            return Ok(pain009Response);
        }



        [HttpPost("Mandate-Amendment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pain010Response>>> MandateAmendment([FromBody] Pain010Request payload)
        {
            var pain010Response = await _npsPayment.ProcessPain010(payload);

            if (!pain010Response.Succeeded)
            {
                return BadRequest(pain010Response);
            }

            return Ok(pain010Response);
        }





        [HttpPost("Mandate-Cancellation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pain011Response>>> MandateCancellation([FromBody] pain011Request payload)
        {
            var pain011Response = await _npsPayment.ProcessPain011(payload);

            if (!pain011Response.Succeeded)
            {
                return BadRequest(pain011Response);
            }

            return Ok(pain011Response);
        }






        [HttpPost("Account-Report")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Camt060Response>>> AccountReport([FromBody] Camt060Request payload)
        {
            var Camt060Response = await _npsPayment.ProcessCamt060(payload);


            if (!Camt060Response.Succeeded)
            {
                return BadRequest(Camt060Response);
            }

            return Ok(Camt060Response);
        }





        [HttpPost("Requests-To-Pay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pain013Response>>> CreditorPaymentActivation([FromBody] Pain013Request payload)
        {
            var Pain013Response = await _npsPayment.ProcessPain013(payload);

            if (!Pain013Response.Succeeded)
            {
                return BadRequest(Pain013Response);
            }

            return Ok(Pain013Response);
        }





        [HttpPost("Easy-Pay/Customer-Credit-Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pain001Response>>> EasyPay([FromBody] Pain001Request payload)
        {
            var Pain001Response = await _npsPayment.ProcessPain001(payload);

            if (!Pain001Response.Succeeded)
            {
                return BadRequest(Pain001Response);
            }

            return Ok(Pain001Response);
        }



        [HttpPost("Direct-Credit-Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pain008Response>>> DirectCredit ([FromBody] Pain008Request payload)
        {

      
            var Pain001Response = await _npsPayment.ProcessPain008(payload);

            if (!Pain001Response.Succeeded)
            {
                return BadRequest(Pain001Response);
            }

            return Ok(Pain001Response);
        }






        [HttpPost("CreditTransferReport")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Pacs002Response>>> CreditTransferReport()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();
            string realXml = Regex.Unescape(xml);

            _logger.LogInformation("Credit Transfer Report request with {@req}", realXml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            doc.LoadXml(realXml);

            var response = await _npsPayment.ProcessInwardPacs002(doc);

            return Ok(response);
        }





        [HttpPost("AccountVerificationStatusReport")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Acmt024Response>>> AccountVerificationStatusReport()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            string realXml = Regex.Unescape(xml);

            _logger.LogInformation("Account Verification Status request ==> {@req}", realXml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            doc.LoadXml(realXml);

            var response = await _npsPayment.ProcessInwardAcmt024(doc);

            return Ok(response);
        }






        // ==================== TRANSACTIONS STATUS ====================
        [HttpPost("TransactionStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomResult<Acmt024Response>>> TransactionStatus([FromBody] Pacs028Request payload)
        {
            var pacs028Response = await _npsPayment.ProcessPacs028(payload);

            if (!pacs028Response.Succeeded)
            {
                return BadRequest(pacs028Response);
            }

            return Ok(pacs028Response);
        }
        // =========================================================================


        // ==================== FIXED GENERATE KEYS ENDPOINT ====================
        [HttpPost("GenerateKeys")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateKeys()
        {
            try
            {
                // Use a dedicated folder (e.g., "Keys" under the app's content root)
                string keysDirectory = Path.Combine("C:\\SecurityKeys\\", "Keys");
                if (!Directory.Exists(keysDirectory))
                    Directory.CreateDirectory(keysDirectory);

                string privateKeyName = Path.Combine(keysDirectory, "privateKey.pem");
                string publicKeyName = Path.Combine(keysDirectory, "Pethahiah_public.pem");

                // Generate the key pair (assuming NpsSecurity.GenerateKeyPair returns Dictionary<string, object>)
                var keys = NpsSecurity.GenerateKeyPair(privateKeyName, publicKeyName);

                // Write the keys to files
                System.IO.File.WriteAllText(privateKeyName, (string)keys[privateKeyName]);
                System.IO.File.WriteAllText(publicKeyName, (string)keys[publicKeyName]);

                // Return the generated keys (or file paths) as JSON
                return Ok(new
                {
                    Message = "Keys generated successfully.",
                    PrivateKeyPath = privateKeyName,
                    PublicKeyPath = publicKeyName,
                    PrivateKeyPem = (string)keys[privateKeyName],
                    PublicKeyPem = (string)keys[publicKeyName]
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to generate RSA key pair.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Key generation failed.", Details = ex.Message });
            }
        }
        

        [HttpPost("encrypt")]
        [Consumes("text/plain", "application/xml", "text/xml")]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ValidateEncryption()
        {
            // ── Read body directly — completely bypasses JSON pipeline ────────────
            Request.EnableBuffering();
            string signedDoc;
            using (var reader = new StreamReader(
                       Request.Body,
                       encoding: Encoding.UTF8,
                       detectEncodingFromByteOrderMarks: false,
                       bufferSize: 4096,
                       leaveOpen: true))
            {
                signedDoc = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrWhiteSpace(signedDoc))
                return BadRequest(new
                {
                    code = "NULL_PAYLOAD",
                    message = "Request body is empty. Send raw XML with Content-Type: text/plain"
                });

            try
            {
                // ── Clean only JSON artifacts if present ──────────────────────────
                string cleanedXml = signedDoc
                    .Replace("\\\"", "\"")   // \"  →  "
                    .Replace("\\/", "/")    // \/  →  /
                    .Trim('"')               // remove wrapping JSON quotes if any
                    .Trim();

                // ── Load into XmlDocument ─────────────────────────────────────────
                //var xmlDoc = new XmlDocument();
                var xmlDoc = new XmlDocument
                {
                    PreserveWhitespace = true
                };
               // xmlDoc.PreserveWhitespace = true;
               xmlDoc.LoadXml(cleanedXml);

                //// ── Validate key path ─────────────────────────────────────────────
                //if (string.IsNullOrWhiteSpace(_settings.Pain014EncrypPath))
                //    return StatusCode(500, new
                //    {
                //        code = "KEY_NOT_CONFIGURED",
                //        message = "Pain014EncrypPath is not set in configuration."
                //    });

                //if (!System.IO.File.Exists(_settings.Pain014EncrypPath))
                //    return StatusCode(500, new
                //    {
                //        code = "KEY_NOT_FOUND",
                //        message = $"Key file not found: {_settings.Pain014EncrypPath}"
                //    });

                // ── Encrypt ───────────────────────────────────────────────────────
                string encryptedContent = _npsPayment.EncryptContent(
                    xmlDoc,
                    _settings.Pain014EncrypPath,
                    ApplicationConstant.Pain014);

                if (string.IsNullOrWhiteSpace(encryptedContent))
                    return StatusCode(500, new
                    {
                        code = "ENCRYPTION_EMPTY",
                        message = "Encryption returned empty. Check key file and XML structure."
                    });

                // ── Return as plain text ──────────────────────────────────────────
                return Content(encryptedContent, "text/plain", Encoding.UTF8);
            }
            catch (XmlException ex)
            {
                _logger.LogError(ex,
                    "Invalid XML received | Length={Len} | FirstChars={Chars}",
                    signedDoc.Length,
                    signedDoc.Length > 50 ? signedDoc[..50] : signedDoc);

                return BadRequest(new
                {
                    code = "INVALID_XML",
                    message = ex.Message,
                    hint = "Body must be raw valid XML. Content-Type must be text/plain"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in ValidateEncryption");
                return StatusCode(500, new
                {
                    code = "UNEXPECTED_ERROR",
                    message = ex.Message
                });
            }
        }



    }
}
