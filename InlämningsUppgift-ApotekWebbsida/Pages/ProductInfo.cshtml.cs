using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    public class ProductInfoModel : PageModel
    {
       
            private readonly ILogger<ProductInfoModel> _logger;
            private readonly ApplicationDbContext _dbContext;
            public ProductInfoModel(ILogger<ProductInfoModel> logger,
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
            public decimal Pris { get; set; }
            public void OnGet(int id)
            {
                Id = id;
                var currentProduct = _dbContext.Products.First(product => product.Id == id);
                Namn = currentProduct.Namn;
                Beskrivning = currentProduct.Beskrivning;
                Varumärke = currentProduct.Varumärke;
                Pris = currentProduct.Pris;
            }
        
    }
}
