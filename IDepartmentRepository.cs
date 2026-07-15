using System.Collections.Generic;

namespace DapperinClass
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void InsertDepartment (string departmentName);
    }
}
