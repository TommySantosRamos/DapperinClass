using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperinClass
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(string name, double price, int categoryID);
        void UpdateProduct(int productId, string name, double price, int categoryID);
        void DeleteProduct(int productId);
    }
}
