using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestesFuncionais.Helper;
using VendasTestesFuncionais;

namespace TestesFuncionais {
    public  abstract class ObjectForm : TestBase_Vendas {


        public const string PlanoNet = "35 MEGA";

        public const string PlanoTv = "Fácil HD";

        public const string PlanoFixo = "Brasil 21";


       #region Inicializações
        protected Actions actions;


       [TestInitialize()]
        public void Inicializar() {
            InicializaValores();
            AbreURL();
            //actions = new Actions(driver);
            
        }

        [TestCleanup()]
        public void CleanUp() {
            FinalizaValores();
        }

        #endregion
        
    
        public void FazLogin() {

            driver.FindElement(By.Id("username")).SendKeys("leandro.vianna");
            driver.FindElement(By.Id("password")).SendKeys("ieH!7b6X");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

        }

        public static bool ValidaLogin() {

            IWebElement validaLogin = driver.FindElement(By.Id("chatid"));

            return validaLogin.Displayed ? true : false;

        }

        public void SubmitCep() {

            IWebElement cep = driver.FindElement(By.Id("cep"));

            cep.SendKeys("21073311");

            cep.SendKeys(Keys.Enter);

        }

        public void Clicar() {

            IWebElement btn = driver.FindElement(By.CssSelector("button[ng-click='plans.submitPlans()']"));

            Thread.Sleep(3000);

            btn.Click();
            

        }

        public static void SubmitCpf() {

            IWebElement cpf = driver.FindElement(By.Id("cpf"));

            cpf.SendKeys(Gerador.gerarCpf());


        }

        public void MontaSingle(string PlanoNet) {

            IWebElement Internet = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleInternet()']"));

            IList<IWebElement> listaInternet = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansInternet']//span[@class='plan-description ng-binding']"));

            // TODO

            Internet.Click();

            Thread.Sleep(2000);

            foreach (var item in listaInternet) {

                if (item.Text.ToLower() == PlanoNet.ToLower()) {

                    item.Click();
                    break;
                }
                else {

                    // Verificar qual tratamento.

                }


            }

        }


        public void MontaDouble(string PlanoNet, string PlanoTv) {

            MontaSingle(PlanoNet);

            IWebElement TV = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleTV()']"));

            IList<IWebElement> listaTV = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansTV']//span[@class='plan-description ng-binding']"));

            TV.Click();
            Thread.Sleep(2000);

            foreach (var item in listaTV) {

                if (item.Text.ToLower() == PlanoTv.ToLower()) {

                    item.Click();
                    break;

                }
                else {

                    // Verificar qual tratamento.

                }


            }

        }


        public void MontaCombo(string PlanoNet, string PlanoTv, string PlanoFixo) {

            MontaDouble(PlanoNet, PlanoTv);

            IWebElement Fixo = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleFixo()']"));
            IList<IWebElement> listaFixo = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansFixo']//span[@class='plan-description ng-binding']"));

            Fixo.Click();

            Thread.Sleep(2000);

            foreach (var item in listaFixo) {

                if (item.Text.ToLower() == PlanoFixo.ToLower()) {

                    item.Click();
                    break;
                }

            }



        }


        public void InserirDadosPessoais() {


            IWebElement numero = driver.FindElement(By.Id("numero"));
            numero.Clear();
            numero.SendKeys("591");


            
        }


    }
}