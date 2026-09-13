using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models
{
    public  class AdminGateway
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Merchant Name is required")]
        public string MerchantName { get; set; }

        public string MerchantID { get; set; } = DateTime.Now.ToString("MMDDYY") + Random.Shared.Next(0, 1000000).ToString("D6");

        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }

        public int Bankid { get; set; }  
        
        public string BankName { get; set; }

        [Required(ErrorMessage = "Password  is required")]
        public string Password { get; set; }

        public string username { get; set; }

        public string usernamepsw { get; set; }
        public string ContpersonFirstName { get; set; }

        public string Address { get; set; }


        public string FeeBearer { get; set; }


        public double lowlimcharge { get; set; }

        public double UpperLimitcharge { get; set; }

    }
}

    

