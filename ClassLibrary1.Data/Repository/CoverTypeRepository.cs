using ClassLibrary1.Data.Repository.IRepository;
using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Repository
{
 public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContex _db;
            public CoverTypeRepository(ApplicationDbContex db): base(db)
        {
            _db = db;
        }

       
        void ICoverTypeRepository.Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
      
    }
}
