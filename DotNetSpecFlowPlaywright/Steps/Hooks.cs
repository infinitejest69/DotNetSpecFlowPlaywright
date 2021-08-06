using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;

using System.Threading.Tasks;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace DotNetSpecFlowPlaywright.Steps
{
    [Binding]
    internal class Hooks
    {
        public IBrowser browser;
        public IBrowserContext context;
        public IPage page;
        public IPlaywright playwright;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [AfterScenario()]
        public async Task closeBrowser()
        {
            if (_scenarioContext.TestError != null)
            {
                await Helpers.Helpers.Screenshot(page);
            }
            await browser.DisposeAsync();
        }

        [BeforeScenario()]
        public async Task createBrowser()
        {
            playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions typeLaunchOptions = new BrowserTypeLaunchOptions{ Headless = false };
            browser = await playwright.Chromium.LaunchAsync(typeLaunchOptions);
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            _objectContainer.RegisterInstanceAs(page);
        }
    }
}