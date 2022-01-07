using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_Pacienti.Data;
using Programare_Pacienti.Models;

namespace Programare_Pacienti.Pages.Consultations
{
    public class CreateModel : PageModel
    {
        private readonly Programare_Pacienti.Data.Programare_PacientiContext _context;

        public CreateModel(Programare_Pacienti.Data.Programare_PacientiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Consultation Consultation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Consultation.Add(Consultation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
