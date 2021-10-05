using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InlämningsUppgift_ApotekWebbsida.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InlämningsUppgift_ApotekWebbsida.Pages
{
    public class SortSearchModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public SortSearchModel(ApplicationDbContext dbContext)
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
        
        public List<ProductItem> allSearchProduct { get; set; } = new List<ProductItem>();

        [BindProperty(SupportsGet = true)]
        public string q { get; set; }

        [BindProperty(SupportsGet = true)]
        public string sortcolumn { get; set; }

        [BindProperty(SupportsGet = true)]
        public string sortorder { get; set; }

        public enum SortOrder
        {
            asc,
            desc
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(sortcolumn))
                sortcolumn = nameof(ProductItem.Namn);

            if (string.IsNullOrEmpty(sortorder))
                sortorder = nameof(SortOrder.asc);

            var query = _dbContext.Products.Select(product => new ProductItem
            {
                Id = product.Id,
                Namn = product.Namn,
                Beskrivning = product.Beskrivning,
                Varumärke = product.Varumärke,
                Pris = product.Pris
            }).Where(p => string.IsNullOrEmpty(q) || p.Namn.Contains(q) || p.Beskrivning.Contains(q));

            if (sortcolumn == nameof(ProductItem.Namn))
            {
                if (sortorder == nameof(SortOrder.asc))
                    query = query.OrderBy(e => e.Namn);
                else
                    query = query.OrderByDescending(e => e.Namn);
            }
            else if (sortcolumn == nameof(ProductItem.Beskrivning))
            {
                if (sortorder == nameof(SortOrder.asc))
                    query = query.OrderBy(e => e.Beskrivning);
                else
                    query = query.OrderByDescending(e => e.Beskrivning);
            }
            else if (sortcolumn == nameof(ProductItem.Pris))
            {
                if (sortorder == nameof(SortOrder.asc))
                    query = query.OrderBy(e => e.Pris);
                else
                    query = query.OrderByDescending(e => e.Pris);
            }


            allSearchProduct = query.ToList();
        }
    }
}
