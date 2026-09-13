using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class Assignment
    {
        [XmlElement("MsgId", Namespace = "")]
        public string? MsgId { get; set; }

        // ISO-8601 datetime
        [XmlElement("CreDtTm", Namespace = "")]
        public DateTime CreDtTm { get; set; }

        [XmlElement("Cretr", Namespace = "")]
        public Creator? Creator { get; set; }

        [XmlElement("Assgnr", Namespace = "")]
        public AssigningParty? Assigner { get; set; }

        [XmlElement("Assgne", Namespace = "")]
        public AssignedParty? Assignee { get; set; }
    }

    public class Acmt024Assignment
    {
        [XmlElement("MsgId", Namespace = "")]
        public string? MsgId { get; set; }

        // ISO-8601 datetime
        [XmlElement("CreDtTm", Namespace = "")]
        public DateTime CreDtTm { get; set; }

        [XmlElement("Assgnr", Namespace = "")]
        public AssignedParty? Assigner { get; set; }

        [XmlElement("Assgne", Namespace = "")]
        public AssigningParty? Assignee { get; set; }
    }

}
