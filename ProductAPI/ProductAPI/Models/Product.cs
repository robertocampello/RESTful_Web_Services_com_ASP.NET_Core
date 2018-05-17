using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class Product {
        // Atributos de classe
        private int     productID;
        private String  productCode;
        private String  name;
        private int     quantity;
        private decimal price;

        // Propriedades
        public int     ProductID   { get => productID; set => productID = value; }
        public string  ProductCode { get => productCode; set => productCode = value; }
        public string  Name        { get => name; set => name = value; }
        public int     Quantity    { get => quantity; set => quantity = value; }
        public decimal Price       { get => price; set => price = value; }
    }
}
