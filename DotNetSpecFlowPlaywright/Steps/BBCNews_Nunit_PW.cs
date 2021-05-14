using FluentAssertions;
using NUnit.Framework;
using PlaywrightSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSpecFlowPlaywright.Steps
{
    [TestFixture]
    class BBCNews_Nunit_PW
    {

        [Test]
        public async Task Test()
        {
            await Playwright.InstallAsync();
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(
                headless: true
            );
            var context = await browser.NewContextAsync();

            // Open new page
            var page = await context.NewPageAsync();

            // Go to https://www.bbc.co.uk/news
            await page.GoToAsync("https://www.bbc.co.uk/news");

            // Click text=Scotland
            await page.ClickAsync("text=Scotland");
            // Assert.Equal("https://www.bbc.co.uk/news/scotland", page.Url);

            // Click text=Edinburgh, Fife & East
            await page.ClickAsync("text=Edinburgh, Fife & East");
            // Assert.Equal("https://www.bbc.co.uk/news/scotland/edinburgh_east_and_fife", page.Url);

            // Click span:has-text("Edinburgh, Fife & East Scotland")
            var text = await page.GetInnerTextAsync("span:has-text(\"Edinburgh, Fife & East Scotland\")");
            text.Should().BeEquivalentTo("Edinburgh, Fife & East Scotland");
            await Screenshot(page);
             //Assert.AreEqual(text, "Edinburgh, Fife & East Scotland");

            // ---------------------
        }

        private static async Task Screenshot(IPage page )
        {
            var date = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
            var title = await page.GetTitleAsync();
            var path = $"../../../screenshots/{date}_{title}-.png";
            await page.ScreenshotAsync(path: path);
        }


    }
}
