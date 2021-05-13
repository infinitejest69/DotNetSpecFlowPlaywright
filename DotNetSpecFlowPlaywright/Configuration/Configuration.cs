using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SpecFlowSelenium.Configuration
{
    partial class Configuration
    {
        private readonly string websettings = "webappsettings.json";
        public IConfiguration Config { get; private set; }
        public Browser browser { get; private set; }
        public Uri Hub { get; private set; }
        public Environemnt environemnt { get; private set; }
        public int Timeout { get; private set; }

        public Configuration()
        {
            ReadConfigFile();
            SetBrowser();
            GetRunType();
            GetSeleniumHub();
            GetTimeout();
        }

        private void GetTimeout()
        {
            Timeout = int.Parse(Config.GetSection("ImplicitWait").Value);
        }

        private void ReadConfigFile()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(websettings, optional: false, reloadOnChange: true);

            Config = builder.Build();
        }

        private void GetRunType()
        {
            var runtype = Config.GetSection("Environment").Value.ToLower();
            if (runtype.Equals("local"))
            {
                environemnt = Environemnt.LOCAL;
            }
            else if (runtype.Equals("remote"))
            {
                environemnt = Environemnt.REMOTE;
            }
            else
            {
                throw new Exception($"Unknown Environment {runtype}, acceptable values are Local, Remote");
            }
        }

        public enum Environemnt
        {
            LOCAL,
            REMOTE
        }

        private void GetSeleniumHub()
        {
            var hubString = Config.GetSection("SeleniumHub").Value;
            if (environemnt.Equals(Environemnt.REMOTE))
            {
                if (hubString != null)
                {
                    Hub = new Uri(hubString);
                }
                else
                {
                    throw new Exception($"Check SeleniumHub has URI, and Environment is remote");
                }
            }
           
        }

        private void SetBrowser()
        {
            var browserString = Config.GetSection("Browser").Value.ToLower();
            browser = browserString switch
            {
                "chrome" => Browser.CHROME,
                "firefox" => Browser.FIREFOX,
                "edge" => Browser.EDGE,
                _ => throw new Exception($"Unknown browser {browserString}, Acceptable Chrome, Firefox, Edge"),
            };
        }
    }
}
