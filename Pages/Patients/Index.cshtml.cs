using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_Pacienti.Data;
using Programare_Pacienti.Models;

namespace Programare_Pacienti.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Programare_Pacienti.Data.Programare_PacientiContext _context;

        public IndexModel(Programare_Pacienti.Data.Programare_PacientiContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }
        public PatientData PatientD { get; set; }
        public int PatientID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PatientD = new PatientData();

            PatientD.Patient = await _context.Patient
                .Include(b => b.Consultation)
                
                .Include(b => b.PatientCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
              .OrderBy(b => b.Name)
                 .ToListAsync();

            if (id != null)
            {
                PatientID = id.Value;
                Patient patient = PatientD.Patient
                .Where(i => i.ID == id.Value).Single();
                PatientD.Categories = patient.PatientCategories.Select(s => s.Category);
            }
        }
    }
}
