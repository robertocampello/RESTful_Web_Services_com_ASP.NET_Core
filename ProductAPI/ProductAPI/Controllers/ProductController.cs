using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Produces("application/json", "application/xml", "application/html")]
    [Route("api/products")]
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
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(int id) {
            var item = context.ProductItems.Find(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Inclui um determinado produto no BD
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Product item) {
            if (item == null) {
                return BadRequest();
            }

            // Inclui produto
            context.ProductItems.Add(item);
            context.SaveChanges();

            // Retorna response, adicionando parâmetro Location com a URL do novo recurso criado
            return CreatedAtRoute("GetProduct", new { id = item.ProductID }, item);
        }

        /// <summary>
        /// Altera um determinado produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Product item) {
            // Caso id não seja igual ao id do produto 
            if (item == null || item.ProductID != id) {
                return BadRequest();
            }

            // Busca produto pelo ID
            var product = context.ProductItems.Find(id);
            if (product == null) {
                return NotFound();
            }

            // Atualiza objeto produto
            product.ProductCode = item.ProductCode;
            product.Name        = item.Name;
            product.Quantity    = item.Quantity;
            product.Price       = item.Price;

            // Altera produto e confirma operação
            context.ProductItems.Update(product);
            context.SaveChanges();

            // Retorna response
            return NoContent();
        }

        /// <summary>
        /// Exclui um determinado produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            // Busca produto pelo ID
            var item = context.ProductItems.Find(id);
            if (item == null) {
                return NotFound();
            }

            // Remove produto e confirma operação
            context.ProductItems.Remove(item);
            context.SaveChanges();

            // Retorna response
            return NoContent();
        }
    }
}