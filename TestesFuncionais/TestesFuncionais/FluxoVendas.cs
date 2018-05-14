using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendasTestesFuncionais;


namespace TestesFuncionais {

   


    [TestClass]
    public class FluxoVendas : ObjectForm {

        


        [TestMethod]
        public void TestSingle() {

            AbreURL();
            FazLogin();
        }



    }
}
