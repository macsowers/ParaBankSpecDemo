using ParaBankSpecDemo.PageObjects;

namespace ParaBankSpecDemo.StepDefinitions
{
    [Binding]
    public sealed class ParaBankStepDefinitions
    {
        private readonly ParaHomePageObject _ParaHomePageObject;
        private readonly GeneralObjects _GeneralObjects;
        private IWebDriver driver;

        public ParaBankStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            _ParaHomePageObject = new ParaHomePageObject(driver);
            _GeneralObjects = new GeneralObjects(driver);
        }


        [Given(@"that the Parabank homepage is open")]
        public void GivenThatTheParabankHomepageIsOpen()
        {
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [When(@"the ""([^""]*)"" link is clicked")]
        public void WhenTheLinkIsClicked(string page)
        {
            _ParaHomePageObject.ClickLeftPanelLink(page);
        }

        [Then(@"I am directed to the ""([^""]*)"" page")]
        public void ThenIAmDirectedToThePage(string expectedText)
        {
            bool isHdrPresent = _GeneralObjects.IsHeaderPresent(expectedText);
            isHdrPresent.Should().BeTrue();
        }


    }
}
