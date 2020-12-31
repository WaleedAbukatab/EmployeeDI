using Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorys
{
    public class Repository <T> : IRepository<T> where T : BaseEntity
    {

        #region VARIABLE & CONTEXT
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        #endregion

        #region CONSTRUCTOR
        public Repository(IDbContext context)
        {
            this._context = context;
        }
        #endregion

        #region GET BY ID
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }
        #endregion

        #region INSERT
        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }
        #endregion

        #region UPDATE
        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }
        #endregion

        #region DELETE
        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }
        #endregion

        #region TABLE
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
        #endregion

        #region ENTITIES
        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
        #endregion
    }
}
