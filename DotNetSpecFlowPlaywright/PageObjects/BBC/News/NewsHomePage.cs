//using OpenQA.Selenium;
//using SeleniumExtras.PageObjects;
//using System;
//using System.Collections.Generic;

//namespace SpecFlowSelenium.PageObjects.BBC.News
//{
//    class NewsHomePage
//    {
//        private readonly IWebDriver Driver;
//        public string PageUrl { get; } = "https://www.bbc.co.uk/news";
//        private readonly string MenuSearch = ".//li/a/span[contains(text(),'replace')]";

//        [FindsBy(How = How.XPath, Using = ".//li[2]/a[@class='gs-c-section-link gs-c-section-link--truncate nw-c-section-link nw-o-link nw-o-link--no-visited-state']/span")]
//        [CacheLookup]
//        public IList<IWebElement> CSectionLinkList { get; set; }

//        public NewsHomePage(IWebDriver driver)
//        {
//            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
//            PageFactory.InitElements(driver, this);
//        }

//        public string GetPageUrl()
//        {
//            return Driver.Url;
//        }

//        public List<string> GetCSectionLinkText(string input)
//        {
//            List<String> arrayList = new List<string>();
//            foreach (var clink in CSectionLinkList)
//            {
//                arrayList.Add(clink.Text);
//            }
//            return arrayList;
//        }

//        public void ClickMenuItem(string input)
//        {
//            string replace = MenuSearch.Replace("replace", input);
//            Driver.FindElement(By.XPath(replace)).Click();
//        }
//    }
//}
