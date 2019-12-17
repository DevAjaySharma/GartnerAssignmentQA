using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUIAutomationSetup.POM
{
    public class CodepenPageObject
    {
        protected IWebDriver driver;
        protected string baseUrl = @"C:\Users\10283377\Desktop\abc.html"; //"https://codepen.io/bmikhayl/pen/MWWMMWo";
        public IWebDriver Driver { get; set; }


        public CodepenPageObject()
        {
            Setup();
        }

        public ReviewModel ReadReviewFromUI()
        {
            ReviewModel reviewData = new ReviewModel();
            var row = driver.FindElements(By.XPath("//div[@class='table_row']")).FirstOrDefault();
            string[] cellsData = row.Text.Split('\n');
            for (int i = 0; i < cellsData.Count();)
            {
                if (cellsData[i].TrimEnd('\r') == "Review Text")
                {
                    reviewData.Text = cellsData[i + 1].TrimEnd('\r');
                }
                else if (cellsData[i].TrimEnd('\r') == "Review Rating")
                {
                    reviewData.Rating = Convert.ToInt32(cellsData[i + 1].TrimEnd('\r'));
                }
                else if (cellsData[i].TrimEnd('\r') == "Review Language")
                {
                    reviewData.Language = cellsData[i + 1].TrimEnd('\r');
                }
                else if (cellsData[i].TrimEnd('\r') == "Is a Duplicate")
                {
                    reviewData.IsDuplicate = (cellsData[i + 1].TrimEnd('\r') == "YES") ? true : false;
                }

                i = i + 2;
            }
            return reviewData;
        }

        public void Setup()
        {
            // Set WebDriver based on browerName parameter 
            driver = new ChromeDriver(@"C:\tools\selenium");
            driver.Manage().Window.Maximize();// Set window to full screen 
            driver.Manage().Cookies.DeleteAllCookies();// Clear all cookies 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = baseUrl;
            Driver = driver;
        }

    }
}
