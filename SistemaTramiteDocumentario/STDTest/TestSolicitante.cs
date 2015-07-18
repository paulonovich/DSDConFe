using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDTest.WSSolicitante;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace STDTest
{
    [TestClass]
    class TestSolicitante
    {
        [TestMethod]
        public void TextCorrecto()
        {
            //1. Instanciar el objeto que contiene el metodo a probar

            WSSolicitante.SolicitanteClient proxy = new WSSolicitante.SolicitanteClient();

            //2. Invocar el metodo a prograr
            WSSolicitante.Solicitante solicitante = new WSSolicitante.Solicitante();
            solicitante.nombre = "Paul";
            solicitante.apellido = "Jimenez";
            solicitante.correo = "paul.jimenez@mdp.com.pe";
            solicitante.direccion = "SD";
            solicitante.dni = "46603204";

            int codigo = 0;
            string resultado = proxy.AgregarSolicitante(solicitante, ref codigo);

            //3. Verificar / Validar resultados

            Assert.AreEqual(1, codigo);
        }

        [TestMethod]
        public void TestError()
        {
            //1. Instanciar el objeto que contiene el metodo a probar

            WSSolicitante.SolicitanteClient proxy = new WSSolicitante.SolicitanteClient();

            //2. Invocar el metodo a prograr
            WSSolicitante.Solicitante solicitante = new WSSolicitante.Solicitante();
            solicitante.nombre = "Marcos";
            solicitante.apellido = "Levano";
            solicitante.correo = "marco.lear";
            solicitante.direccion = "";
            solicitante.dni = "43434532";

            int codigo = 0;
            string resultado = proxy.AgregarSolicitante(solicitante, ref codigo);

            //3. Verificar / Validar resultados

            Assert.AreEqual("", resultado);
        }
    }
}