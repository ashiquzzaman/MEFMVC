using AzR.Core.Models;
using System.Collections.Generic;

namespace AzR.Core.Services
{
    public interface IEmployeeTypeService
    {
        List<EmployeeType> GetAll();
    }
}
