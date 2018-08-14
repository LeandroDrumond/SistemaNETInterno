using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendasTestesFuncionais;

namespace VendasTestesFuncionais {
    public class FormaPagamento : BasePage {

        private IWebElement Banco { get; set; }
        private IWebElement agencia { get; set; }
        private IWebElement conta { get; set; }
        private IWebElement btnContinuar { get; set; }
        private IList<IWebElement> listaBanco { get; set; }
        private IWebElement rButtonNao { get; set; }

        private IWebElement rButtonNaoBoleto { get; set; }
        private IWebElement sim { get; set; }

        public const string nomeBanco = "Banco Bradesco S.A. - 237";
        public bool bValidaDfc { get; set; }

        public FormaPagamento(IWebDriver driver) : base(driver) {

            Banco = driver.FindElement(By.CssSelector("md-select[id^='select_']"));
            agencia = driver.FindElement(By.Id("input_6"));
            conta = driver.FindElement(By.Id("input_7"));
            btnContinuar = driver.FindElement(By.XPath("//button[contains(text(),'Continuar')]"));
            listaBanco = driver.FindElements(By.XPath("//div[@class='md-text ng-binding']"));
            
           
        }

        public FormaPagamento() {

        }

        public void DebitoFaturaCorreio() {

            rButtonNao = driver.FindElement(By.Id("radio_24"));

            Banco.Click();
            //actions.MoveToElement(Banco).Click().Build().Perform();
            foreach (var item in listaBanco) {

                if (item.Text.ToLower() == nomeBanco.ToLower()) {

                    item.Click();
                    waitSpinner();
                    agencia.Clear();
                    agencia.SendKeys("86789");
                    conta.SendKeys("457814-8");
                    rButtonNao.Click();
                    Thread.Sleep(5000);
                    sim = driver.FindElement(By.CssSelector("button[ng-click='paymentNotificationCtrl.cancel()']"));
                    sim.Click();
                    Thread.Sleep(5000);
                    btnContinuar.Click();
                    IWebElement btnAceito = driver.FindElement(By.CssSelector("button[ng-click='conclusion.finishCart()']"));
                    Thread.Sleep(5000);
                    btnAceito.Click();
                    break;

                }

            }
        }

        public void DebitoFaturaDigital() {
            Banco.Click();
            foreach (var item in listaBanco) {

                if (item.Text.ToLower() == nomeBanco.ToLower()) {

                    item.Click();
                    agencia.Clear();
                    agencia.SendKeys("86789");
                    conta.SendKeys("457814-8");
                    btnContinuar.Click();
                    IWebElement btnAceito = driver.FindElement(By.CssSelector("button[ng-click='conclusion.finishCart()']"));
                    Thread.Sleep(5000);
                    btnAceito.Click();
                    break;

                }

            }

        }

        public void BoletoFaturaDigital() {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

            IWebElement abaBoleto = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//md-tab-item[contains(text(),'boleto')]")));
            abaBoleto.Click();
            IWebElement sim = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click='paymentNotificationCtrl.cancel()']")));
            waitSpinner();
            sim.Click();
            IWebElement btnContinuarBoleto = driver.FindElement(By.CssSelector("button[ng-click='payment.submitPayment(payment.paymentMode, payment.dueDate)']"));
            Thread.Sleep(5000);
            btnContinuarBoleto.Click();
            IWebElement btnAceito = driver.FindElement(By.CssSelector("button[ng-click='conclusion.finishCart()']"));
            waitSpinner();
            btnAceito.Click();


        }

        public void BoletoFaturaCorreio() {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

            IWebElement abaBoleto = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//md-tab-item[contains(text(),'boleto')]")));
            abaBoleto.Click();
            IWebElement sim = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click='paymentNotificationCtrl.cancel()']")));
            waitSpinner();
            sim.Click();
            waitSpinner();
            Thread.Sleep(5000);
            rButtonNaoBoleto =driver.FindElement(By.Id("radio_26"));
            rButtonNaoBoleto.Click();
            IWebElement btnContinuarBoleto = driver.FindElement(By.CssSelector("button[ng-click='payment.submitPayment(payment.paymentMode, payment.dueDate)']"));
            Thread.Sleep(5000);
            btnContinuarBoleto.Click();
            IWebElement btnAceito = driver.FindElement(By.CssSelector("button[ng-click='conclusion.finishCart()']"));
            waitSpinner();
            btnAceito.Click();


        }

        public bool PossuiAcrescimoTotal() {
            //IWebElement
            var aba = "Debito Automático";
            bool faturaDigital = true;
            return !(aba == "Débtio Automático " && faturaDigital);
        }
    }
}