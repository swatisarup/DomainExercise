using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pages
{
    public class CommercialPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CommercialPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [FindsBy(How = How.LinkText, Using = "Domain")]
        private IWebElement backtoDomainTab;
        public HomePage goBackToDomainPage()
        {
            backtoDomainTab.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return new HomePage(driver);
        }
    }
}
