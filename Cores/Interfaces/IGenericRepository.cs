using Cores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Interfaces
{
    public interface IGenericRepository< T> where T : BaseEntity
    {
      Task<IReadOnlyList<T>> GetAsync(Expression<Func<T,bool>>?Perdicate=null,string?includeWord=null);
        Task<T> GetbyIdAsync(Expression<Func<T, bool>>? Perdicate = null, string? includeWord = null);
        void Add (T entity);
        void Update (T entity);
        void Delete (T entity);
       
    }
}
