

using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class Account
    {
        [XmlElement("Id" ,Namespace = "")]
        public AccountId? Id { get; set; }
        public string? Nm {  get; set; }
    }

    public class AccountId
    {
        [XmlElement("IBAN", Namespace = "")]
        public string? IBAN { get; set; }
    }
}

