using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        private object in_dbContext;

        public PrivacyModel(ILogger<PrivacyModel> logger,
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
                Lista.Add(new CategoryItem {Namn=category.Namn, Id=category.Id });
            }
        }
    }
}
