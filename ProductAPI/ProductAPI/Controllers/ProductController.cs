using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/product")]
    public class ProductController : ControllerBase {
        private readonly ProductContext context;

        // Construtor da classe
        public ProductController(ProductContext context) {
            this.context = context;

            if (this.context.ProductItems.Count() == 0) {
                this.context.ProductItems.Add(new Product { ProductCode = "Product Code 1", Name = "Product Item 1",
                    Quantity = 1, Price = new decimal(110.50) });
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna lista de todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Product> GetAll() {
            return context.ProductItems.ToList();
        }

        /// <summary>
        /// Retorna um produto através do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var item = context.ProductItems.Find(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }
    }
}