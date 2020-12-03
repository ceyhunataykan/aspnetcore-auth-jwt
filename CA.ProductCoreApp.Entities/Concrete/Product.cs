using CA.ProductCoreApp.Entities.Interfaces;

namespace CA.ProductCoreApp.Entities.Concrete
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
