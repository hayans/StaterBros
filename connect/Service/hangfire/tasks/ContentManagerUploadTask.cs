using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocuSign.Connect;
using connect.Service.docusign;
using DocuSign.eSign.Model;
using connect.Service.docusign.utils;
using System.ComponentModel;
using System.IO;
//using connect.Models.documentum;
//using connect.Service.documentum;
using log4net;
using connect.Service.ibm.cm;
using connect.CMWebService;
using connect.Service.ibm.cm.utils;
using System.Configuration;

namespace connect.Service.hangfire.tasks
{
    public static class ContentManagerUploadTask
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ContentManagerUploadTask));

        [DisplayName("Uploading document {3} for envelope {2}")]
        public static void uploadDocument(IDictionary<string, string> localParams, string envelopeId, string documentId, DocumentOptions options)
        {
            Log.Info("Env :: " + localParams[EnvelopeMetaFields.Environment] + " - Acc ID :: " +
                localParams[EnvelopeMetaFields.AccountId] + " - Env ID :: " +
                envelopeId + " - Doc ID :: " +
                documentId + " - Option :: " +
                options);

            string[] docParams = localParams[EnvelopeMetaFields.TemplateName].Split(':');
            string documentClass = docParams[0];
            string documentType = docParams[1];

            Log.Info("documentClass :: " + documentClass);
            Log.Info("documentType :: " + documentType);
            //Now retrieve the documents for the given envelope from the accountId hosted in environment as combined
            MemoryStream docStream = DocuSignService.GetDocument(localParams[EnvelopeMetaFields.Environment],
                localParams[EnvelopeMetaFields.AccountId],
                envelopeId,
                documentId,
                options);


            // Now upload the bytes for the document that we just retrieved in cm
            byte[] buffer = ServiceUtil.ReadFully(docStream);
       
            string exFolderUri = exFolderUri = ConfigurationManager.AppSettings["exFolderName"];
            AuthenticationData authData = CMWebServiceClient.setupAuthData();
            MTOMAttachment[] mtomAttachment = CMWebServiceClient.setupAttachments(new string[,] { { "doc", "application/pdf" } }, buffer);
            string itemUri = CMWebServiceClient.createItem(authData, mtomAttachment, documentClass, documentType, localParams[EnvelopeMetaFields.EID], localParams[EnvelopeMetaFields.FirstName], localParams[EnvelopeMetaFields.LastName]);
            string folderUri = CMWebServiceClient.getFolderUri(authData, localParams[EnvelopeMetaFields.EID]);
            if (folderUri != null) { CMWebServiceClient.addItemToFolder(authData, folderUri, itemUri); }
            else { CMWebServiceClient.addItemToFolder(authData, exFolderUri, itemUri); } 
        }
    }
}