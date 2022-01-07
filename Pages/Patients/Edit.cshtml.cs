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


namespace Programare_Pacienti.Pages.Patients
{
    public class EditModel : PatientCategoriesPageModel
    {
        private readonly Programare_Pacienti.Data.Programare_PacientiContext _context;

        public EditModel(Programare_Pacienti.Data.Programare_PacientiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient.Include(b => b.Consultation).Include(b => b.PatientCategories).ThenInclude(b => b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Patient == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Patient);
            ViewData["ConsultationID"] = new SelectList(_context.Set<Consultation>(), "ID", "ConsultationReview");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patientToUpdate = await _context.Patient
.Include(i => i.Consultation)
.Include(i => i.PatientCategories)
.ThenInclude(i => i.Category)
.FirstOrDefaultAsync(s => s.ID == id);
            if (patientToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Patient>(
            patientToUpdate,
            "Patient",
            i => i.Name, i => i.Doctor,
            i => i.Price, i => i.ConsultationDate, i => i.Consultation))
            {
                UpdatePatientCategories(_context, selectedCategories, patientToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdatePatientCategories(_context, selectedCategories, patientToUpdate);
            PopulateAssignedCategoryData(_context, patientToUpdate);
            return Page();
        }

        
    }

}
