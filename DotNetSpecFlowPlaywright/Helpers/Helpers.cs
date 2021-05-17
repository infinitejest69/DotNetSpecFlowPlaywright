using PlaywrightSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSpecFlowPlaywright.Helpers
{
    public static class Helpers
    {

        public static async Task Screenshot(IPage page)
        {
            var date = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
            var title = await page.GetTitleAsync();
            var path = $"../../../screenshots/{date}_{title}-.png";
            await page.ScreenshotAsync(path: path, fullPage: true, type: ScreenshotFormat.Png);
        }
    }
}
