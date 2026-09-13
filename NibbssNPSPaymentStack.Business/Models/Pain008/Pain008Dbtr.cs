using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public class Pain008Dbtr
    {
        [XmlElement("Nm")]
        public string DebtorName { get; set; }
    }
}
