using AzR.Core.Models;
using AzR.Core.Repositories;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace AzR.Core.Services
{
    [Export(typeof(IEmployeeTypeService))]
    public class EmployeeTypeService : IEmployeeTypeService
    {

        [Import]
        private IAzRRepository<TestDbContext, EmployeeType> _employeeType;
        [ImportingConstructor]
        public EmployeeTypeService(IAzRRepository<TestDbContext, EmployeeType> employeeType)
        {
            _employeeType = employeeType;
        }
        public List<EmployeeType> GetAll()
        {
            return _employeeType.All().ToList();
        }
    }
}
