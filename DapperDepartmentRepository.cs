using System.Data;
using System.Collections.Generic;
using Dapper;


namespace DapperinClass
{
    public class DapperDepartmentRepository : IDepartmentRepository 
    {
        private readonly IDbConnection _dbConnection;
        public DapperDepartmentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            string sql = "SELECT department_id AS DepartmentID, department_name AS DepartmentName FROM departments";
            return _dbConnection.Query<Department>(sql);
        }
        public void InsertDepartment(string departmentName)
        {
            string sql = "INSERT INTO departments (department_name) VALUES (@DepartmentName)";
            _dbConnection.Execute(sql, new { DepartmentName = departmentName });
        }
    }
}
