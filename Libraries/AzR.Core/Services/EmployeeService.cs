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
        //[Import]
        //private IRepository<Employee> _employee;
        //[ImportingConstructor]
        //public EmployeeService(IRepository<Employee> employee)
        //{
        //    _employee = employee;
        //}
        //public List<Employee> GetAll()
        //{
        //    return _employee.All().ToList();
        //}


        //[Import]
        //private IAppContext _dbContext;
        //[ImportingConstructor]
        //public EmployeeService(IAppContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public List<Employee> GetAll()
        //{
        //    return _dbContext.Repository<Employee>().All().ToList();
        //}

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
