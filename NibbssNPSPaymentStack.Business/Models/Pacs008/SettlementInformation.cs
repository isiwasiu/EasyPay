using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{

    public class SettlementInformation
    {
        [XmlElement("SttlmMtd")]
        public string? SttlmMtd { get; set; } // CLRG
    }

}
