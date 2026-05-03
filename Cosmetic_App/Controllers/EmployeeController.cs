using Cosmetic_App.Common.Entity;
using Cosmetic_App.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmetic_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        public EmployeeController(IEmployeeService userService) : base(userService)
        {
        }
    }
}
