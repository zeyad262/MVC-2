using DataAcessLayer.Models;

namespace BusinessLogicLayer.Repositories
{
    public interface IDepartmentRepositories
    {
        int Create(Department entity);
        Department? Get(int id);
        IEnumerable<Department> GetAll();
        int Remove(Department entity);
        int Update(Department entity);
    }
}