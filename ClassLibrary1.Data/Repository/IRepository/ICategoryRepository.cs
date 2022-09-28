using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Repository.IRepository
{
   public interface ICategoryRepository:IRepository<category>
    {
        void Update(category obj);
       
    }
}
