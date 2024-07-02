using Cores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        //IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        public IproductRepository ProdtRepos { get;  }
        int Compelete();
    }
}
