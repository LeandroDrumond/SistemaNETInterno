using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasTestesFuncionais;

namespace TestesFuncionais {
    public class ObjectForm: TestBase_Vendas {

        public void FazLogin() {
            driver.FindElement(By.Id("username")).SendKeys("leandro.vianna");
            driver.FindElement(By.Id("password")).SendKeys("ieH!7b6X");


        }



    }
}
