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
    [Authorize(Roles= "Admin,Product Manager")]   
    [BindProperties]
    public class EditProductModel : PageModel
    {
        private readonly ILogger<EditProductModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        public EditProductModel(ILogger<EditProductModel> logger,
               ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public int Id { get; set; }
        [MaxLength(200)]
        public string Namn { get; set; }
        [MaxLength(100)] 
        public string Beskrivning { get; set; }
        public string Varumärke { get; set; }
        [BindProperty]
        [Range(1, 1999999)]
        public decimal Pris { get; set; }
        public void OnGet(int id)
        {
            Id = id;
            var currentProduct = _dbContext.Products.First(product => product.Id == id);
            Namn = currentProduct.Namn;
            Beskrivning= currentProduct.Beskrivning;
            Varumärke = currentProduct.Varumärke;
            Pris = currentProduct.Pris;
        }
        public IActionResult OnPost(int id,int categoryId)
        {
            if (ModelState.IsValid)
            {
                var product = _dbContext.Products.First(c => c.Id == id);
                product.Namn = Namn;
                product.Beskrivning = Beskrivning;
                product.Pris = Pris;
                product.Varumärke = Varumärke;
                _dbContext.SaveChanges();
                return RedirectToPage("/Category", new { id = categoryId });
            }
            return Page();
        }
    }
}
