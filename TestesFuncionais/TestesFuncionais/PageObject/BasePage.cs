using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VendasTestesFuncionais {
    public class BasePage {

        protected Actions actions;
        public IWebDriver driver;
    

        public BasePage(IWebDriver driver) {
            this.driver = driver;
        }
        protected BasePage() {

        }

        public void SetDriver(IWebDriver driver) {
            this.driver = driver;
        }

        public void waitSpinner() {


                if (driver.FindElement(By.Id("spinner-content")).Displayed) {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner-content")));
            }
        }

        public void Clicar() {

            var btn = driver.FindElement(By.CssSelector("button[ng-click='plans.submitPlans()']"));

            Thread.Sleep(3000);

            btn.Click();


        }

        public bool validaNumPedido() {

            IWebElement NumPedido = driver.FindElement(By.XPath("//span[@class='order-number ng-binding']"));

            return !(NumPedido.Text).Equals("");

        }

        public bool validaValores(IWebElement preco, decimal acrescimo) {

            IWebElement elementoValor = driver.FindElement(By.CssSelector("strong[class='price ng-binding']"));
            
            // Fazer cast de IWebElement para decimal

            return (elementoValor.Text).Equals(preco);
        }
    }
}
