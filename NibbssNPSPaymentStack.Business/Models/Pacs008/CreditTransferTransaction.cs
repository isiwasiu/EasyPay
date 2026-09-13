using NibbssNPSPaymentStack.Business.Models.acmt023;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    public class CreditTransferTransaction
    {
        [XmlElement("PmtId")]
        public PaymentIdentification? PmtId { get; set; }

        [XmlElement("PmtTpInf")]
        public PaymentTypeInformation? PmtTpInf { get; set; }

        [XmlElement("IntrBkSttlmAmt")]
        public ActiveCurrencyAndAmount? IntrBkSttlmAmt { get; set; }

        [XmlElement("IntrBkSttlmDt")]
        public string? IntrBkSttlmDt { get; set; }

        [XmlElement("ChrgBr")]
        public string? ChrgBr { get; set; }

        [XmlElement("InstgAgt")]
        public Agent? InstgAgt3 { get; set; }

        [XmlElement("InstdAgt")]
        public Agent? InstdAgt4 { get; set; }

        [XmlElement("Dbtr")]
        public Dbtr? Dbtr { get; set; }

        [XmlElement("DbtrAcct")]
        public DbtrAcct? DbtrAcct { get; set; }

        [XmlElement("DbtrAgt")]
        public Agent? DbtrAgt { get; set; }

        [XmlElement("CdtrAgt")]
        public Agent? CdtrAgt { get; set; }

        [XmlElement("Cdtr")]
        public Cdtr? Cdtr { get; set; }

        [XmlElement("CdtrAcct")]
        public CdtrAcct? CdtrAcct { get; set; }

        [XmlElement("InstrForNxtAgt")]
        public List<InstructionForNextAgent>? InstrForNxtAgt { get; set; }

        [XmlElement("RmtInf")]
        public RemittanceInformation? RmtInf { get; set; }
    }

    public class Cdtr
    {
        public string? Nm {  get; set; }
    }

    public class CdtrAcct
    {
        public AccountIdentification? Id {  get; set; }
        public string? Nm {  get; set; }
    }
    public class InstructionForNextAgent
    {
        [XmlElement("InstrInf")]
        public string? InstrInf { get; set; }
    }

    public class RemittanceInformation
    {
        [XmlElement("Ustrd")]
        public string? Ustrd { get; set; }
    }
    public class Acmt024SupplementaryData
    {
        [XmlElement("PlcAndNm")]
        public string? PlcAndNm { get; set; }

        [XmlElement("Envlp")]
        public Acmt024Envlp? Envlp { get; set; }
    }
    public class SupplementaryData
    {
        [XmlElement("PlcAndNm")]
        public string? PlcAndNm { get; set; }

        [XmlElement("Envlp")]
        public Envlp? Envlp { get; set; }
    }

    public class Envlp
    {
        [XmlElement("CustomData")]
        public CustomData? CustomData { get; set; }
    }

    public class Acmt024Envlp
    {
        [XmlElement("CustomData")]
        public Acmt024CustomData? CustomData { get; set; }
    }


    public class Acmt024CustomData
    {
        [XmlElement("DebtorInfo")]
        public DebtorInfo? DebtorInfo { get; set; }

        [XmlElement(ElementName = "DebtorMetadata")]
        public DebtorMetadata? DebtorMetadata { get; set; }

        [XmlElement("CreditorInfo")]
        public CreditorInfo? CreditorInfo { get; set; }

        [XmlElement("TransactionInfo")]
        public Acm024TransactionInfo? TransactionInfo { get; set; }
    }

    public class CustomData
    {
        [XmlElement("DebtorInfo")]
        public DebtorInfo? DebtorInfo { get; set; }

        [XmlElement(ElementName = "DebtorMetadata")]
        public DebtorMetadata? DebtorMetadata { get; set; }

        [XmlElement("CreditorInfo")]
        public CreditorInfo? CreditorInfo { get; set; }

        [XmlElement(ElementName = "CreditorMetadata")]
        public CreditorMetadata? CreditorMetadata { get; set; }

        [XmlElement("TransactionInfo")]
        public TransactionInfo? TransactionInfo { get; set; }

    }

    public class CreditorInfo 
    {
        [XmlElement("AccountDesignation")]
        public string? AccountDesignation { get; set; }

        [XmlElement("IdType")]
        public string? IdType { get; set; }

        [XmlElement("IdValue")]
        public string? IdValue { get; set; }

        [XmlElement("AccountTier")]
        public string? AccountTier { get; set; }
    }

    public class DebtorInfo
    {
        [XmlElement("AccountDesignation")]
        public string? AccountDesignation { get; set; }

        [XmlElement("IdType")]
        public string? IdType { get; set; }

        [XmlElement("IdValue")]
        public string? IdValue { get; set; }

        [XmlElement("AccountTier")]
        public string? AccountTier { get; set; }
    }

    public class TransactionInfo
    {
        [XmlElement("TransactionLocation")]
        public string? TransactionLocation { get; set; }

        [XmlElement("NameEnquiryMsgId")]
        public string? NameEnquiryMsgId { get; set; }

        [XmlElement("ChannelCode")]
        public int ChannelCode { get; set; }

        [XmlElement("RiskRating")]
        public string? RiskRating { get; set; }
    }

    public class Acm024TransactionInfo
    {
        [XmlElement("RiskRating")]
        public string? RiskRating { get; set; }
    }


    public class Dbtr
    {
        [XmlElement("Nm")]
        public string? Nm { get; set; }
    }

    public class DbtrAcct
    {
        [XmlElement("Id")]
        public AccountIdentification? Id { get; set; }

        [XmlElement("Nm")]
        public string? Nm { get; set; }
    }

    public class AccountIdentification
    {
        [XmlElement("IBAN")]
        public string? IBAN { get; set; }
    }


}
