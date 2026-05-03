using Cosmetic_App.Common.Entity;
using Cosmetic_App.Repository;
using NTTRUNG_BaseWebAPI_Domain.Interface.Base;

namespace Cosmetic_App.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
        }
    }
}
