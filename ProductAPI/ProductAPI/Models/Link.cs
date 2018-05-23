using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    /// <summary>
    /// Classe POCO para reprsentação HATEOAS na resposta
    /// </summary>
    public class Link {
        public string Href   { get; set; }
        public string Rel    { get; set; }
        public string method { get; set; }
    }
}
