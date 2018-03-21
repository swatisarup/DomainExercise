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
   public class AgentsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AgentsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        [FindsBy(How = How.XPath, Using = "//ul[@class= 'desktop-nav__list']//a[@data-reactid='64']")]
        private IWebElement morePageTab;

        [FindsBy(How = How.XPath, Using = "//ul[@class= 'desktop-nav__list']//li[@class='desktop-nav__menu-option desktop-nav__dropdown is-active']//ul[@class='desktop-nav__dropdown-content']//li[@class='desktop-nav__dropdown-item']//a[text()='Share']")]
        private IWebElement morePageFirstOption;


        public MorePage goToMorePage()
        {
            morePageTab.Click();
            morePageFirstOption.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return new MorePage(driver);
        }
    }
}
