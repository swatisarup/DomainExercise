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
   public class SoldPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SoldPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        [FindsBy(How = How.XPath, Using = "//ul[@class= 'desktop-nav__list']//a[@data-reactid='58']")]
        private IWebElement commercialPageTab;

        public CommercialPage goToCommercialPage()
        {
            commercialPageTab.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return new CommercialPage(driver);
        }

    }
}
