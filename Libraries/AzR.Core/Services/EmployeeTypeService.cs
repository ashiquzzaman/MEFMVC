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


        //[ImportingConstructor]
        //public EmployeeTypeService(IAppContext<TestDbContext> dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public List<EmployeeType> GetAll()
        //{
        //    return _dbContext.AzRRepository<EmployeeType>().All().ToList();
        //}

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
