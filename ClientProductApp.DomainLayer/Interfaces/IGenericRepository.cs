using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProductApp.DomainLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IList<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void InsertRange(IList<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IList<T> entities);
        public IQueryable<T> GetEntityIQueryable();
        public IEnumerable<T> GetEntityIEnumrable();
        public DbSet<T> GetDbSet();


    }
}
