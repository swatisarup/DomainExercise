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
    public class SignInPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public void goBack()
        {
            driver.Navigate().Back();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
    }
}
