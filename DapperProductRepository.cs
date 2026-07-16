using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperinClass
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public DapperProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            string sql = "SELECT product_id AS ProductID, name AS Name, price AS Price, category_id AS CategoryID FROM products";
            return _dbConnection.Query<Product>(sql);
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            string sql = "INSERT INTO products (name, price, category_id) VALUES (@Name, @Price, @CategoryID)";
            _dbConnection.Execute(sql, new { Name = name, Price = price, CategoryID = categoryID });
        }
        public void UpdateProduct(int productId, string name, double price, int categoryID)
        {
            string sql = "UPDATE products SET name = @Name, price = @Price, category_id = @CategoryID WHERE product_id = @ProductId";
            _dbConnection.Execute(sql, new { Name = name, Price = price, CategoryID = categoryID, ProductId = productId });
        }
        public void DeleteProduct(int productId)
        {
            string sql = "DELETE FROM products WHERE product_id = @ProductId";
            _dbConnection.Execute(sql, new { ProductId = productId });
        }
    }
}
