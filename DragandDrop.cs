using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace LearningSelenium
{
    public class DragAndDrop
    {
        IWebDriver Driver;

        public IWebDriver Driver1 { get => Driver; set => Driver = value; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();

            Driver1.Manage().Cookies.DeleteAllCookies();
            Driver1.Manage().Window.Maximize();
            Driver1.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(60);
            Driver1.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            Driver1.Url = "https://test.qatechhub.com/drag-and-drop/";
        }
        
        [Test]
        public void VerifyDragAndDrop()
        {
        
        Actions action = new Actions(Driver);

        IWebElement source = Driver.FindElement(By.Id("draggable"));

        IWebElement target = Driver.FindElement(By.Id("droppable"));

        string colorBeforeDragAndDrop = target.GetCssValue("color");

        action.DragAndDrop(source, target).Perform();

        string colorAfterDragAndDrop = target.GetCssValue("color");

        Assert.AreNotEqual(colorAfterDragAndDrop, colorBeforeDragAndDrop);
        
        }

        [TearDown]
        public void TearDown()

        {
            Driver1.Quit();
        }
    }
}
