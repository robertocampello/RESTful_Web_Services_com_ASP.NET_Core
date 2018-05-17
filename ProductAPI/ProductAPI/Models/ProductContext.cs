using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Models
{
    public class ProductContext : DbContext {
        // Construtor da classe
        public ProductContext(DbContextOptions<ProductContext> options) : 
            base(options) {
        }

        // Propriedade que retorna o DbSet de Produto
        public DbSet<Product> ProductItems { get; set; }
    }
}