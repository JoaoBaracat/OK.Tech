using Microsoft.AspNetCore.Mvc;
using OK.Tech.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OK.Tech.Api.Controllers
{    
    [Route("Products")]
    public class ProductsController : MainController
    {

        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> GetProducts()
        {

            return CustomResponse(new List<ProductViewModel>());
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<ProductViewModel> GetProductById(Guid id)
        {
            var prod = new ProductViewModel()
            {
                Id = new Guid(),
                Name = "Teclado"
            };
            return CustomResponse(prod);
        }

        [HttpPost("{id:Guid}")]
        public ActionResult<ProductViewModel> CreateProduct (Guid id, ProductViewModel productViewModel)
        {            
            //if (!ModelState.IsValid)
            //{
            //    var erros = ModelState.Values.SelectMany(err => err.Errors).FirstOrDefault().ErrorMessage;
                
            //    //return BadRequest(new
            //    //{
            //    //    success = false,
            //    //    error = erros,
            //    //    data = productViewModel
            //    //});

            //    return CustomResponse(ModelState, productViewModel);
            //}

            return CustomResponse(ModelState, productViewModel);
        }

        [HttpPut("{id:Guid}")]
        public ActionResult<ProductViewModel> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            return CustomResponse(ModelState, productViewModel);
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult<ProductViewModel> DeleteProduct(Guid id)
        {
            var prod = new ProductViewModel()
            {
                Id = new Guid(),
                Name = "Teclado"
            };
            return CustomResponse(prod);
        }

    }
}