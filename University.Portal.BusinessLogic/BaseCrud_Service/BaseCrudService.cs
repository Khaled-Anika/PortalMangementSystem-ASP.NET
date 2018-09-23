using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.Infrastructure;

namespace University.Portal.BusinessLogic.BaseCrud_Service
{
    public abstract class BaseCrudService<T> : IBaseService<T> where T : class
    {
        private readonly DbContext _context;
        protected DbContext Context => this._context;
        UMSDbContext db = new UMSDbContext();

        public BaseCrudService(DbContext Context)
        {
            _context = Context;
        }

        //Get All The Value
        public IEnumerable<T> GetAll()
        {
            try
            {
                //return _context.Set<T>().ToList();
                return db.Set<T>().ToList();
            }
            catch (Exception Ex)
            {

                return null;
            }
        }


        //Get By ID
        public T Get<TKey>(TKey id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        //Insert Entity 
        public virtual bool Insert(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }


        //Update Entity
        public bool Update<Tkey>(T entity, Tkey id)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        
        //Remove Entity
        public bool Remove<TKey>(TKey id)
        {
            try
            {
                T entity = _context.Set<T>().Find(id);
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

       
    }
}
