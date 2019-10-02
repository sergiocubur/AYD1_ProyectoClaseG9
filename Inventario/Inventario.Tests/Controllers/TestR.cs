using System;
using NUnit.Framework;

namespace Inventario.Tests.Controllers
{
    
    public class TestRestarME
    {
        [Test]
        public void TestRestaCero()
        {
            var rme = new MODSAL_RestaMalEstado();
            
            var result = rme.consulta("producto1", 0);

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void TestRestaSinNombre()
        {
            var rme = new MODSAL_RestaMalEstado();

            var result = rme.consulta("", 1);

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void TestSelect()
        {
            var me = new MODSAL_RestaMalEstado();
            var result = me.consultaSelect("Producto1");
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void TestInsert()
        {
            var me = new MODSAL_RestaMalEstado();
            var result = me.consulta("Producto1", 100);
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void TestConnection()
        {
            var me = new MODSAL_RestaMalEstado();
            var result = me.consulta("Producto3", 200);
            Assert.AreEqual(result, 4);
        }

        [Test]
        public void TestUpdate()
        {
            var me = new MODSAL_RestaMalEstado();
            var result = me.consultaUp(200, "Producto3");
            Assert.AreEqual(result, 4);
        }
    }
}
