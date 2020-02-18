using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WesleyTesteGol.Comum.Entidade.POCO;

namespace WesleyTesteGol.Dados
{
    public class Repository <T> : IRepository<T> where T : class
    {
        private DbContext dbContext;
        private DbSet<T> dbset;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbset = this.dbContext.Set<T>();
        }

        public void DeleteById(T entity)
        {
            DbEntityEntry dbEntityEntry = this.dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.dbset.Attach(entity);
                this.dbset.Remove(entity);
            }
        }

        public IQueryable<T> GetAll()
        {
            return this.dbset;
        }

        public T GetById(int id)
        {
            return this.dbset.Find(id);
        }

        public void Insert(T entity)
        {
            DbEntityEntry dbEntityEntry = this.dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)

            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                this.dbset.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = this.dbContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                this.dbset.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
