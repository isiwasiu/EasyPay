using Microsoft.Extensions.Logging;
using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NibbssNPSPaymentStack.Business.Utility
{
    public class NpsSecurity
    {
        public static Dictionary<string, object> GenerateKeyPair(string privateKeyName, string publicKeyName)
        {
            using var rsa = RSA.Create(2048);
            var privateKeyPem = ConvertPrivateKeyToPem(rsa);
            var publicKeyPem = ConvertPublicKeyToPem(rsa);

            return new Dictionary<string, object>
            {
                [privateKeyName] = privateKeyPem,
                [publicKeyName] = publicKeyPem
            };
        }

        public static RSA LoadPrivateKey(string filePath)
        {
            string pemContent = File.ReadAllText(filePath);
            string base64 = ExtractBase64FromPem(pemContent, "PRIVATE KEY");
            byte[] keyBytes = Convert.FromBase64String(base64);

            var rsa = RSA.Create();
            rsa.ImportPkcs8PrivateKey(keyBytes, out _);
            Console.WriteLine($"Private key loaded from {filePath}");
            return rsa;
        }

        public static RSA LoadPublicKey(string filePath)
        {
            string pemContent = File.ReadAllText(filePath);
            string base64 = ExtractBase64FromPem(pemContent, "PUBLIC KEY");
            byte[] keyBytes = Convert.FromBase64String(base64);

            var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(keyBytes, out _);
            Console.WriteLine($"Public key loaded from {filePath}");
            return rsa;
        }

        private static string ConvertPrivateKeyToPem(RSA rsa)
        {
            byte[] privateKeyBytes = rsa.ExportPkcs8PrivateKey();
            return FormatPem(privateKeyBytes, "PRIVATE KEY");
        }

        private static string ConvertPublicKeyToPem(RSA rsa)
        {
            byte[] publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();
            return FormatPem(publicKeyBytes, "PUBLIC KEY");
        }

        private static string FormatPem(byte[] keyBytes, string pemLabel)
        {
            string base64 = Convert.ToBase64String(keyBytes);
            var sb = new StringBuilder();
            sb.AppendLine($"-----BEGIN {pemLabel}-----");

            // Wrap lines at 64 characters
            for (int i = 0; i < base64.Length; i += 64)
            {
                int length = Math.Min(64, base64.Length - i);
                sb.AppendLine(base64.Substring(i, length));
            }

            sb.AppendLine($"-----END {pemLabel}-----");
            return sb.ToString();
        }

        private static string ExtractBase64FromPem(string pemContent, string expectedLabel)
        {
            // Remove header and footer, then remove all whitespace
            string header = $"-----BEGIN {expectedLabel}-----";
            string footer = $"-----END {expectedLabel}-----";

            int start = pemContent.IndexOf(header, StringComparison.Ordinal);
            if (start == -1)
                throw new ArgumentException($"Invalid PEM: missing {header}");

            start += header.Length;
            int end = pemContent.IndexOf(footer, start, StringComparison.Ordinal);
            if (end == -1)
                throw new ArgumentException($"Invalid PEM: missing {footer}");

            string inner = pemContent.Substring(start, end - start);
            // Remove all whitespace (newlines, spaces, etc.)
            return string.Concat(inner.Where(c => !char.IsWhiteSpace(c)));
        }


        public string ExtractNibssError(string responseBody)
        {
            if (string.IsNullOrEmpty(responseBody))
                return "null";

            try
            {
                var xml = XDocument.Parse(responseBody);

                Console.WriteLine("\r\n <========   Error Body   ======> \r\r {@xm}  \r \n", xml);



                // SOAP fault (common in NIBSS)
                var faultString = xml.Descendants()
                    .FirstOrDefault(x => x.Name.LocalName == "faultstring")?.Value;
                if (!string.IsNullOrEmpty(faultString))
                    return faultString;

                // NIBSS custom error structure
                var respCode = xml.Descendants()
                    .FirstOrDefault(x => x.Name.LocalName == "ResponseCode")?.Value;
                var respDesc = xml.Descendants()
                    .FirstOrDefault(x => x.Name.LocalName == "ResponseDescription")?.Value;

                if (!string.IsNullOrEmpty(respCode))
                    return $"{respCode} - {respDesc ?? "No description"}";

                // Direct error element
                var error = xml.Descendants()
                    .FirstOrDefault(x => x.Name.LocalName == "Error")?.Value;
                if (!string.IsNullOrEmpty(error))
                    return error;
            }
            catch (XmlException)
            {
                // Not XML – return the raw body if it's short, otherwise null
                if (responseBody.Length < 500)
                    return responseBody;
            }

            return "null";
        }


    }

}
