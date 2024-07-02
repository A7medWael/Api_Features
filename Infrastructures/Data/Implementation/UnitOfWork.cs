using Cores.Entities;
using Cores.Interfaces;
using Infrastructure.Data.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Data.Implementation
{
    public class UnitOfWork:IUnitOfWork

    {
        private readonly ApplicationDbContext _context;
        //private Hashtable _Repositories;
     

        public IproductRepository ProdtRepos { get; private set; }

        public UnitOfWork(IproductRepository iproductRepository, ApplicationDbContext context)
        {
            ProdtRepos = new productRepository(context);
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Compelete()
        {
            return _context.SaveChanges();
        }





        //public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        //{
        //   if(_Repositories == null)
        //        _Repositories= new Hashtable();
        //   var type=typeof(TEntity).Name;
        //    if (!_Repositories.ContainsKey(type))
        //    {
        //        var repositorytype = typeof(GenericRepository<>);
        //        var repositoryinstance=Activator.CreateInstance(repositorytype.MakeGenericType(typeof(TEntity)),_context);
        //        _Repositories.Add(type, repositoryinstance);
        //    }
        //    return (IGenericRepository<TEntity>)_Repositories[type];
        //}
    }
}
