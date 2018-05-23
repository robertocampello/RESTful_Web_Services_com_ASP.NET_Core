using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models.Helper
{
    /// <summary>
    /// Classe Helper para criação da representação HATEOAS
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkHelper<T> where T : class {
        public T Value          { get; set; }
        public List<Link> Links { get; set; }

        /// <summary>
        /// Construtor default da classe
        /// </summary>
        public LinkHelper() {
            Links = new List<Link>();
        }

        /// <summary>
        /// Construtor sobrecarregado que recebe um objeto genérico <T>
        /// </summary>
        /// <param name="item"></param>
        public LinkHelper(T item) : base() {
            Value = item;
            Links = new List<Link>();
        }
    }
}
