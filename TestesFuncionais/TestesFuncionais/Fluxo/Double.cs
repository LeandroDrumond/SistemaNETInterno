using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendasTestesFuncionais;

namespace VendasTestesFuncionais {

    [TestClass]
    public class Double : ObjectForm {

        [TestInitialize]
        public void Start() {
            FazLogin();
            waitSpinner();
            Assert.IsTrue(ValidaLogin());
            SubmitCep();
            waitSpinner();
            SubmitCpf();
            waitSpinner();

        }

        [TestMethod]
        public void DebitoFaturaCorreio() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaDouble();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.DebitoFaturaCorreio();


            Assert.IsTrue(validaNumPedido());

            Thread.Sleep(5000);


        }

        [TestMethod]

        public void DebitoFaturaDigital() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaDouble();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.DebitoFaturaDigital();

            Assert.IsTrue(validaNumPedido());

            Thread.Sleep(5000);


        }

        [TestMethod]

        public void BoletoFaturaDigital() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaDouble();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.BoletoFaturaDigital();

            Assert.IsTrue(validaNumPedido());

            Thread.Sleep(5000);


        }

        [TestMethod]

        public void BoletoFaturaCorreio() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaDouble();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.BoletoFaturaCorreio();

            Assert.IsTrue(validaNumPedido());

            Thread.Sleep(5000);

        }


    }
}
