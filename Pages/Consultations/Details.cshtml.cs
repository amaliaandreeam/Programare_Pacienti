using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_Pacienti.Data;
using Programare_Pacienti.Models;

namespace Programare_Pacienti.Pages.Consultations
{
    public class DetailsModel : PageModel
    {
        private readonly Programare_Pacienti.Data.Programare_PacientiContext _context;

        public DetailsModel(Programare_Pacienti.Data.Programare_PacientiContext context)
        {
            _context = context;
        }

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
    }
}
