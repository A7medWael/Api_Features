using Cores.Entities;
using Cores.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Data.Implementation
{
  
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbset;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset=_context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
          
        }

        public void Delete(T entity)
        {
           _dbset.Remove(entity);
           
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T,bool>>? Perdicate=null,string ? includeWord = null)
        {
            IQueryable<T> query = _dbset;
            if(Perdicate!= null)
            {
                query = query.Where(Perdicate);
            }
            if(includeWord!= null)
            {
                foreach(var item in includeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(item);
                }
            }
           
            return await query.ToListAsync();
        }

        public async Task<T> GetbyIdAsync(Expression<Func<T,bool>>? Perdicate=null,string? includeWord=null)
        {
            IQueryable<T> query = _dbset;
            if (Perdicate != null)
            {
                query=query.Where(Perdicate);
            }
            if (includeWord!= null)
            {
                foreach(var item in includeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(item);
                }
               
            }
            return await query.SingleOrDefaultAsync();
        }
       

        public void Update(T entity)
        {
           _dbset.Update(entity);
           
        }
    }
}
