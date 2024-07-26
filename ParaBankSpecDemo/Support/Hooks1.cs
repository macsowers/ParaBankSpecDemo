using BoDi;
using ParaBankSpecDemo.Drivers;
using TechTalk.SpecFlow;

namespace ParaBankSpecDemo.Support
{
    [Binding]
    public sealed class Hooks1
    {
        public Hooks1(IObjectContainer driverContainer) { _driverContainer = driverContainer; }

        #region Properties
        private readonly IObjectContainer _driverContainer;
        private IWebDriver? _chromeDriver;
        #endregion

        #region Scenario Hooks
       [BeforeScenario("@tag1", Order = 2)]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            var restRequet = new RestRequest("/initializeDB", Method.Post);
            var restResponse = client.Execute(restRequet);
            _chromeDriver = WebDriver.CreateChromeDriver();
            _driverContainer.RegisterInstanceAs<IWebDriver>(_chromeDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var restRequest = new RestRequest("/cleanDB", Method.Post);
            var restResponse = client.Execute(restRequest);
            if (_chromeDriver != null) { _chromeDriver.Quit(); }
            _chromeDriver = _driverContainer.Resolve<IWebDriver>();
        }
        #endregion

        #region Resources
        private readonly WebDrivers WebDriver = new();
        private readonly RestClient client = new RestClient("https://parabank.parasoft.com/parabank/services/bank");
        #endregion
    }
}