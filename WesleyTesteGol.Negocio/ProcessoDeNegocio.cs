using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesleyTesteGol.Negocio
{
    public class ProcessoDeNegocio
    {
        private readonly IUow uow;
        
        public ProcessoDeNegocio()
        {
            this.uow = new Uow();            
        }
        
        public List<Comum.Entidade.POCO.Airplane> GetAvioes() 
        {
            return this.uow.Avioes.GetAll().ToList();
        }

        public Comum.Entidade.POCO.Airplane GetAviao(int id) 
        {
            return this.uow.Avioes.GetById(id);
        }

        public void Delete(int id) 
        {
            this.uow.Avioes.DeleteById(this.GetAviao(id));
            this.uow.Salvar();
        }

        public void Update(Comum.Entidade.POCO.Airplane entity) 
        {
            this.uow.Avioes.Update(entity);
            this.uow.Salvar();
        }

        public void Insert(Comum.Entidade.POCO.Airplane entity) 
        {
            this.uow.Avioes.Insert(entity);
            this.uow.Salvar();
        }
    }
}
