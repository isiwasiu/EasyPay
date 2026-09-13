using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain012
{
    public class OriginalMandateWrapper
    {
         [XmlElement(ElementName = "OrgnlMndtId", Namespace = "")]
         public string? OrgnlMndtId { get; set; }

         [XmlElement(ElementName = "OrgnlMndt", Namespace = "")]
         public Pain012OriginalMandate? OrgnlMndt { get; set; }
    }
}
