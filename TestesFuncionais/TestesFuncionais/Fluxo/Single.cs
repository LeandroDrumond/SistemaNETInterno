using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using VendasTestesFuncionais;

namespace VendasTestesFuncionais {

    [TestClass]
    public class Single : ObjectForm {

        [TestInitialize]
        public void StartTest() {
        
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
            planosPage.montaSingle();
            Clicar();
            waitSpinner();

            DadosPessoaisPage dadosPessoais = new DadosPessoaisPage(driver);
            dadosPessoais.InserirDadosPessoais();

            FormaPagamento frmPagamento = new FormaPagamento(driver);
            frmPagamento.DebitoFaturaCorreio();

            Assert.IsTrue(validaNumPedido());

            //Assert.IsTrue(validaValores(planosPage.preco, frmPagamento.PossuiAcrescimoTotal() ? 5 : 0));
         
            Thread.Sleep(5000);
            
        }

        [TestMethod]

        public void DebitoFaturaDigital() {

            PlanosPage planosPage = new PlanosPage(driver);
            planosPage.montaSingle();
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
            planosPage.montaSingle();
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
            planosPage.montaSingle();
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
