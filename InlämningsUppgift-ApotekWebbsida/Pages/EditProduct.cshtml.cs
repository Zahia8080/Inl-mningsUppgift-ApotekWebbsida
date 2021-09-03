using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    [Authorize(Roles="Admin")]
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
        public string Namn { get; set; }
        public string Beskrivning { get; set; }
        public string Varumärke { get; set; }
        public Decimal Pris { get; set; }
        public void OnGet(int id)
        {
            var currentProduct = _dbContext.Products.First(product => product.Id == id);
            Namn = currentProduct.Namn;
            Beskrivning= currentProduct.Beskrivning;
            Varumärke = currentProduct.Varumärke;
            Pris = currentProduct.Pris;
        }
    }
}
