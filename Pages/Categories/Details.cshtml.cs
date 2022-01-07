﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Programare_Pacienti.Data.Programare_PacientiContext _context;

        public DetailsModel(Programare_Pacienti.Data.Programare_PacientiContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
