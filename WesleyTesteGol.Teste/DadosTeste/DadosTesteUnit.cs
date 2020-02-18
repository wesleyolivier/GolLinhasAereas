using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WesleyTesteGol.Teste.DadosTeste
{
    [TestClass]
    public class DadosTesteUnit
    {
        [TestMethod]
        public void TestarRetornoTodos()
        {
            Dados.Repository<Comum.Entidade.POCO.Airplane> air =
                new Dados.Repository<Comum.Entidade.POCO.Airplane>(new Dados.ModeloGolNewEntities());

            var avioes = air.GetAll().ToList();            
        }

        [TestMethod]
        public void TestarRetornoPorId()
        {
            Dados.Repository<Comum.Entidade.POCO.Airplane> air =
                new Dados.Repository<Comum.Entidade.POCO.Airplane>(new Dados.ModeloGolNewEntities());

            var avioes = air.GetById(2);
        }        
    }
}
