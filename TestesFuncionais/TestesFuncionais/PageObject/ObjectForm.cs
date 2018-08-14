using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using VendasTestesFuncionais.Extensions;

namespace VendasTestesFuncionais {
    public class ObjectForm : TestBase_Vendas {

        public const string PlanoNet = "35 MEGA";

        public const string PlanoTv = "Fácil HD";

        public const string PlanoFixo = "Brasil 21";

        public const string nomeBanco = "Banco Bradesco S.A. - 237";

        public const string precoSingle = "129,99";

        public const string precoDouble = "189,98";

        public const string precoCombo = "153,99";

        public bool bValidaSingle { get; set; }

        private static bool bValidaDouble { get; set; }

        private static bool bValidaCombo { get; set; }

        public static bool bValidaDfc { get; set; }

        private static bool bValidaDfd { get; set; }

        private static bool bValidaBfd { get; set; }

        #region Inicializações
       

        [TestInitialize()]
        public void Inicializar() {

            InicializaValores();
            AbreURL();
            actions = new Actions(driver);
           
         }

        [TestCleanup()]
        public void CleanUp() {
            FinalizaValores();
        }

        #endregion

        public void FazLogin() {

            driver.FindElement(By.Id("username")).SendKeys("SeuUser");
            driver.FindElement(By.Id("password")).SendKeys("SuaSenha");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

        }

        public bool ValidaLogin() {

            IWebElement validaLogin = driver.FindElement(By.Id("chatid"));

            return validaLogin.Displayed ? true : false;

        }

        public void SubmitCep() {

            IWebElement cep = driver.FindElement(By.Id("cep"));

            cep.SendKeys("21073311");

            cep.SendKeys(Keys.Enter);

        }

      

        public  void SubmitCpf() {

            IWebElement cpf = driver.FindElement(By.Id("cpf"));

            cpf.SendKeys(Gerador.gerarCpf());


        }

        public bool MontaSingle(string PlanoNet) {

            IWebElement Internet = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleInternet()']"));


            IList<IWebElement> listaInternet = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansInternet']//span[@class='plan-description ng-binding']"));

            Internet.Click();

            Thread.Sleep(2000);

            foreach (var item in listaInternet) {

                if (item.Text.ToLower() == PlanoNet.ToLower()) {

                    item.Click();
                    waitSpinner();
                    break;

                   
                }
                else {

                    // Verificar qual tratamento.

                }


            }
            return bValidaSingle = true;
        }


        public bool MontaDouble(string PlanoNet, string PlanoTv) {

            
            IWebElement TV = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleTV()']"));
            IList<IWebElement> listaTV = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansTV']//span[@ng-bind='plan.Nome']"), 3000);
            waitSpinner();
            Thread.Sleep(5000);
            TV.Click();
            
            foreach (var item in listaTV) {

                if (item.Text.ToLower() == PlanoTv.ToLower()) {

                    item.Click();
                    waitSpinner();
                    break;
                    
                }
                else {

                    // Verificar qual tratamento.

                }


            }
            
            MontaSingle(PlanoNet);
            return bValidaDouble = true;
        }


        public bool MontaCombo(string PlanoNet, string PlanoTv, string PlanoFixo) {

           
            IWebElement Fixo = driver.FindElement(By.CssSelector("li[ng-click='plans.toggleFixo()']"));
            
            IList<IWebElement> listaFixo = driver.FindElements(By.XPath("//li[@ng-repeat='plan in plans.plansFixo']//span[@class='plan-description ng-binding']"),3000);
            waitSpinner();
            Thread.Sleep(5000);
            Fixo.Click();

            Thread.Sleep(2000);

            foreach (var item in listaFixo) {

                if (item.Text.ToLower() == PlanoFixo.ToLower()) {

                    item.Click();
                    waitSpinner();
                    break;
                }

            }
            
            MontaDouble(PlanoNet, PlanoTv);
            return bValidaCombo = true;
        }


        public void InserirDadosPessoais() {

            IWebElement numero = driver.FindElement(By.Id("numero"));
            numero.Clear();
            numero.SendKeys("591");
            IWebElement comp = driver.FindElement(By.Id("complemento"));
            comp.Clear();
            comp.SendKeys("Apt 105");
            IWebElement rg = driver.FindElement(By.Id("rg"));
            rg.Clear();
            rg.SendKeys(Gerador.gerarNumero());
            IWebElement OrgaoExp = driver.FindElement(By.Id("orgaoExpedidor"));
            OrgaoExp.Clear();
            OrgaoExp.SendKeys("Detran");
            IWebElement name = driver.FindElement(By.Id("name"));
            name.Clear();
            name.SendKeys("Teste TI");
            IWebElement motherName = driver.FindElement(By.Id("motherName"));
            motherName.Clear();
            motherName.SendKeys("Teste TI");
            IWebElement birth = driver.FindElement(By.Id("birthday"));
            birth.Clear();
            birth.SendKeys("01011990");
            IWebElement email = driver.FindElement(By.Id("email"));
            email.Clear();
            email.SendKeys(Gerador.gerarEmail());
            IWebElement phone = driver.FindElement(By.Id("phone"));
            phone.Clear();
            phone.SendKeys(Gerador.gerarNumeroCelular());
            IWebElement btnContinuar = driver.FindElement(By.CssSelector("button[ng-click='personalData.submitPersonalData(frmValidate)']"));
            btnContinuar.Click();


        }

