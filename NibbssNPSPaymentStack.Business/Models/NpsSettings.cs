using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models
{
    public class NpsSettings
    {
        public string? BaseUrl {  get; set; }
        public string? BaseUrl2 { get; set; }
        public string? ClientId { get; set; }
        public string TokenBaseUrl { get; set; }
        public string? ClientSecret { get; set; }
        public string? AcmtUrl { get; set; }
        public string? Acmt023Url { get; set; }
        public string? Acmt024Url { get; set; }
        public string? PacsUrl { get; set; }
        public string? PainUrl { get; set; }
        public string? CamtUrl { get; set; }
        public string? GetParticipant {  get; set; }
        public string? InstitutionCode { get; set; }
        public string? privateKeyPath {  get; set; }
        
        public string? publicKeyPath {  get; set; }

        public string?  Pacs024InwardPath { get; set; }
        public string? Acmt023Inwardpath { get; set; }
        public string? Acmt024inwardPath { get; set; }
        public string? Pacs008Inwardpath { get; set; }
        public string? Pacs002Inwardpath { get; set; }
        public string? Pacs028InwardPath { get; set; }

        public string? Pain008InwardPath { get; set; }
        
        public string? Pain009InwardPath { get; set; }
        public string? Pain010InwardPath { get; set; }
        public string? Pain011InwardPath { get; set; }
        public string? Pain012InwardPath { get; set; }
        public string? Pain001Url {  get; set; }
        public string? Pain002Url { get; set; }
        public string? Pain008Url { get; set; }
        public string? Pacs003InwardPath { get; set; }
        public string? Pain013inwardPath { get; set; }
        public string? Pain014InwardPath { get; set; }

        public string? Pain001InwardPath { get; set; }
        public string? Pain002InwardPath { get; set; }
        public string? Camt060inwardPath { get; set; }

        public string? Camt052InwardPath { get; set; }
        public string? Camt053InwardPath { get; set; }



        public string? Acmt023Path { get; set; }
        public string? Acmt024Path { get; set; }
        public string? Pacs008Path { get; set; }
        public string? Pacs001Path {  get; set; }
        public string? Pacs002Path {  get; set; }
        public string? Pacs028Path {  get; set; }

      

        public string? Pain001Path { get; set; }
        public string? Pain002Path { get; set; }
        public string? Pain008Path { get; set; }
        public string? Pain009Path { get; set; }
        public string? Pain010Path {  get; set; }
        public string? Pain011Path {  get; set; }
        public string? Pain012Path { get; set; }

        public string? Pacs003Path {  get; set; }
        public  string? Pain013Path { get; set; }
        public string? Pain014Path { get; set; }
    
        public string? Camt060Path { get; set; }
        public string? Camt052Path { get; set; }
        public string? Camt053Path { get; set; }

        public string? Camt060EncrypPath { get; set; }
        public string? Camt052EncrypPath { get; set; }
        public string? Camt053EncrypPath { get; set; }
        public string? Pacs008EncrypPath { get; set; }
        public string?  Pacs002EncrypPath { get; set; }
        public string? Pacs001EncrypPath { get; set; }
        public string? Pain008EncrypPath { get; set; }
        public string? Pain001EncrypPath { get; set; }
        public string? Pain002EncrypPath { get; set; }
        public string? Pain009EncrypPath { get; set; }
        public string?  Pain011EncrypPath { get; set; }
        public string?  Pain010EncrypPath { get; set; }
        public string? Pacs003EncrypPath { get; set; }
      
        public string? Pain013EncrypPath { get; set; }
        public string? Pain012EncrypPath { get; set; }

        public string? Pain014EncrypPath { get; set; }  

        public string? Acmt023EncrypPath { get; set; }
        public string? Pacs028EncrypPath { get; set; }
        public string? Pacs002EncryPath { get; set; }
        public string? Acmt024EncrypPath { get; set; }
        public string? Acmt02EncrypPath { get; set; }


        public string? EncryptDataPath {  get; set; }
      
        public string? InwardFilePath { get; set; }
     
    }
}
