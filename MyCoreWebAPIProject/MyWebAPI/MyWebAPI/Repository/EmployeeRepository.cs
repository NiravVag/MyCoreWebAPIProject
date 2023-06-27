using MyWebAPI.Context;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee _object)
        {
            var data = await _context.Employees.AddAsync(_object);
            _context.SaveChanges();
            return data.Entity;
        }

        public void Delete(Employee _object)
        {
            _context.Remove(_object);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return _context.Employees.Where(x => x.IsDeleted != false).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee GetById(int Id)
        {
            return _context.Employees.Where(x => x.IsDeleted == false && x.EmployeeId == Id).FirstOrDefault();
        }

        public void Update(Employee _object)
        {
            _context.Employees.Update(_object);
            _context.SaveChanges();
        }
    }
}
