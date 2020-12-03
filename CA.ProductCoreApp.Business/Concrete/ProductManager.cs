using CA.ProductCoreApp.Business.Interfaces;
using CA.ProductCoreApp.DataAccess.Interfaces;
using CA.ProductCoreApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.ProductCoreApp.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {
        }
    }
}
