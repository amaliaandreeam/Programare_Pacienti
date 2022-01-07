using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_Pacienti.Data;
using Programare_Pacienti.Models;

namespace Programare_Pacienti.Pages.Patients
{
    public class CreateModel  : PatientCategoriesPageModel
    {
        private readonly Programare_Pacienti.Data.Programare_PacientiContext _context;

        public CreateModel(Programare_Pacienti.Data.Programare_PacientiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ConsultationID"] = new SelectList(_context.Set<Consultation>(), "ID", "ConsultationReview");
            var patient = new Patient();
            patient.PatientCategories = new List<PatientCategory>();
            PopulateAssignedCategoryData(_context, patient);
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newPatient = new Patient();
            if (selectedCategories != null)
            {
                newPatient.PatientCategories = new List<PatientCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new PatientCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newPatient.PatientCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Patient>(
             newPatient,
              "Patient",
                i => i.Name, i => i.Doctor,
                i => i.Price, i => i.ConsultationDate, i => i.ConsultationID))
            {
                _context.Patient.Add(newPatient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newPatient);
            return Page();
        }
    }
}
