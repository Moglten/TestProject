using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.DomainLayer.Interfaces;
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Formats.Tar;

namespace ClientProductApp.InfrastructureLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbEntity;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbEntity = dbContext.Set<T>();
        }

        public IList<T> GetAll()
        {
            return _dbEntity.AsNoTracking().ToList<T>();
        }

        public T Get(int id)
        {
            return _dbEntity.AsNoTracking().FirstOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbEntity.Add(entity);
            _dbContext.SaveChanges();
        }

        public void InsertRange(IList<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            _dbEntity.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbEntity.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbEntity.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteRange(IList<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            _dbEntity.RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> GetEntityIQueryable()
        {
            return _dbEntity.AsQueryable();
        }

        public IEnumerable<T> GetEntityIEnumrable()
        {
            return _dbEntity.AsEnumerable();
        }

        public DbSet<T> GetDbSet()
        {
            return _dbEntity;
        }

    }
}
