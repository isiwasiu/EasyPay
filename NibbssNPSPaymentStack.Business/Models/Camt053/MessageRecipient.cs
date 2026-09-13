using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class MessageRecipient
    {

        [XmlElement("Nm")]
        public string? Nm { get; set; }

        [XmlElement("Id")]
        public RecipientId? Id { get; set; }

    }
}
