using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Repository
{
    public interface IEmployeeRepo
    {
        public Task<Employee> Create(Employee _object);

        public void Update(Employee _object);

        public IEnumerable<Employee> GetAll();

        public Employee GetById(int Id);

        public void Delete(Employee _object);
    }
}
