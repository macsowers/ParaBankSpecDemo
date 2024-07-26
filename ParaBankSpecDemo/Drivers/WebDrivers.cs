using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ParaBankSpecDemo.Drivers
{
    public sealed class WebDrivers
    {
        public IWebDriver CreateChromeDriver()
        {
            //Creating browser using chrome. 
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions() { };
            //chromeOptions.AddArgument("--headless");

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            return chromeDriver;
        }

        public IWebDriver CreateFirefoxDriver()
        {
            var firefoxDriverServices = FirefoxDriverService.CreateDefaultService();
            var firefoxOptions = new FirefoxOptions() { };
            firefoxOptions.AddArguments("--headless");
            var firefoxDriver = new FirefoxDriver(firefoxDriverServices, firefoxOptions);
            return firefoxDriver;
        }
    }
}
