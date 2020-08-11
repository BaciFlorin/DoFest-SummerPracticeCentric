using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace DoFest.AutomationTests.PageObjects.Dashboard
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.ClassName, Using = "container")]
        public IWebElement ContainerDashboard { get; set; }
    }
}
