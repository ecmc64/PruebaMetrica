using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebaUnitaria
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        public void PruebaChangeString()
        {
            var cadena = "abcde";
            var obj = new Prueba1.ChangeString();
            var resultado = obj.Build(cadena);
            Assert.AreEqual("bcdef", resultado);
        }

        [TestMethod]
        public void PruebaOrderRange()
        {
            var lista = new List<string> { "9", "8", "7", "6", "5", "4", };
            var obj = new Prueba1.OrderRange();
            var resultado = obj.Build(lista);
            Assert.AreEqual("[4,6,8][5,7,9]", resultado);
        }

        [TestMethod]
        public void PruebaMoneyParts()
        {
            var obj = new Prueba1.MoneyParts();
            var listaResultado = obj.Build("0.5");
            Assert.AreEqual(listaResultado.Count, 13);
        }
    }
}
