using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Business
{
    public interface IEmployeeAFL
    {
        public Task<Employee> AddEmployee(Employee _object);

        public bool EditEmployee(Employee _object);

        public IQueryable<Employee> GetEmployeeList();

        public Employee GetEmployeeById(int Id);

        public bool DeleteEmployee(Employee _object);
    }
}
