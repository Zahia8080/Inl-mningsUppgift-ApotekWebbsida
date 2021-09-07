using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    public class AllCategoriesModel : PageModel
    {
        private readonly ILogger<AllCategoriesModel> _logger;
        private readonly ApplicationDbContext _dbContext;


        public AllCategoriesModel(ILogger<AllCategoriesModel> logger,
                ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public class CategoryItem
        {
            public int Id { get; set; }
            public string Namn { get; set; }
        }
        public List<CategoryItem> Lista { get; set; }

        public void OnGet()
        {
            Lista = new List<CategoryItem>();
            foreach (var category in _dbContext.Categories)
            {
                Lista.Add(new CategoryItem { Namn = category.Namn, Id = category.Id });
            }
        }
    }
}
