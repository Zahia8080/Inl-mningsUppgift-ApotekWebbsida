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
    public class NewCategoryModel : PageModel
    {
        private readonly ILogger<NewCategoryModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        public NewCategoryModel(ILogger<NewCategoryModel> logger,
               ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [MaxLength(100)]
        public string Namn { get; set; }
        public List<Product> Products { get; set; } 
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var category = new Category();
                category.Namn = Namn;
                category.Products = new List<Product>();
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToPage("/AllCategories");
            }
            return Page();
        }
       }
}