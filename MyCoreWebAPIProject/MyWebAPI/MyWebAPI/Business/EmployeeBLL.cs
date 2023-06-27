using MyWebAPI.Model;
using MyWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Business
{
    public class EmployeeBLL : IEmployeeAFL
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeBLL(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> AddEmployee(Employee _object)
        {
            return await _employeeRepo.Create(_object);
        }

        public bool DeleteEmployee(Employee _object)
        {
            try
            {
                var data = _employeeRepo.GetAll().Where(x => x.EmployeeId == _object.EmployeeId).ToList();
                foreach (var item in data)
                {
                    _employeeRepo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool EditEmployee(Employee _object)
        {
            try
            {
                var data = _employeeRepo.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in data)
                {
                    _employeeRepo.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public Employee GetEmployeeById(int Id)
        {
            return _employeeRepo.GetAll().Where(x => x.IsDeleted != false && x.EmployeeId == Id).FirstOrDefault();
        }

        public IQueryable<Employee> GetEmployeeList()
        {
            try
            {
                return (IQueryable<Employee>)_employeeRepo.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
