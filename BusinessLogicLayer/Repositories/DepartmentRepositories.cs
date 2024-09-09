using DataAcessLayer.Data;
using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class DepartmentRepositories : IDepartmentRepositories
    {
        private readonly DataContext _datacontext;
        public DepartmentRepositories(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public Department? Get(int id)
        {
            return _datacontext.Departments.Find(id);
        }
        public IEnumerable<Department> GetAll()
        {
            return _datacontext.Departments.ToList();
        }
        public int Create(Department entity)
        {
            _datacontext.Departments.Add(entity);
            return _datacontext.SaveChanges();
        }
        public int Update(Department entity)
        {
            _datacontext.Departments.Update(entity);
            return _datacontext.SaveChanges();
        }
        public int Remove(Department entity)
        {
            _datacontext.Departments.Remove(entity);
            return _datacontext.SaveChanges();
        }
    }
}
