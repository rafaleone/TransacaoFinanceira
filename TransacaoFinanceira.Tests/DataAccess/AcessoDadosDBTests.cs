using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransacaoFinanceira.DataAccess;
using TransacaoFinanceira.Model;

namespace TransacaoFinanceira.Tests.DataAccess
{
    [TestClass]
    public class AcessoDadosDBTests
    {
        private AcessoDadosDB acessoDadosDB;

        [TestInitialize]
        public void Setup()
        {
            // Cria uma nova instância de AcessoDadosDB antes de cada teste
            acessoDadosDB = new AcessoDadosDB();
        }

        [TestMethod]
        public void GetConta_ContaExiste_RetornaConta()
        {
            // Arrange
            string contaId = "938485762";

            // Act
            ContasSaldoModel resultado = acessoDadosDB.getConta(contaId);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(contaId, resultado.conta);
            Assert.AreEqual(180, resultado.saldo);
        }

        [TestMethod]
        public void GetConta_ContaNaoExiste_RetornaNull()
        {
            // Arrange
            string contaId = "999999999";

            // Act
            ContasSaldoModel resultado = acessoDadosDB.getConta(contaId);

            // Assert
            Assert.IsNull(resultado);
        }
    }
}
