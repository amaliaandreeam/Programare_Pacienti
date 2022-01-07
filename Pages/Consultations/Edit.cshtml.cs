using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programare_Pacienti.Data;
using Programare_Pacienti.Models;

namespace Programare_Pacienti.Pages.Consultations
{
    public class EditModel : PageModel
    {
        private readonly Programare_Pacienti.Data.Programare_PacientiContext _context;

        public EditModel(Programare_Pacienti.Data.Programare_PacientiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consultation Consultation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Consultation = await _context.Consultation.FirstOrDefaultAsync(m => m.ID == id);

            if (Consultation == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Consultation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationExists(Consultation.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConsultationExists(int id)
        {
            return _context.Consultation.Any(e => e.ID == id);
        }
    }
}
