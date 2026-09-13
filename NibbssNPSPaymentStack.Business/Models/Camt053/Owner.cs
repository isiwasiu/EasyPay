using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class Owner
    {
        [XmlElement("Id")]
        public OwnerId? Id { get; set; }
    }
}
