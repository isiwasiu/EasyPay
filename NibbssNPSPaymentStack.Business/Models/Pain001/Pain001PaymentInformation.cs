using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Pain013;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    public class Pain001PaymentInformation
    {
         [XmlElement("PmtInfId", Namespace = "")]
            public string? PaymentInformationId { get; set; }

            [XmlElement("PmtMtd", Namespace = "")]
            public string? PaymentMethod { get; set; } // TRF

            [XmlElement("BtchBookg", Namespace = "")]
            public bool BatchBooking { get; set; }

            [XmlElement("NbOfTxs", Namespace = "")]
            public int NumberOfTransactions { get; set; }

            [XmlElement("CtrlSum", Namespace = "")]
            public decimal ControlSum { get; set; }

            [XmlElement("ReqdExctnDt", Namespace = "")]
            public Pain001RequestedExecutionDate? RequestedExecutionDate { get; set; }

            [XmlElement("Dbtr", Namespace = "")]
            public Party? Debtor { get; set; }

            [XmlElement("DbtrAcct", Namespace = "")]
            public Account? DebtorAccount { get; set; }

            [XmlElement("DbtrAgt", Namespace = "")]
            public Agent? DebtorAgent { get; set; }

            [XmlElement("ChrgBr", Namespace = "")]
            public string? ChargeBearer { get; set; }

            [XmlElement("CdtTrfTxInf", Namespace = "")]
            public CreditTransferTransactionInformation? CreditTransferTransactions { get; set; }
         
    }
}
