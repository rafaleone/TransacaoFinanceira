
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TransacaoFinanceira.DataAccess;
using TransacaoFinanceira.Business;
using TransacaoFinanceira.Model;

namespace TransacaoFinanceira.Tests.Busisness
{
    [TestClass]
    public class TransacaoFinanceiraTests
    {
        private Mock<IAcessoDadosDB> mockAcessoDadosDB;
        private Business.TransacaoFinanceira transacaoFinanceira;

        [TestInitialize]
        public void Setup()
        {
            // Configura o mock
            mockAcessoDadosDB = new Mock<IAcessoDadosDB>();

            // Cria a instância da classe a ser testada
            transacaoFinanceira = new Business.TransacaoFinanceira(mockAcessoDadosDB.Object);
        }

        [TestMethod]
        public void Transferir_SaldoSuficiente_EfetuaTransferencia()
        {
            // Arrange
            string contaOrigemId = "123";
            string contaDestinoId = "456";
            decimal valorTransacao = 100m;

            var contaOrigem = new ContasSaldoModel(contaOrigemId, 200);
            var contaDestino = new ContasSaldoModel(contaDestinoId, 300);

            mockAcessoDadosDB.Setup(db => db.getConta(contaOrigemId)).Returns(contaOrigem);
            mockAcessoDadosDB.Setup(db => db.getConta(contaDestinoId)).Returns(contaDestino);

            // Act
            transacaoFinanceira.transferir(1, contaOrigemId, contaDestinoId, valorTransacao);

            // Assert
            Assert.AreEqual(100, contaOrigem.saldo);
            Assert.AreEqual(400, contaDestino.saldo);
        }

        [TestMethod]
        public void Transferir_SaldoInsuficiente_CancelaTransferencia()
        {
            // Arrange
            string contaOrigemId = "123";
            string contaDestinoId = "456";
            decimal valorTransacao = 100m;

            var contaOrigem = new ContasSaldoModel(contaOrigemId, 50);
            var contaDestino = new ContasSaldoModel(contaDestinoId, 300);

            mockAcessoDadosDB.Setup(db => db.getConta(contaOrigemId)).Returns(contaOrigem);
            mockAcessoDadosDB.Setup(db => db.getConta(contaDestinoId)).Returns(contaDestino);
            
            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                transacaoFinanceira.transferir(2, contaOrigemId, contaDestinoId, valorTransacao);
                var result = sw.ToString().Trim();

                // Assert
                Assert.AreEqual("Transacao numero 2 foi cancelada por falta de saldo", result);
            }
        }
    }
}
