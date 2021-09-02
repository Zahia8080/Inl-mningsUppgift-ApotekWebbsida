using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlämningsUppgift_ApotekWebbsida.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
