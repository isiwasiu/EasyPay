using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Services
{
    internal class FileUtility
    {


        public static bool WriteTextFile(string content, string filePath)
        {
            try
            {
                string? dir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);

                File.WriteAllText(filePath, content);

                string logMsg = $"Written to {filePath}";
                Console.WriteLine(logMsg);
                File.AppendAllText(Path.GetTempPath() + "FileWriteLog.txt", logMsg + Environment.NewLine);
                return true;
            }
            catch (Exception ex)
            {
                string errMsg = $"Error: {ex.Message}";
                Console.WriteLine(errMsg);
                File.AppendAllText(Path.GetTempPath() + "FileWriteLog.txt", errMsg + Environment.NewLine);
                return false;
            }
        }
    }
}
