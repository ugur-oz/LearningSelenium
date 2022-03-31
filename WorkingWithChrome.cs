using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LearningSelenium
{
public class NewBaseType
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
        Driver.Url = "https://test.qatechhub.com";

    }
    [Test]
    public void VerifyTitleOfThePage() {

        string expectedTitle = "Test QA Tech Hub – Learning By Doing is the best way to learn!";

        string actualTitle = Driver.Title;

        Assert.AreEqual(expectedTitle,actualTitle);

     }

    [TearDown]
    public void TearDown()

    {
        Driver.Quit();
    }

  
}


}