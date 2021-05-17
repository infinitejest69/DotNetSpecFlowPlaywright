using FluentAssertions;
using PlaywrightSharp;
using PlaywrightSharp.Chromium;
using System;
using System.Globalization;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DotNetSpecFlowPlaywright.Steps
{
    [Binding]
    internal class BBCNews_SpecFlow_PW

    {
        public IPlaywright playwright;
        public IChromiumBrowser browser;
        public IChromiumBrowserContext context;
        public IPage page;

        [BeforeFeature]
        public static async Task BeforeFeature()
        {
            await Playwright.InstallAsync();
        }

        [BeforeScenario()]
        public async Task createBrowser()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(
                headless: false
            );
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
        }

        [AfterScenario()]
        public async Task closeBrowser()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                await Helpers.Helpers.Screenshot(page);
            }
            await browser.DisposeAsync();
        }

        [Given(@"i navigate to ""(.*)""")]
        public async Task GivenINavigateTo(string p0)
        {
            await page.GoToAsync(p0);
        }

        [When(@"i click menu ""(.*)""")]
        public async Task WhenIClickNewsMenu(string p0)
        {
            await page.ClickAsync($"text={p0}");
        }

        [Then(@"i see stories for ""(.*)""")]
        public async Task ThenISeeStoriesFor(string p0)
        {
            var text = await page.GetInnerTextAsync("span:has-text(\"Edinburgh, Fife & East Scotland\")");
            text.Should().BeEquivalentTo(p0);
        }

        [Then("i see current formula 1 driver table")]
        public async Task ThenISeeCurrentFormulaDriverTable()
        {
            string expected = await page.GetInnerTextAsync("text=Lewis Hamilton");
            expected.Should().BeEquivalentTo("Lewis Hamilton");
        }

        [When(@"i input the location ""(.*)""")]
        public async Task WhenIInputTheLocation(string p0)
        {
            await page.FillAsync("[placeholder=\"Enter a town, city or UK postcode\"]", p0);

        }

        [When(@"click search")]
        public async Task WhenClickSearch()
        {
            // Press Enter
            await Task.WhenAll(
                page.PressAsync("[placeholder=\"Enter a town, city or UK postcode\"]", "Enter"));
        }

        [Then(@"i see current weather for ""(.*)""")]
        public async Task ThenISeeCurrentWeatherFor(string p0)
        {
            string expected  = await page.GetInnerTextAsync("//*[@id='wr-location-name-id']");
            expected.Should().BeEquivalentTo(p0);
        }

        [When(@"i click channel ""(.*)""")]
        public async Task WhenIClickChannel(string p0)
        {
            var selector = $"//*[@href='#iplayer-icon-{p0.ToLower().Replace(" ","")}-active']";
            await page.ClickAsync(selector);

        }

        [Then(@"i see todays Tv Guide")]
        public async Task ThenISeeTodaysTvGuide()
        {
            //Todays Date
            var date = System.DateTime.Now;
            var today = await page.GetInnerTextAsync("//*[@class='day-switcher__item__day typo--bold'][contains(text(),'Today')]/../div[2]");
            var expectedDate = date.ToString("dd");
            today.Should().BeEquivalentTo(expectedDate);


            string timeFromPageText = await page.GetInnerTextAsync("//*[@class='schedule-item schedule-item--live']/div/div[1]");
            var timeFromPage = DateTime.ParseExact(timeFromPageText, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay;
            var time = date.TimeOfDay;
            //within one hour
            timeFromPage.Should().BeCloseTo(time, 3600000);


        }

    }
}