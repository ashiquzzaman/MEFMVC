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

        //[Import]
        //private IAppContext<TestDbContext> _dbContext;
        [Import]
        private IRepository<EmployeeType> _employeeType;

        [ImportingConstructor]
        public EmployeeTypeService(IRepository<EmployeeType> employeeType)
        {
            _employeeType = employeeType;
        }
        public List<EmployeeType> GetAll()
        {
            return _employeeType.All().ToList();
        }


    }
}
