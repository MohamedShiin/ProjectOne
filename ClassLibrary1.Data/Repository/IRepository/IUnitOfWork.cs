using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository category { get; }
        ICoverTypeRepository CoverType { get; }
        IProductRepository product { get; }

        void Save();
    }
}
