using ClassLibrary1.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContex _db;
        public UnitOfWork(ApplicationDbContex db) 
        {
            _db = db;
            category = new CategoryRepository(_db);
            CoverType=new CoverTypeRepository(_db);
            product=new ProductRepository(_db);
        }
        public ICategoryRepository category { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; } 
       public IProductRepository product { get; private set; }



    public void Save()
        {
      _db.SaveChanges();
        }
    }
}
