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
   public class SellPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SellPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [FindsBy(How = How.LinkText, Using = "News")]
        private IWebElement newsPageTab;

        [FindsBy(How = How.CssSelector, Using = "a.desktop-nav__dropdown-item-link[href*='news']")]
        private IWebElement newsPageFirstOption;


        public NewsPage goToNewsPage()
        {
            newsPageTab.Click();
            newsPageFirstOption.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return new NewsPage(driver);
        }
    }
}
