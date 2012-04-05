using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dry.Services
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        void Save(TEntity entity);
    }
}
