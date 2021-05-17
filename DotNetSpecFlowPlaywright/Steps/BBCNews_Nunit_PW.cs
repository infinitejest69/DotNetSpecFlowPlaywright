using FluentAssertions;
using NUnit.Framework;
using PlaywrightSharp;
using System.Threading.Tasks;

namespace DotNetSpecFlowPlaywright.Steps
{
    [TestFixture]
    internal class BBCNews_Nunit_PW
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
            var page = await context.NewPageAsync();

            await page.GoToAsync("https://www.bbc.co.uk/news");
            await page.ClickAsync("text=Scotland");
            await page.ClickAsync("text=Edinburgh, Fife & East");

            var text = await page.GetInnerTextAsync("span:has-text(\"Edinburgh, Fife & East Scotland\")");
            text.Should().BeEquivalentTo("Edinburgh, Fife & East Scotland");
            await Helpers.Helpers.Screenshot(page);
        }
    }
}