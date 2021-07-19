using PlaywrightSharp;
using System.Threading.Tasks;

namespace DotNetSpecFlowPlaywright.PageObjects
{
    public class CommonPageObjects
    {
        private readonly IPage _page;

        public CommonPageObjects(IPage page)
        {
            _page = page;
        }


        public async Task GivenINavigateTo(string p0)
        {
            await _page.GoToAsync(p0);
        }


        public async Task WhenIClickNewsMenu(string p0)
        {
            await _page.ClickAsync($"text={p0}");
        }
    }
}