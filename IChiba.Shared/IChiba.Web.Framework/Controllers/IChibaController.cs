using IChiba.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;

namespace IChiba.Web.Framework.Controllers
{
    public abstract partial class IChibaController : ControllerBase
    {
        protected IChibaController(
            )
        {

        }

        protected virtual IActionResult InvalidModelResult()
        {
            return Ok(new IChibaResult
            {
                success = false,
                errors = ModelState.GetErrors()
            });
        }
    }
}
