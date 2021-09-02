using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public SearchResultsModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public class ProductItem
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public string Beskrivning { get; set; }
            public string Varumärke { get; set; }
            public Decimal Pris { get; set; }
        }
        public string SearchWord { get; set; }
        public List<ProductItem> allaProduct { get; set; } = new List<ProductItem>();
        public void OnGet(string query)
        {
            SearchWord = query;
           var currentLista = _dbContext.Products.Where(p => p.Namn.Contains(query) || p.Beskrivning.Contains(query));
            allaProduct = currentLista.Select(product => new ProductItem 
            {
                Id = product.Id,
                Namn = product.Namn,
                Beskrivning = product.Beskrivning,
                Varumärke =product.Varumärke,
                Pris=product.Pris
            }).ToList();
        }
    }
}
