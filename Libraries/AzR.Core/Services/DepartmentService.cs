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
        private IRepository<Department> _department;
        [ImportingConstructor]
        public DepartmentService(IRepository<Department> department)
        {
            _department = department;
        }
        public List<Department> GetAll()
        {
            return _department.All().ToList();

        }


    }
}
