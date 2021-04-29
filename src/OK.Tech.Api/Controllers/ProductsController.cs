using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OK.Tech.Api.Models;
using OK.Tech.Domain.Apps;
using OK.Tech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OK.Tech.Api.Controllers
{    
    [Route("Products")]
    public class ProductsController : MainController
    {
        private readonly IProductApp _productApp;
        private readonly IMapper _mapper;

        public ProductsController(IProductApp productApp, IMapper mapper)
        {
            _productApp = productApp;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
        {
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productApp.GetAll());

            return CustomResponse(products);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById(Guid id)
        {
            //var prod = new ProductViewModel()
            //{
            //    Id = new Guid(),
            //    Name = "Teclado"
            //};
            var product = _mapper.Map<IEnumerable<ProductViewModel>>(await _productApp.GetById(id));

            return CustomResponse(product);
        }

        [HttpPost("{id:Guid}")]
        public ActionResult<ProductViewModel> CreateProduct (Guid id, ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                //var erros = ModelState.Values.SelectMany(err => err.Errors).FirstOrDefault().ErrorMessage;
                //return BadRequest(new
                //{
                //    success = false,
                //    error = erros,
                //    data = productViewModel
                //});

                return CustomResponse(ModelState, productViewModel);
            }

            var product = _mapper.Map<Product>(productViewModel);
            _productApp.Create(product);

            return CustomResponse(productViewModel);
        }

        [HttpPut("{id:Guid}")]
        public ActionResult<ProductViewModel> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            _productApp.Update(product);

            return CustomResponse(ModelState, productViewModel);
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult<ProductViewModel> DeleteProduct(Guid id)
        {
            //var prod = new ProductViewModel()
            //{
            //    Id = new Guid(),
            //    Name = "Teclado"
            //};
            var productViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(_productApp.GetById(id));
            _productApp.Delete(id);

            return CustomResponse(productViewModel);
        }

    }
}