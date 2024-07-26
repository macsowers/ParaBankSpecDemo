using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankSpecDemo.PageObjects
{
    public class GeneralObjects
    {
        private readonly IWebDriver _webDriver;
        WebDriverWait wait;

        public GeneralObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2));
        }

        #region Page Elements
        private IWebElement HdrPageConfirmationHeading(string hdrTxt) => _webDriver.FindElement(By.XPath($"//*[contains(text(),'{hdrTxt}')]"));
        #endregion

        #region Actions
        public bool IsHeaderPresent(string hdrText)
        {
            wait.Until(d => HdrPageConfirmationHeading(hdrText));
            if (HdrPageConfirmationHeading(hdrText) != null) { return true; }
            else { return false; }
        }
        #endregion
    }
}
