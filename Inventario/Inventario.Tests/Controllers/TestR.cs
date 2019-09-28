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
            var rme = new MODSAL_RestaMalEstado();

            var result = rme.consulta("producto1", 0);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestRestaSinNombre()
        {
            var rme = new MODSAL_RestaMalEstado();

            var result = rme.consulta("", 1);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestSelect()
        {
            var me = new MODSAL_RestaMalEstado();
            var result = me.consulta("Producto1", 100);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestInsert()
        {
            var me = new MODSAL_RestaMalEstado();
            var result = me.consulta("Producto1", 100);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestConnection()
        {
            var me = new MODSAL_RestaMalEstado();
            var result = me.consulta("Producto3", 200);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var me = new MODSAL_RestaMalEstado();
            var result = me.consultaUp("Producto3", 200);
            Assert.AreEqual(result, 4);
        }
    }
}
