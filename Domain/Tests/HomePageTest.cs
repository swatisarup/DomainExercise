using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Pages;
using Domain.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;

namespace Domain.Tests
{
    [TestFixture]
    public class HomepageTest : TestBase
    {
        internal static IWebDriver driver;
        ExtentTest test;
        //   private static ReportingTasks _reportingTasks;

        [SetUp]
        public void SetUp()
        {
            test = _reportingTasks.InitializeTest("Testing different tabs of Domain Home Page");
            BrowserFactory.InitBrowser(ConfigurationManager.AppSettings["Browser Name"]);
            driver = BrowserFactory.Driver;

        }

        [Test]
        public void TestNavigationOfHomePageTabs()
        {
            HomePage home = new HomePage(driver);
            home.goToPage();
            Assert.IsNotNull(home);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/");
            test.Log(LogStatus.Pass, "Home Page Loaded successfully");

            RentPage rentPage = home.goToRentPage();
            Assert.IsNotNull(rentPage);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/?mode=rent");
            test.Log(LogStatus.Pass, "Rent Page Loaded successfully");



            NewHomesPage newHomesPage = rentPage.goToNewHomesPage();
            Assert.IsNotNull(newHomesPage);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/new-homes");
            test.Log(LogStatus.Pass, "New Homes Page Loaded successfully");

            SoldPage soldPage = newHomesPage.goToSoldPage();
            Assert.IsNotNull(soldPage);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/?mode=sold");
            test.Log(LogStatus.Pass, "Sold Page Loaded successfully");


            CommercialPage commercialPage = soldPage.goToCommercialPage();
            Assert.IsNotNull(commercialPage);
            Assert.AreEqual(driver.Url, "https://www.commercialrealestate.com.au/");
            test.Log(LogStatus.Pass, "Commercial Page Loaded successfully");

            home = commercialPage.goBackToDomainPage();
            Assert.IsNotNull(home);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/");
            test.Log(LogStatus.Pass, "Home Page ReLoaded successfully");

            SellPage sellPage = home.goToSellPage();
            Assert.IsNotNull(sellPage);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/sell?hp=1");
            test.Log(LogStatus.Pass, "Sell Page Loaded successfully");

            NewsPage newsPage = sellPage.goToNewsPage();
            Assert.IsNotNull(newsPage);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/news/");
            test.Log(LogStatus.Pass, "News Page Loaded successfully");


            AgentsPage agentsPage = newsPage.goToAgentsPage();
            Assert.IsNotNull(agentsPage);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/real-estate-agents/");
            test.Log(LogStatus.Pass, "Agents Page Loaded successfully");


            MorePage morePage = agentsPage.goToMorePage();
            Assert.IsNotNull(morePage);
            Assert.AreEqual(driver.Url, "https://www.domain.com.au/home?mode=share");
            test.Log(LogStatus.Pass, "More Page Loaded successfully");


            IWebElement savedTab = morePage.goToSavedSearchesPage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsNotNull(savedTab);
            test.Log(LogStatus.Pass, "Saved Searches Page Loaded successfully");


            IWebElement shortListTab = morePage.goToShortListpropertyPage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsNotNull(shortListTab);
            test.Log(LogStatus.Pass, "Shortlist Property Page Loaded successfully");


            SignInPage signInPage = morePage.goTosignInPageTab();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.IsNotNull(signInPage);
            Assert.IsTrue(driver.Url.Contains("https://auth.domain.com.au/v1/login?signin"));
            signInPage.goBack();
            test.Log(LogStatus.Pass, "SignIn Page Loaded successfully");


            SignUpPage signUpPage = morePage.goTosignUpPageTab();
            Assert.IsNotNull(signUpPage);
            Assert.IsTrue(driver.Url.Contains("https://auth.domain.com.au/v1/signup?signin"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            test.Log(LogStatus.Pass, "SignUp Page Loaded successfully");

        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                // _reportingTasks.FinalizeTest();
                // driver.Manage().Cookies.DeleteAllCookies();
                BrowserFactory.CloseAllDrivers();
                _reportingTasks.FinalizeTest();
            }
        }

    }
}
