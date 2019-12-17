using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUIAutomationSetup;
using WebUIAutomationSetup.API;
using WebUIAutomationSetup.POM;

namespace WebUIUnitTests
{
    [TestClass]
    public class TestCodepenUI
    {

        CodepenPageObject codepenPageObject;

        [TestInitialize]
        public void BrowserSetup()
        {
            codepenPageObject = new CodepenPageObject();

        }

        [TestMethod]
        public void SubmitReviewAndVerifyFromUI()
        {
            //Arrange

            ReviewModel newReviews = new ReviewModel()
            {
                Language = "EN",
                Text = "Great Product!",
                Rating = 5,
                IsDuplicate = false
            };

            //Act

            //Hit API with Review details to submit into system.
            PartnersAPI.SubmitReviewToPlatform(newReviews);

            //Read the latest review submit on the system.
            var submittedReview = codepenPageObject.ReadReviewFromUI();


            //Assert
            Assert.AreEqual(newReviews, submittedReview);

        }
    }
}
