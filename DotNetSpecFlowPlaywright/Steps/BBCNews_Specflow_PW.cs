using FluentAssertions;
using NUnit.Framework;
using PlaywrightSharp;
using PlaywrightSharp.Chromium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DotNetSpecFlowPlaywright.Steps
{
    [Binding]
    class BBCNews_SpecFlow_PW

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
            await Screenshot(page);
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
            // Click td:has-text("Lewis HamiltonLewis Hamilton")
            string expected = await page.GetInnerTextAsync("text=Lewis Hamilton");
            expected.Should().BeEquivalentTo("Lewis Hamilton");
        }


        private static async Task Screenshot(IPage page)
        {
            var date = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
            var title = await page.GetTitleAsync();
            var path = $"../../../screenshots/{date}_{title}-.png";
            await page.ScreenshotAsync(path: path);
        }


    }
}
