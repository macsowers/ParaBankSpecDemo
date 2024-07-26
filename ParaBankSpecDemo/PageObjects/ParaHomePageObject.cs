using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankSpecDemo.PageObjects
{
    public sealed class ParaHomePageObject
    {
        private readonly IWebDriver _webDriver;

        public ParaHomePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        #region Page Elements
        //Left Panel Quick Links 
        private IWebElement LnkLeftPanelMenu(string pageName) => _webDriver.FindElement(By.XPath($"//ul[@class='leftmenu']//a[contains(text(),'{pageName}')]"));
        #endregion

        #region Page Actions
        //Left Panel Actions 
        public void ClickLeftPanelLink(string pageName)
        {
            LnkLeftPanelMenu(pageName).Click();
        }
        #endregion
    }
}
