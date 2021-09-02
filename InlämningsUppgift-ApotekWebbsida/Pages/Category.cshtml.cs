using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ILogger<CategoryModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        public CategoryModel(ILogger<CategoryModel> logger,
               ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public string CategoryName { get; set; }
        public class ProductItem
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public string Beskrivning { get; set; }
            public string Varumärke { get; set; }
            public Decimal Pris { get; set; }
        }
        public List<ProductItem> ListOffProducts { get; set; }
        public void OnGet(int categoryId)
        {
            var currentCategory = _dbContext.Categories.Include(p=>p.Products).First(category => category.Id == categoryId);
            CategoryName = currentCategory.Namn.ToUpper();
            ListOffProducts = currentCategory.Products.Select(product => new ProductItem
            {
                Id = product.Id,
                Namn = product.Namn,
                Beskrivning = product.Beskrivning,
                Pris = product.Pris,
                Varumärke = product.Varumärke
            }).ToList();
        }
    }
}
