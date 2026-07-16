using Microsoft.Extensions.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
namespace DapperinClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            IDepartmentRepository repo = new DapperDepartmentRepository(dbConnection);

            // insert a test department
            repo.InsertDepartment("Test Department");

            // Get all departments and display them
            var departments = repo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine($"Department ID: {department.DepartmentID}, Name: {department.DepartmentName}");
            }
            var productRepo = new DapperProductRepository(dbConnection);

            productRepo.CreateProduct("Test Product", 9.99, 1);

            var products = productRepo.GetAllProducts();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
            productRepo.UpdateProduct(1, "Updated Product", 12.99, 1);
            productRepo.DeleteProduct(2);

        }
    }
}
