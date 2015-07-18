using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDTest.WSExpediente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace STDTest
{
    [TestClass]
    class TestExpediente
    {
        [TestMethod]
        public void TextCorrecto()
        {
            //1. Instanciar el objeto que contiene el metodo a probar

            WSExpediente.ExpedienteClient proxy = new WSExpediente.ExpedienteClient();

            //2. Invocar el metodo a prograr
            WSExpediente.Expediente expediente = new WSExpediente.Expediente();
            expediente.codigoSolicitante = 1;
            expediente.codigoTramite = 1;
            expediente.Estado = 1;

            bool resultado = proxy.Agregar(ref expediente);

            //3. Verificar / Validar resultados

            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void TestError()
        {
            //1. Instanciar el objeto que contiene el metodo a probar

            WSExpediente.ExpedienteClient proxy = new WSExpediente.ExpedienteClient();

            //2. Invocar el metodo a prograr
            WSExpediente.Expediente expediente = new WSExpediente.Expediente();
            expediente.codigoSolicitante = 2;
            expediente.codigoTramite = 2;
            expediente.Estado = 1;

            bool resultado = proxy.Agregar(ref expediente);

            //3. Verificar / Validar resultados

            Assert.AreEqual(false, resultado);
        }
    }
}