using Azure;
using Microsoft.AspNetCore.Mvc;
using NibbssNPSPaymentStack.Business.Contract;
using NibbssNPSPaymentStack.Business.Models;
using NibbssNPSPaymentStack.Business.Models.acmt024;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml;

namespace NibbssNPSPaymentStack.API.Controllers
{
    [Route("")]
    [ApiController]
    public class NPSInwardController : ControllerBase
    {
        private readonly INibssNPSPayments _npsPayment;
        private readonly ILogger<NPSInwardController> _logger;
        public NPSInwardController(ILogger<NPSInwardController> logger, INibssNPSPayments npsPayment)
        {
            _logger = logger;
            _npsPayment = npsPayment;
        }

        [HttpPost("pacs008")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pacs008()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            _logger.LogInformation("\r\n   <====================  NPS Inward pacs008  Encrypted   ==============> is \r\n {@res} \r\n ", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };
            string realXml = Regex.Unescape(xml);
            doc.LoadXml(realXml);

            //decrypt and send pacs 002 to nibss

            var response = await _npsPayment.ProcessInwardPacs008(doc);

            return Ok(response);
        }




        [HttpPost("pacs002")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Pacs002()
        {
            Request.EnableBuffering();
            using var reader = new StreamReader(Request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            var xml = await reader.ReadToEndAsync();
            Request.Body.Position = 0;
            _logger.LogInformation("\r\n<======  Nibbs  Inward  Pacs002     ==========>]\r\n");
            //    _logger.LogInformation("\r\n NPSAcmt024 callback response for Acmt024 is {@res} \r\n", xml);
            ///_logger.LogInformation("NPS callback raw XML: {xml}", xml);

            if (string.IsNullOrWhiteSpace(xml))
            {
                _logger.LogError("Empty XML body received.");
                return BadRequest("Empty XML request body.");
            }

            // Only remove backslashes if truly necessary – better to avoid
            xml = xml.Replace("\\", "");

            var doc = new XmlDocument { PreserveWhitespace = true };
            try
            {
                doc.LoadXml(xml);
            }
            catch (XmlException ex)
            {
                _logger.LogError(ex, "\r\n Invalid Acmt024 XML received: {xml} \r\n", xml);
                return BadRequest($"Malformed XML: {ex.Message}");
            }
            //receive Inward 002 after successful outward 008 snd decrypt if you like
            await _npsPayment.ProcessInwardPacs002(doc);

            return Ok(xml);
        }






        [HttpPost("pacs028")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Pacs028()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            _logger.LogInformation("\r\n NPS callback response for Inward Pacs028 is \r\n {@res} \r\n  ", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            doc.LoadXml(xml);

            return Ok(xml);
        }






        [HttpPost("acmt023")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Acmt023()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            xml = xml.Replace("\\", "");

            _logger.LogInformation("\r\n <======= Nibss NPS  Inward  Acmt023  request \r\n {@res} \r\n    =======> \r\n", xml);



            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };



            //string cleanedXml = Regex.Unescape(xml);

            // string realXml = Regex.Unescape(xml);
            doc.LoadXml(xml);

            //receive Inward 024 and send 023 as outward
            await _npsPayment.ProcessInwardAcmt023(doc);

            return Ok(xml);
        }




        [HttpPost("pain009")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pain009()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            xml = xml.Replace("\\", "");

           // _logger.LogInformation(" \r\n NPS Encrypted  for Inward pain009 is \r\n {@res} \r\n", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };




            doc.LoadXml(xml);

            //receive Inward 024 and send 023 as outward
            var response = await _npsPayment.InwardPain009(doc);

            //  _logger.LogInformation(" \r\n Outward  Pain012 Response to  nibss => \r\n {@response} \r\n ", JsonSerializer.Serialize(response));

            return Ok(response);
        }


        [HttpPost("pain010")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pain010()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            xml = xml.Replace("\\", "");

            _logger.LogInformation("NPS callback response for pain010 is {@res}", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            //string cleanedXml = Regex.Unescape(xml);

            // string realXml = Regex.Unescape(xml);
            doc.LoadXml(xml);

            //receive Inward 024 and send 023 as outward
            var response = await _npsPayment.InwardPain010(doc);
            _logger.LogInformation("\r\n Pain012 response from nibss => \r\n{@res}\r\n ", JsonSerializer.Serialize(response));

            return Ok(response);
        }



        [HttpPost("pain011")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pain011()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            xml = xml.Replace("\\", "");

            _logger.LogInformation("\r\n NPS callback response for pain011 is \r\n {@res} \r\n ", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            // string cleanedXml = Regex.Unescape(xml);

            // string realXml = Regex.Unescape(xml);
            doc.LoadXml(xml);

            //receive Inward 024 and send 023 as outward
            var response = await _npsPayment.InwardPain011(doc);

            // _logger.LogInformation("\r\n Outward Pain012 response from nibss => \r\n{@res}\r\n ", JsonSerializer.Serialize(response));

            return Ok(response);
        }




        [HttpPost("pain012")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pain012()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            xml = xml.Replace("\\", "");

            _logger.LogInformation("NPS callback response for pain012 is {@res}", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            //string cleanedXml = Regex.Unescape(xml);

            // string realXml = Regex.Unescape(xml);
            doc.LoadXml(xml);

            //receive Inward 024 and send 023 as outward
            await _npsPayment.InwardPain012(doc);

            return Ok(xml);
        }





        [HttpPost("pain002")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pain002()

        {
            Request.EnableBuffering();
            using var reader = new StreamReader(Request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            var xml = await reader.ReadToEndAsync();
            Request.Body.Position = 0;
            _logger.LogInformation("\r\n<======  Nibbs  Inward  Acmt024    ==========>]\r\n");
            //    _logger.LogInformation("\r\n NPSAcmt024 callback response for Acmt024 is {@res} \r\n", xml);
            ///_logger.LogInformation("NPS callback raw XML: {xml}", xml);

            if (string.IsNullOrWhiteSpace(xml))
            {
                _logger.LogError("Empty XML body received.");
                return BadRequest("Empty XML request body.");
            }

            // Only remove backslashes if truly necessary – better to avoid
            xml = xml.Replace("\\", "");

            var doc = new XmlDocument { PreserveWhitespace = true };
            try
            {
                doc.LoadXml(xml);
            }
            catch (XmlException ex)
            {
                _logger.LogError(ex, "\r\n Invalid Acmt024 XML received: {xml} \r\n", xml);
                return BadRequest($"Malformed XML: {ex.Message}");
            }
         
            await _npsPayment.InwardPain002(doc);

            return Ok(doc);
        }





        [HttpPost("pain001")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pain001()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            xml = xml.Replace("\\", "");

            _logger.LogInformation("NPS callback response for pain001 is {@res}", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            //string cleanedXml = Regex.Unescape(xml);

            // string realXml = Regex.Unescape(xml);
            doc.LoadXml(xml);

            //receive Inward 001 and send 002 as outward
            var response = await _npsPayment.InwardPain001(doc);

            _logger.LogInformation("Pain002 response from nibss => {@res}", JsonSerializer.Serialize(response));

            return Ok(response);
        }






        //[HttpPost("pain013")]
        //[Consumes("application/xml", "text/xml")]
        //[ProducesResponseType(StatusCodes.Status200OK)]

        [HttpPost("pain013")]
        [Consumes("text/plain", "application/xml", "text/xml")]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> pain013()
        {
            // ── Read body directly — completely bypasses JSON pipeline ────────────
            Request.EnableBuffering();
            string signedDoc;
            using (var reader = new StreamReader(
                       Request.Body,
                       encoding: Encoding.UTF8,
                       detectEncodingFromByteOrderMarks: false,
                       bufferSize: 4096,
                       leaveOpen: true))
            {
                signedDoc = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrWhiteSpace(signedDoc))
                return BadRequest(new
                {
                    code = "NULL_PAYLOAD",
                    message = "Request body is empty. Send raw XML with Content-Type: text/plain"
                });

            try
            {
                // ── Clean only JSON artifacts if present ──────────────────────────
                string cleanedXml = signedDoc
                    .Replace("\\\"", "\"")   // \"  →  "
                    .Replace("\\/", "/")    // \/  →  /
                    .Trim('"')               // remove wrapping JSON quotes if any
                    .Trim();

                // ── Load into XmlDocument ─────────────────────────────────────────
                //var xmlDoc = new XmlDocument();
                var xmlDoc = new XmlDocument
                {
                    PreserveWhitespace = true
                };
                // xmlDoc.PreserveWhitespace = true;
                xmlDoc.LoadXml(cleanedXml);

             
                var response = await _npsPayment.InwardPain013(xmlDoc);

                _logger.LogInformation("Pain014 response from nibss => {@res}", JsonSerializer.Serialize(response));

                return Ok(response);

            }
            catch (XmlException ex)
            {
                _logger.LogError(ex,
                    "Invalid XML received | Length={Len} | FirstChars={Chars}",
                    signedDoc.Length,
                    signedDoc.Length > 50 ? signedDoc[..50] : signedDoc);

                return BadRequest(new
                {
                    code = "INVALID_XML",
                    message = ex.Message,
                    hint = "Body must be raw valid XML. Content-Type must be text/plain"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in ValidateEncryption");
                return StatusCode(500, new
                {
                    code = "UNEXPECTED_ERROR",
                    message = ex.Message
                });
            }
        }


      




        [HttpPost("pacs003")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pacs003()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            xml = xml.Replace("\\", "");

            _logger.LogInformation("NPS callback response for pacs003 is {@res}", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            //string cleanedXml = Regex.Unescape(xml);

            // string realXml = Regex.Unescape(xml);
            doc.LoadXml(xml);

            //receive Inward 024 and send 023 as outward
            var response = await _npsPayment.InwardPacs003(doc);

            _logger.LogInformation("Pacs003 response from nibss => {@res}", JsonSerializer.Serialize(response));

            return Ok(response);
        }







        [HttpPost("camt060")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
    
        public async Task<ActionResult> camt060()
        {
            // ── Read body directly — completely bypasses JSON pipeline ────────────
            Request.EnableBuffering();
            string signedDoc;
            using (var reader = new StreamReader(
                       Request.Body,
                       encoding: Encoding.UTF8,
                       detectEncodingFromByteOrderMarks: false,
                       bufferSize: 4096,
                       leaveOpen: true))
            {
                signedDoc = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrWhiteSpace(signedDoc))
                return BadRequest(new
                {
                    code = "NULL_PAYLOAD",
                    message = "Request body is empty. Send raw XML with Content-Type: text/plain"
                });

            try
            {
                // ── Clean only JSON artifacts if present ──────────────────────────
                string cleanedXml = signedDoc
                    .Replace("\\\"", "\"")   // \"  →  "
                    .Replace("\\/", "/")    // \/  →  /
                    .Trim('"')               // remove wrapping JSON quotes if any
                    .Trim();

                // ── Load into XmlDocument ─────────────────────────────────────────
                //var xmlDoc = new XmlDocument();
                var xmlDoc = new XmlDocument
                {
                    PreserveWhitespace = true
                };
                // xmlDoc.PreserveWhitespace = true;
                xmlDoc.LoadXml(cleanedXml);


            //receive Inward 024 and send 023 as outward
            var response = await _npsPayment.InwardCamt060(xmlDoc);

           // _logger.LogInformation("Camt053 or Camt052 response from nibss => {@res}", JsonSerializer.Serialize(response));

            return Ok(response);
        }

            catch (XmlException ex)           {
                _logger.LogError(ex,
                    "Invalid XML received | Length={Len} | FirstChars={Chars}",
                    signedDoc.Length,
                    signedDoc.Length > 50 ? signedDoc[..50] : signedDoc);

                return BadRequest(new
                {
            code = "INVALID_XML",
                    message = ex.Message,
                    hint = "Body must be raw valid XML. Content-Type must be text/plain"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in ValidateEncryption");
                return StatusCode(500, new
                {
        code = "UNEXPECTED_ERROR",
                    message = ex.Message
    });
            }
        }





        [HttpPost("pain014")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> pain014()
        {
            using var reader = new StreamReader(Request.Body);
            var xml = await reader.ReadToEndAsync();

            xml = xml.Replace("\\", "");

            _logger.LogInformation("NPS callback response for pain014 is {@res}", xml);

            var doc = new XmlDocument
            {
                PreserveWhitespace = true
            };

            //string cleanedXml = Regex.Unescape(xml);

            // string realXml = Regex.Unescape(xml);
            doc.LoadXml(xml);

            //receive Inward 024 and send 023 as outward
            await _npsPayment.InwardPain014(doc);

            return Ok(xml);
        }







        [HttpPost("acmt024")]
        [Consumes("application/xml", "text/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Acmt024Response>> Acmt024()

        {
            Request.EnableBuffering();
            using var reader = new StreamReader(Request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            var xml = await reader.ReadToEndAsync();
            Request.Body.Position = 0;
            _logger.LogInformation("\r\n<======  Nibbs  Inward  Acmt024    ==========>]\r\n");
        //    _logger.LogInformation("\r\n NPSAcmt024 callback response for Acmt024 is {@res} \r\n", xml);
            ///_logger.LogInformation("NPS callback raw XML: {xml}", xml);

            if (string.IsNullOrWhiteSpace(xml))
            {
                _logger.LogError("Empty XML body received.");
                return BadRequest("Empty XML request body.");
            }

            // Only remove backslashes if truly necessary – better to avoid
            xml = xml.Replace("\\", "");

            var doc = new XmlDocument { PreserveWhitespace = true };
            try
            {
                doc.LoadXml(xml);
            }
            catch (XmlException ex)
            {
                _logger.LogError(ex, "\r\n Invalid Acmt024 XML received: {xml} \r\n", xml);
                return BadRequest($"Malformed XML: {ex.Message}");
            }

            var acmt024Response = await _npsPayment.InwardAcmt024(doc);
            return Ok(acmt024Response);
        }






    }
}