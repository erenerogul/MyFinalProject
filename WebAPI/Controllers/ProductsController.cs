using Bussiness.Abstract;
using Entitites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]//Burası link kısmına localhosttan sonra /api/class'a verdiğin isimi yazarak oraya gelebiliyorsun
    [ApiController]//Attribute Bilgi verme onu imzalama yöntemi Bu class bir controllerder kendini ona göre yapılandır demek oluyor
    //Restful  mimari araştırması yap
    public class ProductsController : ControllerBase
    {
        //Bussiness da yaptığımız gibi bağımsız bir yapı yaptık constructor injection yaptık 
        //Loosely Coupled Serbest bağlılık 
        //IoC
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency Chain Araştır
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result);//200 OK
            }
            return BadRequest(result);//400 BAD REQUEST 

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
