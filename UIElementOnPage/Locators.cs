using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UIElementOnPage
{
    public class Locators
    {
        IWebDriver driver;

        [SetUp]
        public void SetupBrowser()
        {
            DriverManager driverManager = new DriverManager();
            driverManager.SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();  

            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void LocatorIdentification()
        {
            // 1. Selenium Locators to identify UI Elements on the Page.
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacadmey");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.Name("password")).SendKeys("123456");

            // CSS and Xpath are not exactly an attribute.
            // they are baically queries which can be called to target specific elements. 
            // for css: tagname[attribute='value']
            // driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            // Xpath : traversre from parent to grand child
            driver.FindElement(By.XPath("//div[@class='form-group']/label/span/input")).Click();

            // for Xpath: //tagname[@attribute='value']
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            // 2. Returning WebElements and their attributes for functional valdiations

            Thread.Sleep(3000);
            string errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            // Example of an LinkText and its validation
            // Test Case: Validate the url of the text
            string urlText = "Free Access to InterviewQues/ResumeAssistance/Material";
            IWebElement urlLinkText = driver.FindElement(By.LinkText(urlText));
            string actualUrlAddress = urlLinkText.GetAttribute("href");
            string expectedUrlAddress = "https://rahulshettyacademy.com/#/documents-request";

            // 3. Nunit Assertions to validate the Test Scenarios & Advanced location strategies

            Assert.AreEqual(expectedUrlAddress, actualUrlAddress);

            // to handle checkbox 


        }
    }
}