using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LearningSelenium
{
    public class WorkingWithTextbox
    {
        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();

            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(60);
            Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            Driver.Url = "https://test.qatechhub.com/contact-us";
        }
        
        [Test]
        public void VerifyContactUsFormFill()
        {
            Driver.FindElement(By.Id("wpforms-20-field_0")).SendKeys("Saurabh");
            Driver.FindElement(By.Name("wpforms[fields][0][last]")).SendKeys("Öz");
            Driver.FindElement(By.Id("wpforms-20-field_1")).SendKeys("herhangimail@gmail.com");
            Driver.FindElement(By.Id("wpforms-20-field_2")).SendKeys("Burayi iyi oku dostum ");
            Driver.FindElement(By.Name("wpforms[submit]")).Click();

            string expectedMessage = "Thanks for contacting us! We will be in touch with you shortly.";
            string actualMessage = Driver.FindElement(By.Id("wpforms-confirmation-20")).Text;
        
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TearDown]
        public void TearDown()

        {
            Driver.Quit();
        }
    }
}