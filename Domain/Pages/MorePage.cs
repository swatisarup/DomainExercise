using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Pages
{
    public class MorePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MorePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [FindsBy(How = How.CssSelector, Using = "div.member-dropdown[data-reactid='69']>button.member-dropdown__toggle-savedsearch")]
        private IWebElement savedSearchesPageTab;

        [FindsBy(How = How.CssSelector, Using = "div.member-dropdown>button.member-dropdown__toggle-shortlist")]
        private IWebElement shortListpropertyPageTab;

        [FindsBy(How = How.CssSelector, Using = "div.header-member__sign-in-container>button.header-member__sign-in")]
        private IWebElement signInPageTab;

        [FindsBy(How = How.CssSelector, Using = "div.header-member__sign-in-container>button[data-reactid='78']")]
        private IWebElement signUpPageTab;


        public IWebElement goToSavedSearchesPage()
        {
            savedSearchesPageTab.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return savedSearchesPageTab;
        }

        public IWebElement goToShortListpropertyPage()
        {
            shortListpropertyPageTab.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return shortListpropertyPageTab;

        }

        public SignInPage goTosignInPageTab()
        {
            signInPageTab.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return new SignInPage(driver);

        }

        public SignUpPage goTosignUpPageTab()
        {
            signUpPageTab.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
           wait.Until(driver=>driver.Url.Contains("https://auth.domain.com.au/v1/signup?signin"));
            return new SignUpPage(driver);

        }
    }
}
