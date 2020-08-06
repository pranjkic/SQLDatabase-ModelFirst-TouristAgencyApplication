using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Repository.DB.DAO
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(object id);
        List<TEntity> GetAll();
        bool Insert(TEntity entity);
        bool Delete(object id);
        void Update(TEntity entityToUpdate);
    }
}
