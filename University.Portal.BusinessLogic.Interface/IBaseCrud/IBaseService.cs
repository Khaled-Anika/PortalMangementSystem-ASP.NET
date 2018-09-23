using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.BusinessLogic.Interface.IBaseCrud
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        bool Insert(TEntity entity);
        bool Update<Tkey>(TEntity entity, Tkey id);
        bool Remove<TKey>(TKey id);
        IEnumerable<TEntity> GetAll();
        TEntity Get<TKey>(TKey id);
    }
}
