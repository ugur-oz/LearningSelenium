using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LearningSelenium
{
    public class WorkingWithDropdown
    {
        IWebDriver Driver;

        public IWebDriver Driver1 { get => Driver; set => Driver = value; }

        [SetUp]
        public void Setup()
        {
            Driver1 = new ChromeDriver();

            Driver1.Manage().Cookies.DeleteAllCookies();
            Driver1.Manage().Window.Maximize();
            Driver1.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(60);
            Driver1.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            Driver1.Url = "https://test.qatechhub.com/form-elements";
        }
        
        [Test]
        public void VerifyContactUsFormFill()
        {
            Driver1.FindElement(By.Id("wpforms-49-field_1")).SendKeys("Saurabh");
            Driver1.FindElement(By.Name("wpforms[fields][1][last]")).SendKeys("Dhingra");
            Driver1.FindElement(By.Id("wpforms-49-field_2")).SendKeys("Saurabh@qatechhub.com");
            Driver1.FindElement(By.Id("wpforms-49-field_4")).SendKeys("9560666952");
            Driver1.FindElement(By.XPath("//input[@value = 'Female']")).Click();

            IWebElement dropdown = Driver1.FindElement(By.Name("wpforms[fields][5]"));

            SelectElement select = new SelectElement(dropdown);

            select.SelectByText("Selenium");
    
            Driver1.FindElement(By.Name("wpforms[submit]")).Click();

        
        }

        [TearDown]
        public void TearDown()

        {
            Driver1.Quit();
        }
    }
}