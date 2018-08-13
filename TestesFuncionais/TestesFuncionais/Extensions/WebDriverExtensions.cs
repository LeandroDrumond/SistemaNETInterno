using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VendasTestesFuncionais.Extensions {
    public static class WebDriverExtensions {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds) {
            if (timeoutInSeconds > 0) {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            Thread.Sleep(timeoutInSeconds);
            return driver.FindElement(by);
        }

        public static IList<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds) {

            Thread.Sleep(timeoutInSeconds);
            return driver.FindElements(by);
        }
    }
}
