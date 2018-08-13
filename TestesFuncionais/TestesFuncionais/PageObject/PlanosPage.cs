using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendasTestesFuncionais;
using VendasTestesFuncionais.Extensions;

namespace VendasTestesFuncionais {
    public class PlanosPage : BasePage {

        public bool bvalidaSingle { get; set; }
        public bool bvalidaDouble { get; set; }
        public bool bvalidaCombo { get; set; }
        private string planoNet { get; set; }
        private string planoTV { get; set; }
        private string planoFixo { get; set; }
        private IWebElement ElementInternet { get; set; }
        private IList<IWebElement> listaInternet { get; set; }
        private IList<IWebElement> listaTV { get; set; }
        public IWebElement preco { get; set; }
        private IWebElement TV { get; set; }
        private IWebElement Fixo { get; set; }
        public string precoSingle { get; set; }
        public string precoDouble { get; set; }
        public string precoCombo { get; set; }

        public PlanosPage(IWebDriver driver) : base(driver) {

            ElementInternet = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleInternet()']"));
            TV = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleTV()']"));
            Fixo = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleFixo()']"));

            planoNet = "35 MEGA";
            planoTV = "Fácil HD";
            planoFixo = "Brasil 21";
            precoSingle = "129,99";

        }

        public PlanosPage() {


        }

        public void montaSingle() {

            ElementInternet.Click();

            listaInternet = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansInternet']//span[@class='plan-description ng-binding']"));


            Thread.Sleep(2000);

            foreach (var item in listaInternet) {

                if (item.Text.ToLower() == planoNet.ToLower()) {

                    item.Click();
                    waitSpinner();
                    break;

                }
                else {

                    Console.WriteLine("Plano:" + planoNet + "não encontrado");

                }

            }
            // bvalidaSingle = true;
            CapturaValor();

        }

        public void montaDouble() {

            montaSingle();
            TV.Click();
            listaTV = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansTV']//span[@ng-bind='plan.Nome']"), 3000);
            waitSpinner();
            Thread.Sleep(5000);

            foreach (var item in listaTV) {

                if (item.Text.ToLower() == planoTV.ToLower()) {

                    item.Click();
                    waitSpinner();
                    break;

                }
                else {

                    Console.WriteLine("Plano:" + planoTV + "não encontrado");

                }

            }

            // bvalidaDouble = true;
            CapturaValor();
        }

        public void montaCombo() {

            montaDouble();
            IList<IWebElement> listaFixo = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansFixo']//span[@class='plan-description ng-binding']"), 3000);
            waitSpinner();
            Thread.Sleep(5000);
            Fixo.Click();

            Thread.Sleep(2000);

            foreach (var item in listaFixo) {

                if (item.Text.ToLower() == planoFixo.ToLower()) {

                    item.Click();
                    waitSpinner();
                    break;
                }

            }

        }

        private void CapturaValor() {

            preco = driver.FindElement(By.CssSelector("p[ng-bind='plans.plansResumo.preco']"));
        }
    }
}
