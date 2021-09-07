using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    [Authorize(Roles = "Admin,Product Manager")]
    [BindProperties]
    public class NewCategoryModel : PageModel
    {   
            private readonly ApplicationDbContext _dbContext;
            public NewCategoryModel(ApplicationDbContext dbContext)
            {
               _dbContext = dbContext;
            }
           
            [MaxLength(100)]
            public string Namn { get; set; }
            
            public void OnGet()
            {

            }
            public IActionResult OnPost()
            {
                if (ModelState.IsValid)
                {
                    var category = new Category();
                    category.Namn = Namn;
                    _dbContext.Categories.Add(category);
                    _dbContext.SaveChanges();

                    return RedirectToPage("/AllCategories");
                }
                return Page();
            }
        }
    
}
