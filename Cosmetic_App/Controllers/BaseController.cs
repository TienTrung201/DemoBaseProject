using Cosmetic_App.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmetic_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        protected readonly IBaseService<TEntity> _baseService;

        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Trả về số bản ghi thay đổi</returns>
        /// CreatedBy: NTTrung (13/07/2023)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _baseService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var result = await _baseService.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

    }
}
