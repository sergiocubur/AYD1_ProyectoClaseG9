using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inventario.Tests.Controllers
{
    [TestClass]
    public class TestRestarME
    {
        [TestMethod]
        public void TestRestaCero()
        {
            var rme = new MODRES_MEstado();

            var result = rme.consulta("producto1", 0);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestRestaSinNombre()
        {
            var rme = new MODRES_MEstado();

            var result = rme.consulta("", 1);

            Assert.AreEqual(result, 0);
        }
        
        [TestMethod]
        public void TestInsert()
        {
            var me = new MODRES_MEstado();
            var result = me.consulta("Producto1", 100);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestConnection()
        {
            var me = new MODRES_MEstado();
            var result = me.consulta("Producto3", 200);
            Asset.AreEqual(result, 4);
        }
    }
}
