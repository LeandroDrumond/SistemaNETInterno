using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendasTestesFuncionais {
     public class DadosPessoaisPage : BasePage {

        IWebElement numero { get; set; }
        IWebElement complemento { get; set; }
        IWebElement rg { get; set; }
        IWebElement OrgaoExp { get; set; }
        IWebElement name { get; set; }
        IWebElement motherName { get; set; }
        IWebElement birth { get; set; }
        IWebElement email { get; set; }
        IWebElement phone { get; set; }
        IWebElement btnContinuar { get; set; }

        public DadosPessoaisPage(IWebDriver driver) : base(driver) {

             numero = driver.FindElement(By.Id("numero"));
             complemento = driver.FindElement(By.Id("complemento"));
             rg = driver.FindElement(By.Id("rg"));
             OrgaoExp = driver.FindElement(By.Id("orgaoExpedidor"));
             name = driver.FindElement(By.Id("name"));
             motherName = driver.FindElement(By.Id("motherName"));
             birth = driver.FindElement(By.Id("birthday"));
             email = driver.FindElement(By.Id("email"));
             phone = driver.FindElement(By.Id("phone"));
             btnContinuar = driver.FindElement(By.CssSelector("button[ng-click='personalData.submitPersonalData(frmValidate)']"));


        }

        public void InserirDadosPessoais() {

            numero.Clear();
            numero.SendKeys("591");
            complemento.Clear();
            complemento.SendKeys("Apt 105"); 
            rg.Clear();
            rg.SendKeys(Gerador.gerarNumero());
            OrgaoExp.Clear();
            OrgaoExp.SendKeys("Detran");
            name.Clear();
            name.SendKeys("Teste TI");
            motherName.Clear();
            motherName.SendKeys("Teste TI");
            birth.Clear();
            birth.SendKeys("01011990");
            email.Clear();
            email.SendKeys(Gerador.gerarEmail());
            phone.Clear();
            phone.SendKeys(Gerador.gerarNumeroCelular());
             btnContinuar.Click();


        }


    }
}
