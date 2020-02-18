using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WesleyTesteGol.Teste.NegocioTeste
{
    [TestClass]
    public class NegocioTesteUnit
    {
        [TestMethod]
        public void TestarRetorno()
        {
            var avioes = new Negocio.ProcessoDeNegocio().GetAvioes();
        }
    }
}
