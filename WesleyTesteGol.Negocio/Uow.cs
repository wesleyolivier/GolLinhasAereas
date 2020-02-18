using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WesleyTesteGol.Comum.Entidade.POCO;
using WesleyTesteGol.Dados;

namespace WesleyTesteGol.Negocio
{
    public class Uow : IUow
    {
        private DbContext dbContext;
        

        public Uow()
        {
            this.dbContext = new AvioesDatabaseEntities();
        }

        public IRepository<Comum.Entidade.POCO.Airplane> Avioes
            => new Repository<Comum.Entidade.POCO.Airplane>(this.dbContext);

        public void Salvar()
        {
            this.dbContext.SaveChanges();
        }
    }
}
