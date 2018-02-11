using AzR.Core.Models;
using AzR.Core.Repositories;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace AzR.Core.Services
{
    [Export(typeof(IEmployeeService))]
    public class EmployeeService : IEmployeeService
    {

        [Import]
        IRepository<Employee> _employee;
        [ImportingConstructor]
        public EmployeeService(IRepository<Employee> employee)
        {
            _employee = employee;
        }

        public List<Employee> GetAll()
        {
            return _employee.All().ToList();
        }
    }
}
