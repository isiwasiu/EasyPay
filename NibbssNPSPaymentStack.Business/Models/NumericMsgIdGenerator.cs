using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NPOI.OpenXmlFormats.Dml;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace NibbssNPSPaymentStack.Business.Models
{
    public class NumericMsgIdGenerator
    {
        private readonly IHttpClientFactory httpClientFactory;
        public GeolocationApi GeolocationApi;

        public NumericMsgIdGenerator(IHttpClientFactory httpClientFactory,
            IOptions<GeolocationApi> options)
        {
            this.httpClientFactory = httpClientFactory;
            GeolocationApi= options.Value;
        }

        private static readonly Random _random = new Random();

        public static void WriteToFile(string Path,string content)
        {
            File.WriteAllText(Path,content);
        }

        public static string GenerateInstrId(string sourceInstitution, string destinationInstitution)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"); 
            int value = RandomNumberGenerator.GetInt32(100000000, 1000000000);
            return sourceInstitution+ destinationInstitution+timestamp+value.ToString();
        }

        //public static string GenerateMandateID()
        //{
        //    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

        //    Random random = new Random();
        //    long min = 1000L;// smallest 14-digit number
        //    long max = 9999L; // largest 14-digit number

        //    long random14DigitNumber = min + (long)(random.NextDouble() * (max - min));

        //    // 17 random digits
        //    string randomPart = random14DigitNumber
        //                               .ToString();

        //    return timestamp + randomPart;
        //}


        public static string generateEndToEndId(string sourceInstitutionId)
        {
            StringBuilder result = new StringBuilder(29);

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[1];

                // First digit (1–9) to avoid leading zero
                do
                {
                    rng.GetBytes(buffer);
                }
                while (buffer[0] > 249); // remove modulo bias

                result.Append((buffer[0] % 9) + 1);

                // Remaining 28 digits (0–9)
                for (int i = 1; i < 29; i++)
                {
                    do
                    {
                        rng.GetBytes(buffer);
                    }
                    while (buffer[0] > 249);

                    result.Append(buffer[0] % 10);
                }
            }

            return sourceInstitutionId+result.ToString();
        }
        public static string Generate(string institutionId)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            Random random = new Random();
            long min = 100000000000000L; // smallest 14-digit number
            long max = 999999999999999L; // largest 14-digit number

            long random14DigitNumber = min + (long)(random.NextDouble() * (max - min));

            // 17 random digits
            string randomPart = random14DigitNumber.ToString();

            return institutionId + timestamp + randomPart;
        }

        public static string SerficeRef(string institutionId, string requestinstiti)
        {
            string serviceref = "";
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");


            Random random = new Random();
            long min = 100000000L; // smallest 14-digit number
            long max = 999999999L; // largest 14-digit number

            long random9DigitNumber = min + (long)(random.NextDouble() * (max - min));

            // 17 random digits
            string randomPart = institutionId + requestinstiti +timestamp +  random9DigitNumber.ToString();

            return randomPart ;
        }

        public static string GenerateIso8061()
        {
            string isoTime = DateTime.Now.ToString("yyyy-MM-dd");
            return isoTime;
        }

        public static DateTime GenerateDateTimeIso8061()
        {
            string isoTime = DateTime.Now.ToString("yyyy-MM-dd");
            return DateTime.Parse(isoTime);
        }

        public static DateTime FormatDateTimeToIsoUtc()
        {
            string getdate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
            return DateTime.Parse(getdate);
        }

      
        public static DateTime GetIsoTime()
        {
            string isoTime = DateTimeOffset.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz");
            //DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff");
            DateTime dateTime = DateTime.Parse(isoTime);
            ////return dateTimeOffset.DateTime;

            //string isoTime = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            //return DateTime.Parse(isoTime);
            return dateTime;
        }

     
        public static DateTime formatDateMandate(DateTime mandatedate)
        {
            string isoTime = mandatedate.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
       
            //DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff");ss
            DateTime dateTime = DateTime.Parse(isoTime);
            ////return dateTimeOffset.DateTime;

            //string isoTime = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            //return DateTime.Parse(isoTime);
            return dateTime;
        }

        public string ConvertToDms(double coordinate, bool isLatitude)
        {
            var direction = coordinate >= 0
                ? (isLatitude ? "N" : "E")
                : (isLatitude ? "S" : "W");

            coordinate = Math.Abs(coordinate);

            int degrees = (int)coordinate;
            double minutesFull = (coordinate - degrees) * 60;
            int minutes = (int)minutesFull;
            double seconds = (minutesFull - minutes) * 60;

            if (isLatitude)
            {
                return $"{degrees:00}{minutes:00}{seconds:00.00000}{direction}";
            }
            else
            {
                return $"{degrees:000}{minutes:00}{seconds:00.00000}{direction}";
            }
        }

        public async Task<GeolocationApiResponse> GetLocation(string ip)
        {
            var geoResponse = new GeolocationApiResponse();
            string url = GeolocationApi.Url + $"/{ip}";
            var httpRequstMessage = new HttpRequestMessage(HttpMethod.Get,url);
            var httpClient = httpClientFactory.CreateClient();
            var response = await httpClient.SendAsync(httpRequstMessage);

            if (!response.IsSuccessStatusCode)
            {
                var failedResponseStream = await response.Content.ReadAsStringAsync();
                geoResponse = JsonSerializer.Deserialize<GeolocationApiResponse>(failedResponseStream);

                return geoResponse!;

            }

            var responseStream = await response.Content.ReadAsStringAsync();
            geoResponse = JsonSerializer.Deserialize<GeolocationApiResponse>(responseStream);

            return geoResponse!;
        }

        public string FormatLocation(double latitude, double longitude)
        {
            string lat = ConvertToDms(latitude, true);
            string lon = ConvertToDms(longitude, false);

            return $"{lat}{lon}";
        }
    }
}
