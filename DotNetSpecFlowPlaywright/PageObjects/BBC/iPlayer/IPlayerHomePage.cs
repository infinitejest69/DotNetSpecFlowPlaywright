using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace SpecFlowSelenium.PageObjects.BBC.iPlayer
{
    class IPlayerHomePage
    {
        private readonly IWebDriver Driver;
        public string PageUrl { get; } = "https://www.bbc.co.uk/iplayer";
        private string ChannelIconstring { get; } = ".//*[@href='#iplayer-icon-replace-active']";

        [FindsBy(How = How.XPath, Using = ".//*[@aria-label='TV Guide']/span")]
        [CacheLookup]
        public IWebElement MenuTVGuide { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@aria-label='A to Z']/span")]
        [CacheLookup]
        public IWebElement MenuAToZ { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='day-switcher__item__day typo--bold'][contains(text(),'Today')]/../div[2]")]
        [CacheLookup]
        public IWebElement TodaysDate { get; set; }

        public IPlayerHomePage(IWebDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(Driver, this);
        }

        public void ClickChanelLogo(string ChannelName)
        {
            string channel = ChannelName.ToLower().Replace(" ", "");
            Driver.FindElement(By.XPath(ChannelIconstring.Replace("replace", channel))).Click();
        }

        public void ClickMenuA2Z()
        {
            MenuAToZ.Click();
        }

        public void ClickMenuTVGuide()
        {
            MenuTVGuide.Click();
        }

        public string GetIPLayerTodaysDate()
        {
            return TodaysDate.Text;
        }

        public string GetPageUrl()
        {
            return Driver.Url;
        }

        public string getPageTitle()
        {
            return Driver.Title;
        }
    }
}
