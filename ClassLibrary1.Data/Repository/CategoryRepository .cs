using ClassLibrary1.Data.Repository.IRepository;
using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Repository
{
    public class CategoryRepository : Repository<category>, ICategoryRepository
    {
        private ApplicationDbContex _db;
            public CategoryRepository(ApplicationDbContex db): base(db)
        {
            _db = db;
        }

       


        public void Update(category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
