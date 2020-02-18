using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WesleyTesteGol.Dados;

namespace WesleyTesteGol.Negocio
{
    public interface IUow
    {
        IRepository<Comum.Entidade.POCO.Airplane> Avioes { get; }
        
        void Salvar();
    }
}
