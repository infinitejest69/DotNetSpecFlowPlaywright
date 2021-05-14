//using FluentAssertions;
//using OpenQA.Selenium;
//using SpecFlowSelenium.Configuration;
//using SpecFlowSelenium.PageObjects.BBC.iPlayer;
//using System;
//using TechTalk.SpecFlow;

//namespace SpecFlowSelenium.Steps
//{
//    [Binding]
//    class BBCIPlayerSteps
//    {
//        readonly DriverConfiguration config;
//        readonly IWebDriver driver;
//        readonly IPlayerHomePage iPlayerHomePage;

//        public BBCIPlayerSteps(DriverConfiguration configuration)
//        {
//            config = configuration;
//            driver = configuration.WebDriver;
//            iPlayerHomePage = new IPlayerHomePage(driver);
//        }

//        [When(@"i click tv guide")]
//        public void WhenIClickTvGuide()
//        {
//            iPlayerHomePage.ClickMenuTVGuide();
//        }

//        [When(@"i click channel ""(.*)""")]
//        public void WhenIClickChannel(string p0)
//        {
//            iPlayerHomePage.ClickChanelLogo(p0);
//        }

//        [Then(@"i see todays Tv Guide")]
//        public void ThenISeeTodaysTvGuide()
//        {
//            var day = DateTime.Now.Day.ToString();
//            iPlayerHomePage.GetIPLayerTodaysDate().Should().Contain(day);
//        }
//    }
//}
