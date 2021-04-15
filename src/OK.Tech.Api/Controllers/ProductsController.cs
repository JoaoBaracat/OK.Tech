using Microsoft.AspNetCore.Mvc;
using OK.Tech.Api.Models;
using System.Collections.Generic;

namespace OK.Tech.Api.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> GetProducts()
        {

            return Ok(new List<ProductViewModel>());
        }
    }
}