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
        public ExportFactory<IAppContext> Context { get; set; }
        protected IAppContext DbContext
        {
            get { return Context.CreateExport().Value; }
        }

        public List<Employee> GetAll()
        {
            return DbContext.Repository<Employee>().All().ToList();
        }
    }
}
