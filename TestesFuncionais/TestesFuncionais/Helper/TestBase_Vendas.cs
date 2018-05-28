using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace VendasTestesFuncionais {

    public enum TipoDriver {

        Chrome,
        Firefox,
        InternetExplorer

    }

    // TODO Tempo Espera

    public abstract class TestBase_Vendas {

        private const int TEMPO_ESPERA_ELEMENTO = 80;

        protected static IWebDriver driver;
        public WebDriverWait wait;

        protected const string PRD = "http://vendastelecom.celulardireto.com.br/planos";

        public virtual void InicializaValores() {
            driver = ObtemDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TEMPO_ESPERA_ELEMENTO);

        }

        public void AbreURL() {

            //driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(PRD);
            driver.Manage().Window.Maximize();



        }

        public virtual void FinalizaValores() {
            driver.Close();
            driver.Quit();
            driver.Dispose();
            driver = null;
            driver = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /*public void executandoThread() {

            ThreadStart ts = new ThreadStart(InicializaValores);
            CrossThreadTestRunner runner = new CrossThreadTestRunner(ts);
            runner.Run();
        } */



       /* public TestBase_Vendas() {
            driver = ObtemDriver();
        }*/ 

        protected virtual IWebDriver ObtemDriver(TipoDriver tipoDriver) {


            switch (tipoDriver) {

                case TipoDriver.Chrome: {

                        var chromeDriverService = ChromeDriverService.CreateDefaultService();
                        chromeDriverService.HideCommandPromptWindow = true;
                        ChromeOptions chromeOptions = new ChromeOptions();
                        driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromSeconds(60));
                        break;
                    }

                case TipoDriver.Firefox: {

                        driver = new FirefoxDriver();
                        break;
                    }

                case TipoDriver.InternetExplorer: {

                        driver = new InternetExplorerDriver();
                        break;
                    }

            }

            return driver;
        }

        private IWebDriver ObtemDriver() {

            return ObtemDriver(TipoDriver.Chrome);
        }




      




    }








}
