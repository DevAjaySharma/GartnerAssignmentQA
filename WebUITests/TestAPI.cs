using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUIAutomationSetup;
using WebUIAutomationSetup.API;
using WebUIAutomationSetup.POM;

namespace WebUIUnitTests.API
{
    [TestClass]
    public class TestAPI 
    {

        [TestMethod]
        public void GetServeReviewToPartner200()
        {
            System.Net.Http.HttpResponseMessage response = PartnersAPI.ServeReviewToPartner();
            Assert.IsTrue(response.IsSuccessStatusCode, "Status Code is not 200");
        }

        [TestMethod]
        public void PostReviewShouldReturn200()
        {
            ReviewModel content = new ReviewModel();
            System.Net.Http.HttpResponseMessage response = PartnersAPI.SubmitReviewToPlatform(content);
            Assert.IsTrue(response.IsSuccessStatusCode, "Status Code is not 200");
        }
    }
}
