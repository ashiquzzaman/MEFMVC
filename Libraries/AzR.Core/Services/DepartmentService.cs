using AzR.Core.Models;
using AzR.Core.Repositories;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace AzR.Core.Services
{
    [Export(typeof(IDepartmentService))]
    public class DepartmentService : IDepartmentService
    {

        [Import]
        private IAppContext<ApplicationDbContext> _dbContext;
        [ImportingConstructor]
        public DepartmentService(IAppContext<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Department> GetAll()
        {
            //return _dbContext.Repository<Department>().All().ToList();
            return _dbContext.AzRRepository<Department>().All().ToList();

        }


    }
}
