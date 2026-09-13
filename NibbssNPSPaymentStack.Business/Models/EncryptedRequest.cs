using System.Security.Cryptography;
using System.Xml;

namespace NibbssNPSPaymentStack.Business.Models
{
    public class EncryptedRequest
    {
       public XmlDocument? doc { get; set; }
       public string? xpathExpression { get; set; }
       public RSA? publicKey {  get; set; }
       public string? nameSpace {  get; set; }
    }
}
