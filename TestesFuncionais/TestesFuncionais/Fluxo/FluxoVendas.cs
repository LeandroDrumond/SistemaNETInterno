using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;

namespace TestesFuncionais {
    

    [TestClass]
    public class FluxoVendas : ObjectForm {

        [TestMethod]
        public void Fluxo_Single() {

            FazLogin();
            Thread.Sleep(5000);
            Assert.IsTrue(ValidaLogin());
            SubmitCep();
            Thread.Sleep(2000);
            SubmitCpf();
            MontaSingle(PlanoNet);
            Clicar();
            Thread.Sleep(5000);
            InserirDadosPessoais();


        }

        [TestMethod]
        public void Fluxo_Double() {

            FazLogin();
            Thread.Sleep(2000);
            Assert.IsTrue(ValidaLogin());
            SubmitCep();
            Thread.Sleep(2000);
            SubmitCpf();
            MontaDouble(PlanoNet, PlanoTv);

        }

        [TestMethod]
        public void Fluxo_Combo() {

            AbreURL();
            FazLogin();
            Thread.Sleep(2000);
            Assert.IsTrue(ValidaLogin());
            SubmitCep();
            Thread.Sleep(2000);
            SubmitCpf();
            MontaCombo(PlanoNet, PlanoTv, PlanoFixo);

        }


    }
}
