using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowSelenium.Configuration;
using SpecFlowSelenium.PageObjects.BBC.News;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    class BBCNewsSteps
    {
        readonly DriverConfiguration config;
        readonly IWebDriver driver;
        readonly NewsHomePage newsHome;

        public BBCNewsSteps(DriverConfiguration configuration)
        {
            config = configuration;
            driver = configuration.WebDriver;
            newsHome = new NewsHomePage(driver);
        }

        [When(@"i click news menu ""(.*)""")]
        public void iCheckNewsFor(string menuItem)
        {
            newsHome.ClickMenuItem(menuItem);
        }

        [Then(@"i see stories for ""(.*)""")]
        public void iSeeStoriesFor(string input)
        {
            newsHome.GetCSectionLinkText(input).Should().Contain(input);
        }
    }
}