        public bool ValidaTelaDadosPessoais() {

            IWebElement DadosPessoais = driver.FindElement(By.XPath("//h1[contains(text(),'Dados Pessoais')]"));

            Boolean result = (DadosPessoais.Text).Equals("Dados Pessoais");

            return result;
            

        }

        public bool formaPagamento(string tipoPagamento) {

            IWebElement selecionaBanco = driver.FindElement(By.CssSelector("md-select[id^='select_']"));
            IWebElement agencia = driver.FindElement(By.Id("input_6"));
            IWebElement conta = driver.FindElement(By.Id("input_7"));
            IWebElement btnContinuar = driver.FindElement(By.XPath("//button[contains(text(),'Continuar')]"));

           string  Dfd = "Debito Fatura Digital";

           string Dfc = "Debito Fatura Correio";

           string Bfd = "Boleto Fatura Digital";

            if (tipoPagamento.ToLower() == Dfc.ToLower()) {

                Thread.Sleep(5000);

                actions.MoveToElement(selecionaBanco).Click().Build().Perform();
                IList<IWebElement> listaBanco = driver.FindElements(By.XPath("//div[@class='md-text ng-binding']"));
                IWebElement rButtonNao = driver.FindElement(By.Id("radio_24"));

                foreach (var item in listaBanco) {

                    if (item.Text.ToLower() == nomeBanco.ToLower()) {

                        item.Click();
                        waitSpinner();
                        agencia.Clear();
                        agencia.SendKeys("86789");
                        conta.SendKeys("457814-8");
                        rButtonNao.Click();
                        IWebElement sim = driver.FindElement(By.CssSelector("button[ng-click='paymentNotificationCtrl.cancel()']"));
                        Thread.Sleep(5000);
                        sim.Click();
                        Thread.Sleep(5000);
                        btnContinuar.Click();
                        IWebElement btnAceito = driver.FindElement(By.CssSelector("button[ng-click='conclusion.finishCart()']"));
                        Thread.Sleep(5000);
                        btnAceito.Click();
                        break;


                    }

                }
               

                return bValidaDfc = true;
            }
            else if (tipoPagamento.ToLower() == Dfd.ToLower()) {

                actions.MoveToElement(selecionaBanco).Click().Build().Perform();
                IList<IWebElement> listaBanco = driver.FindElements(By.XPath("//div[@class='md-text ng-binding']"));

                foreach (var item in listaBanco) {

                    if (item.Text.ToLower() == nomeBanco.ToLower()) {

                        item.Click();
                        agencia.SendKeys("86789");
                        conta.SendKeys("457814-8");
                        btnContinuar.Click();
                        IWebElement btnAceito = driver.FindElement(By.CssSelector("button[ng-click='conclusion.finishCart()']"));
                        Thread.Sleep(5000);
                        btnAceito.Click();
                        break;

                    }

                }
                return bValidaDfd = true;
                
            }

            else if(tipoPagamento.ToLower() == Bfd.ToLower()) {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
               IWebElement abaBoleto = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//md-tab-item[contains(text(),'boleto')]")));
                 abaBoleto.Click();
               IWebElement sim =  wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click='paymentNotificationCtrl.cancel()']")));
                 waitSpinner();
                 sim.Click();
               IWebElement btnContinuarBoleto = driver.FindElement(By.CssSelector("button[ng-click='payment.submitPayment(payment.paymentMode, payment.dueDate)']"));
                Thread.Sleep(5000);
                btnContinuarBoleto.Click();
                IWebElement btnAceito = driver.FindElement(By.CssSelector("button[ng-click='conclusion.finishCart()']"));
                waitSpinner();
                btnAceito.Click();

                return bValidaBfd = true;

            }
          return false;
        }

      /*  public bool ValidaNumPedido() {

            IWebElement NumPedido = driver.FindElement(By.XPath("//span[@class='order-number ng-binding']"));

            return !(NumPedido.Text).Equals("");

        } */

        public bool ValidaValores() {
            
            IWebElement elementoValor = driver.FindElement(By.CssSelector("strong[class='price ng-binding']"));

            if (bValidaSingle && bValidaDfc) {

                return (elementoValor.Text).Equals(precoSingle) ;

            }
            else if (bValidaDouble && bValidaBfd) {

                return (elementoValor.Text).Equals(precoDouble);
            }
            else if (bValidaCombo && bValidaDfd) {

                return (elementoValor.Text).Equals(precoCombo);

            }

            return false;
           

        }

    }

    

}