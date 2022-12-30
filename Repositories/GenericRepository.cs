using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Data;
using OrdersManager.Domain;
using OrdersManager.Orchestrators.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace OrdersManager.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private DbSet<T> _entities;

        private string _errorMessage = string.Empty;

        private bool _isDisposed;
        private OrdersManagerDbContext _context { get; set; }

       
        public GenericRepository(OrdersManagerDbContext context)
        {
            _isDisposed = false;
           _context = context;
        }

        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities =_context.Set<T>()); }
        }
        public virtual T GetByID(int? id)
        {
            return Entities.Find(id);
        }

        public virtual T Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Entities.Add(entity);
                if (_context == null || _isDisposed)
                    _context = new OrdersManagerDbContext();
                _context.SaveChanges();


                return entity;

            }
           
            catch (Exception e)
            {
                throw;
            }

        }

        public virtual T Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (_context == null || _isDisposed)
                    _context = new OrdersManagerDbContext();
                SetEntryModified(entity);
                return entity;
                _context.SaveChanges();
             }
            catch (Exception e)
            {
                throw;
            }
        }

        public virtual void SetEntryModified(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (_context == null || _isDisposed)
                    _context = new OrdersManagerDbContext();
                Entities.Remove(entity);
                _context.SaveChanges();
            }

            catch (Exception e)
            {
                throw;
            }
        }


        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Entities;
            if (filter != null)
            {
                query = query.AsNoTracking().Where(filter);
            }
            return query;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            _isDisposed = true;
        }
    }
}
