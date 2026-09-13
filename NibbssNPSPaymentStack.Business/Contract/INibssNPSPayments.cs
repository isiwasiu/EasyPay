using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.acmt024;
using NibbssNPSPaymentStack.Business.Models.Camt060;
using NibbssNPSPaymentStack.Business.Models.GetPartipants;
using NibbssNPSPaymentStack.Business.Models.Pacs002;
using NibbssNPSPaymentStack.Business.Models.Pacs002.NibbssNPSPaymentStack.Business.Models.Pacs002;
using NibbssNPSPaymentStack.Business.Models.Pacs003;
using NibbssNPSPaymentStack.Business.Models.Pacs008;
using NibbssNPSPaymentStack.Business.Models.Pacs028;
using NibbssNPSPaymentStack.Business.Models.Pain001;
using NibbssNPSPaymentStack.Business.Models.Pain002;
using NibbssNPSPaymentStack.Business.Models.Pain008;
using NibbssNPSPaymentStack.Business.Models.Pain009;
using NibbssNPSPaymentStack.Business.Models.Pain010;
using NibbssNPSPaymentStack.Business.Models.pain011;
using NibbssNPSPaymentStack.Business.Models.Pain012;
using NibbssNPSPaymentStack.Business.Models.Pain013;
using NibbssNPSPaymentStack.Business.Models.Pain014;
using NibbssNPSPaymentStack.Business.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Microsoft.AspNetCore.Mvc;
using NibbssNPSPaymentStack.Business.Models;
using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.acmt024;
using NibbssNPSPaymentStack.Business.Models.Camt060;
using NibbssNPSPaymentStack.Business.Models.GetPartipants;
using NibbssNPSPaymentStack.Business.Models.Pacs002;
using NibbssNPSPaymentStack.Business.Models.Pacs002.NibbssNPSPaymentStack.Business.Models.Pacs002;
using NibbssNPSPaymentStack.Business.Models.Pacs003;
using NibbssNPSPaymentStack.Business.Models.Pacs008;
using NibbssNPSPaymentStack.Business.Models.Pacs028;
using NibbssNPSPaymentStack.Business.Models.Pain001;
using NibbssNPSPaymentStack.Business.Models.Pain002;
using NibbssNPSPaymentStack.Business.Models.Pain008;
using NibbssNPSPaymentStack.Business.Models.Pain009;
using NibbssNPSPaymentStack.Business.Models.Pain010;
using NibbssNPSPaymentStack.Business.Models.pain011;
using NibbssNPSPaymentStack.Business.Models.Pain012;
using NibbssNPSPaymentStack.Business.Models.Pain013;
using NibbssNPSPaymentStack.Business.Models.Pain014;
using NibbssNPSPaymentStack.Business.Models.Response;
using System.Security.Cryptography;
using System.Xml;

namespace NibbssNPSPaymentStack.Business.Contract
{
    public interface INibssNPSPayments
    {
        Task<CustomResult<Camt060Response>> InwardCamt060(XmlDocument doc);
        Task<CustomResult<Pacs002Response>> InwardPacs003(XmlDocument doc);
        Task<CustomResult<Pain002Response>> InwardPain001(XmlDocument doc);
        Task<CustomResult<Pain014Response>> InwardPain013(XmlDocument doc);
        Task InwardPain002(XmlDocument doc);
        Task InwardPain014(XmlDocument doc);
        Task<CustomResult<Camt060Response>> ProcessCamt060(Camt060Request payload);
        Task<CustomResult<Pain001Response>> ProcessPain001(Pain001Request payload);
        Task<CustomResult<Pain008Response>> ProcessPain008(Pain008Request payload);



        Task<CustomResult<Pain013Response>> ProcessPain013(Pain013Request payload);
        Task<CustomResult<Pacs003Response>> ProcessPacs003(Pacs003Request payloadRequest);
        Task<CustomResult<Pain011Response>> ProcessPain011(pain011Request payloadRequest);
        Task InwardPain012(XmlDocument doc);
        Task<CustomResult<Pain012Response>> InwardPain010(XmlDocument doc);
        Task<CustomResult<Pain012Response>> InwardPain011(XmlDocument doc);
        Task<CustomResult<Pain012Response>> InwardPain009(XmlDocument doc);
        Task<CustomResult<Pain010Response>> ProcessPain010(Pain010Request payload);
        Task<CustomResult<Pain009Response>> ProcessPain009(Pain009Request payloadRequest);
        Pain009Document RegeneratePain009(Pain009Request payload);
        Task<CustomResult<GetAccountDetailsByMessageIdViewModel>> GetAccountVerificationByMessageId(string MessageId);
        Task<CustomResult<IEnumerable<GetAccountVerificationViewModel>>> GetAccountVerification(int pageIndex, int pageSize);
        Task<string> InwardAcmt023(XmlDocument doc);
        Task<CustomResult<Pacs002Response>> ProcessInwardPacs002(XmlDocument doc);
        Task<CustomResult<Pacs002Response>> ProcessInwardPacs008(XmlDocument doc);
        Task<CustomResult<Acmt024Response>> ProcessInwardAcmt023(XmlDocument doc);
        Task<CustomResult<Acmt024Response>> ProcessInwardAcmt024(XmlDocument doc);
        Task<CustomResult<Pacs028Response>> ProcessPacs028(Pacs028Request payload);
        Task<CustomResult<Pacs002Response>> Processpacs002(CreditTransferStatusReport payload);
        Task<CustomResult<List<ParticipantViewModel>>> GetParticipant();
        void DebugSignature(XmlDocument doc, RSA publicKey);
        Task<CustomResult<Acmt024Response>> InwardAcmt024(XmlDocument doc);
        Task<CustomResult<Acmt024Response>> ProcessAcmt024(AccountVerificationStatusRequest accountVerificationRequest);
        void GenerateKey();
        string SerializePayload<T>(T payload, string nameSpace);
        bool ValidateXmlSignature(XmlDocument doc, RSA publicKey);
        string EncryptContent(XmlDocument signedDoc, string xpath, string NameSpace);
        XmlDocument ConvertXmlToDoc(string xml);
        XmlNode ConvertXmlToNode(string xml);
        T DeserializePayload<T>(string xmlString);
        void SignXmlDocument(XmlDocument doc);
        Task<CustomResult<Pacs008Response>> ProcessPacs008(CreditTransferRequest payload);
        Task<CustomResult<Acmt023Response>> ProcessAcmt023(AccountVerificationRequest accountVerificationRequest);
        string GetXPath(XmlNode node);

    }
}
