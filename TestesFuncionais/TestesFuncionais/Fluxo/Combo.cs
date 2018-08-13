using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendasTestesFuncionais;

namespace VendasTestesFuncionais {

    [TestClass]
    public class Combo : ObjectForm {

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
        public void BoletoFaturaCorreio() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaCombo();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.BoletoFaturaCorreio();

            Assert.IsTrue(validaNumPedido());

        }

        [TestMethod]
        public void BoletoFaturaDigital() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaCombo();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.BoletoFaturaDigital();

            Assert.IsTrue(validaNumPedido());


        }

        [TestMethod]
        public void DebitoFaturaDigital() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaCombo();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.DebitoFaturaDigital();

            Assert.IsTrue(validaNumPedido());


        }

        [TestMethod]
        public void DebitoFaturaCorreio() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaCombo();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.DebitoFaturaCorreio();

            Assert.IsTrue(validaNumPedido());

        }


    }
}
