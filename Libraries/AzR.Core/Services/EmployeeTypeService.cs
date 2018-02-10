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
        private IAppContext<TestDbContext> _dbContext;


        [ImportingConstructor]
        public EmployeeTypeService(IAppContext<TestDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public List<EmployeeType> GetAll()
        {
            return _dbContext.Repository<EmployeeType>().All().ToList();
        }


    }
}
