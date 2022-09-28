using ClassLibrary1.Data.Repository.IRepository;
using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Repository
{
 public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContex _db;
            public ProductRepository(ApplicationDbContex db): base(db)
        {
            _db = db;
        }

       
    

        void IProductRepository.Update(Product obj)
        {
      var objFromDb= _db.products.FirstOrDefault(u=>u.Id==obj.Id);  
            if(objFromDb!=null)
            {
         objFromDb.Title=obj.Title;
         objFromDb.ISBN=obj.ISBN;
                objFromDb.Description=obj.Description;
                objFromDb.Price=obj.Price;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Prise50 = obj.Prise50;
                objFromDb.Description=obj.Description;
                objFromDb.Author=obj.Author;
                objFromDb.CategoryId=obj.CategoryId;
                objFromDb.CoverTypeId=obj.CoverTypeId;
                if(obj.ImageUrl!=null)
                {
                    objFromDb.ImageUrl=obj.ImageUrl;
                }

                     
            }
        }
    }
}
