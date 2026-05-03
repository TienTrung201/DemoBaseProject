using Cosmetic_App.Common.Entity;
using NTTRUNG_BaseWebAPI_Infastructurce.Repository.Base;

namespace Cosmetic_App.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository():base()  
        {
        }
    }
}
