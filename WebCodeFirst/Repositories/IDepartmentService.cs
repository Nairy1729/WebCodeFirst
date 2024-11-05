using WebCodeFirst.Models;

namespace WebCodeFirst.Repositories
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        int AddNewDepartment(Department department);
        string UpdateDepartment(Department department);
        string DeleteDepartment(int id);
    }
}
