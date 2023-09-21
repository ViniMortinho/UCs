using Projeto_TESTE;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SomarDoisNumeros()
        {
            //Arrange - Preparação
            string pNum = "Cai";
            string sNum = "que";
            string rNum = "Caique";
            //Act - Ação
            var resultado = Operacoes.Somar(pNum, sNum);
            //Assert - Comparação
            Assert.AreEqual(rNum, resultado);
        }
    }
}