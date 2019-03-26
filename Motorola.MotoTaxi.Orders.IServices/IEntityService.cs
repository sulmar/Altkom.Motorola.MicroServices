using System.Collections;
using System.Collections.Generic;

namespace Motorola.MotoTaxi.Orders.IServices
{
    public interface IEntityService<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
    }
}
