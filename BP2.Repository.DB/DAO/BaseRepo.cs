using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Repository.DB.DAO
{
    public abstract class BaseRepo<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public bool Delete(object id)
        {
            try
            {
                using (var db = new ModelBP2Container())
                {
                    DbSet<TEntity> dbSet = db.Set<TEntity>();
                    TEntity entityToDelete = db.Set<TEntity>().Find(id);
                    db.Entry(entityToDelete).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public TEntity FindById(object id)
        {
            using (var db = new ModelBP2Container())
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetAll()
        {
            using (var db = new ModelBP2Container())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public bool Insert(TEntity entity)
        {
            try
            {
                using (var db = new ModelBP2Container())
                {
                    db.Set<TEntity>().Add(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public void Update(TEntity entityToUpdate)
        {
            using (var db = new ModelBP2Container())
            {
                db.Set<TEntity>().Attach(entityToUpdate);
                db.Entry(entityToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
