using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesleyTesteGol.Dados
{
    public interface IRepository <T> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        void Insert(T entity);

        void Update(T entity);

        void DeleteById(T entity);
    }
}
