using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Domain.Pages
{
   public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [FindsBy(How = How.XPath, Using = "//ul[@class= 'desktop-nav__list']//a[@data-reactid='50']")]
        private IWebElement buyPageTab;

        [FindsBy(How = How.XPath, Using = "//ul[@class= 'desktop-nav__list']//a[@data-reactid='52']")]
        private IWebElement rentPageTab;
       
        [FindsBy(How = How.XPath, Using = "//ul[@class= 'desktop-nav__list']//a[@data-reactid='61']")]
        private IWebElement sellPageTab;

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.domain.com.au");
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public void goToBuyPage()
        {
            buyPageTab.Click();
        }
        public RentPage goToRentPage()
        {
            rentPageTab.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return new RentPage(driver);
        }

        public SellPage goToSellPage()
        {
            sellPageTab.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return new SellPage(driver);
        }

    }
}
