//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.PageObjects;
//using SpecFlowSelenium.Configuration;
//using System;
//using System.Threading;

//namespace SpecFlowSelenium.PageObjects.BBC.Weather
//{
//    public class WeatherHomePage
//    {
//        private readonly IWebDriver Driver;
//        private readonly IWait<IWebDriver> wait;
//        public string PageUrl { get; } = "https://www.bbc.co.uk/weather";

//        [FindsBy(How = How.Id, Using = "ls-c-search__input-label")]
//        public IWebElement locationSearchBar { get; set; }

//        [FindsBy(How = How.XPath, Using = ".//input[@type='submit']")]
//        public IWebElement submitLocationButton { get; set; }

//        [FindsBy(How = How.XPath, Using = ".//*[@id='wr-location-name-id']")]
//        public IWebElement locationTitle { get; set; }

//        public WeatherHomePage(DriverConfiguration configuration)
//        {
//            if (configuration == null)
//                throw new ArgumentNullException(nameof(configuration));

//            Driver = configuration.WebDriver;
//            wait = configuration.Wait;

//            PageFactory.InitElements(Driver, this);
//        }

//        public void inputLocation(string location)
//        {
//            locationSearchBar.SendKeys(location);
//        }

//        public void clickSubmit()
//        {
//            submitLocationButton.Click();
//        }

//        public String getLocationText()
//        {
//            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='wr-location-name-id']")));
//            //var x = locationTitle.Text;
//            return locationTitle.Text;
//        }
//    }
//}
