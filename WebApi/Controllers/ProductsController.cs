﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //attribute --> javadaki annotation
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(2000);
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductbyid")]
        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetProductById(id); 
            if(result.Success)
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
            return BadRequest(result);
        }
       
        [HttpGet("getbycategoryid")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
     
        
    }
}
