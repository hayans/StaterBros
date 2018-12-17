using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using connect.CMWebService;
using System.Xml;
using connect.Service.ibm.cm.utils;
using System.Reflection;
using System.IO;
using connect.Service.ibm.cm;

namespace connect.Tests.Service.ibm.cm
{
    [TestClass]
    public class CMWebServiceClientTest
    {
       
        [TestMethod]
        public void TestCreateItem()
        {
            // create and set the authentication data
            AuthenticationData authData = new AuthenticationData();
            ServerDef serverDef = new ServerDef();
            serverDef.ServerName = "icmnlsdb"; // The CM server name
            authData.ServerDef = serverDef;
            AuthenticationDataLoginData loginData = new AuthenticationDataLoginData();
            loginData.UserID = "icmadmin"; // The CM server user id
            loginData.Password = "Sparklett5"; // The CM server password
            authData.LoginData = loginData;
            
            
            //create test item
      //      XmlElement item = XmlUtil.createItem("HRRules");

            //setup attachment
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    byte[] pdf = XmlUtil.ReadAllBytes(dir + "\\TestData\\sample-doc.pdf");
        //    MTOMAttachment[] mTomAttchement = XmlUtil.setupAttachments(pdf);

            CMWebServiceClient cmService = new CMWebServiceClient();
       //     string uri = cmService.createItem(authData, mTomAttchement);
        //    Assert.IsNotNull(uri);

        }
    }
}
