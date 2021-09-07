using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    [Authorize(Roles = "Admin,Product Manager")]
    [BindProperties]
    public class NewProductModel : PageModel
    {
        private readonly ILogger<NewProductModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        public NewProductModel(ILogger<NewProductModel> logger,
               ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [MaxLength(100)]
        public string Namn { get; set; }
        [MaxLength(250)]
        public string Beskrivning { get; set; }
        public string Varumärke { get; set; }
        public decimal Pris { get; set; }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();
                product.Namn = Namn;
                product.Beskrivning = Beskrivning;
                product.Pris = Pris;
                product.Varumärke = Varumärke;
                _dbContext.Products.Add(product);
                var categoryItem = _dbContext.Categories.First(category => category.Id == id);
                categoryItem.Products.Add(product);
                _dbContext.SaveChanges();
                return RedirectToPage("/Category", new { id = id });
            }
            return Page();
        }
    }
}
