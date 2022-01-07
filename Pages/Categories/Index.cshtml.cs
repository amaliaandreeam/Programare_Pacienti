using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_Pacienti.Data;
using Programare_Pacienti.Models;

namespace Programare_Pacienti.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Programare_Pacienti.Data.Programare_PacientiContext _context;

        public IndexModel(Programare_Pacienti.Data.Programare_PacientiContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
