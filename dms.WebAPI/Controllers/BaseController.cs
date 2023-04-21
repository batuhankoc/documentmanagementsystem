using dms.Contract.ResponseContracts;
using Microsoft.AspNetCore.Mvc;

namespace dms.WebAPI.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ApiResponse<T>(ApiResponse<T> response)
        {
            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
