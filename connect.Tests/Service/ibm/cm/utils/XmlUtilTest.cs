using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using connect.Service.ibm.cm.utils;
using connect.CMWebService;
using System.Xml;
using System.IO;
using System.Reflection;

namespace connect.Tests.Service.ibm.cm.utils
{
    [TestClass]
    public class XmlUtilTest
    {
        //[TestMethod]
        //public void TestCreateItem()
        //{
        //   XmlElement item =  XmlUtil.createItem("HRRules");
        //   Assert.IsNotNull(item);
        //}

        [TestMethod]
        public void TestSetupAttachments()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
   //         byte[] pdf = XmlUtil.ReadAllBytes(dir + "\\TestData\\sample-doc.pdf");
   //         MTOMAttachment[] mTomAttchement = XmlUtil.setupAttachments(pdf);
    //        Assert.IsNotNull(mTomAttchement);
        }

    }
}
