using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class RecipientId
    {
        [XmlElement("OrgId")]
        public OrganisationId? OrgId { get; set; }
    }
}
