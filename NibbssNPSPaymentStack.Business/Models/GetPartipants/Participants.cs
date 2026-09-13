using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.GetPartipants
{
    [XmlRoot("participants")]
    public class Participants
    {
        [XmlElement("participant")]
        public List<Participant>? Participant { get; set; }
    }
}
