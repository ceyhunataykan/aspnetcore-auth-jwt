using CA.ProductCoreApp.DataAccess.Interfaces;
using CA.ProductCoreApp.Entities.Concrete;

namespace CA.ProductCoreApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductDal
    {
    }
}
