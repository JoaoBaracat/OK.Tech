using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OK.Tech.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace OK.Tech.Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly List<string> _errors;
        public MainController()
        {
            _errors = new List<string>();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (!IsOperationValid())
            {
                var errorMessage = ModelState.Values.SelectMany(err => err.Errors).FirstOrDefault().ErrorMessage;
                return BadRequest(new { success = false, data = result, errors = _errors});
            }

            return Ok(new { success = true, data = result });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState, object result = null)
        {
            if (!modelState.IsValid)
            {
                var errorMessage = ModelState.Values.SelectMany(err => err.Errors).Select(msg => msg.ErrorMessage).ToList();
                _errors.AddRange(errorMessage);
                return BadRequest(new { success = false, data = result, errors = _errors });
            }
            return Ok(new { success = true, data = result });

        }

        protected bool IsOperationValid()
        {

            return !_errors.Any();
        }


    }
}