using DoFest.AutomationTests.Helpers;
using DoFest.AutomationTests.PageObjects.Dashboard;
using DoFest.AutomationTests.PageObjects.Login;
using System;
using Xunit;

namespace DoFest.AutomationTests.Tests
{
    public class LoginTests : Browser, IDisposable
    {
        public LoginPage loginPage;
        public DashboardPage dashboardPage;

        public LoginTests(): base()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/authentication");
            loginPage = new LoginPage(Driver);
        }

        [Fact]
        public void Login_With_Valid_Credentials()
        {
            loginPage.Login("DoFestAdmin@gmail.com", "passwordAdmin");
            dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("[label='Your bucketlist']");
            Assert.True(dashboardPage.ContainerDashboard.Displayed);
        }

        [Fact]
        public void Login_With_Invalid_Credentials()
        {
            loginPage.Login("DoFestAdmin@gmail.com", "12345678");
            dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("[class='error-item']");
            Assert.True(loginPage.ErrorMessage.Displayed);
        }

        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
