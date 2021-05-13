using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using static SpecFlowSelenium.Configuration.Configuration;

namespace SpecFlowSelenium.Configuration
{
    public class DriverConfiguration
    {
        private readonly Configuration configuration;
        public RemoteWebDriver WebDriver { get; private set; }
        public IWait<IWebDriver> Wait { get; private set; }
        private ICapabilities capabilities;


        public DriverConfiguration()
        {
            configuration = new Configuration();
            createWebdriver();
        }

        public string getScreenShotBase64()
        {
            return WebDriver.GetScreenshot().AsBase64EncodedString;
        }

        private void createWebdriver()
        {
            switch (configuration.environemnt)
            {
                case Environemnt.LOCAL:
                    switch (configuration.browser)
                    {
                        case Browser.CHROME:
                            WebDriver = new ChromeDriver();
                            break;
                        case Browser.FIREFOX:
                            WebDriver = new FirefoxDriver();
                            break;
                        case Browser.EDGE:
                            WebDriver = new EdgeDriver();
                            break;
                    }
                    AddTimeouts();
                    break;
                case Environemnt.REMOTE:
                    switch (configuration.browser)
                    {
                        case Browser.CHROME:
                            ChromeOptions ChromeOption = new ChromeOptions();
                            ChromeOption.AcceptInsecureCertificates = false;
                            ChromeOption.AddArgument("--headless");
                            ChromeOption.AddArgument("--whitelisted-ips");
                            ChromeOption.AddArgument("--no-sandbox");
                            ChromeOption.AddArgument("--disable-extensions");
                            capabilities = ChromeOption.ToCapabilities();
                            break;
                        case Browser.FIREFOX:
                            FirefoxOptions FirefoxOption = new FirefoxOptions();
                            capabilities = FirefoxOption.ToCapabilities();
                            break;
                        case Browser.EDGE:
                            EdgeOptions EdgeOption = new EdgeOptions();
                            capabilities = EdgeOption.ToCapabilities();
                            break;
                        default:
                            break;
                    }
                    break;
                    WebDriver = new RemoteWebDriver(configuration.Hub, capabilities, TimeSpan.FromMinutes(5));// NOTE: connection timeout of 600 seconds or more required for time to launch grid nodes if non are available.
                    AddTimeouts();
                    return;

                default:
                    throw new Exception("Somethings gone wrong creating the WebDriver in DriverConfiguration");
            }

        }

        private void AddTimeouts()
        {
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(configuration.Timeout);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30.00));
        }
    }
}
