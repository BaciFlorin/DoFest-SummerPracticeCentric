using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace DoFest.AutomationTests.PageObjects.Login
{
    public class LoginPage: BasePage
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }

        #region Login section
        [FindsBy(How= How.CssSelector, Using = "[type='email']")]
        public IWebElement TextEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='password']")]
        public IWebElement TextPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='button']")]
        public IWebElement ButtonLogin { get; set; }

        [FindsBy(How = How.ClassName, Using = "error-item")]
        public IWebElement ErrorMessage { get; set; }
        #endregion


        public void Login(string email, string password)
        {
            TextEmail.SendKeys(email);
            TextPassword.SendKeys(password);
            ButtonLogin.Click();
        }

    }
}
