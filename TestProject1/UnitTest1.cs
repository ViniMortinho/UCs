using Projeto_TESTE;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SomarDoisNumeros()
        {
            //Arrange - Prepara��o
            string pNum = "Cai";
            string sNum = "que";
            string rNum = "Caique";
            //Act - A��o
            var resultado = Operacoes.Somar(pNum, sNum);
            //Assert - Compara��o
            Assert.AreEqual(rNum, resultado);
        }
    }
}