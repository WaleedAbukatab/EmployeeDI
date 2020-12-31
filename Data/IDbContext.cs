using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Core;

namespace Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
