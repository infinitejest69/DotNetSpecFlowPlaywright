using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace DotNetSpecFlowPlaywright.Helpers
{
    public static class Helpers
    {
        public static async Task Screenshot(IPage page)
        {
            var date = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
            var title = await page.TitleAsync();
            var path = $"../../../screenshots/{date}_{title}-.png";
            var so = new PageScreenshotOptions()
            {
                Path = path,
                FullPage = true,
            };
            await page.ScreenshotAsync(so);
        }
    }
}