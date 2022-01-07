using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Programare_Pacienti.Data;

namespace Programare_Pacienti.Models
{
    public class PatientCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
       

        public void PopulateAssignedCategoryData(Programare_PacientiContext context,
        Patient patient)
        {
            var allCategories = context.Category;
            var patientCategories = new HashSet<int>(patient.PatientCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryAge,
                    Assigned = patientCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdatePatientCategories(Programare_PacientiContext context,
        string[] selectedCategories, Patient patientToUpdate)
        {
            if (selectedCategories == null)
            {
                patientToUpdate.PatientCategories = new List<PatientCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var patientCategories = new HashSet<int>
            (patientToUpdate.PatientCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!patientCategories.Contains(cat.ID))
                    {
                        patientToUpdate.PatientCategories.Add(
                        new PatientCategory
                        {
                            PatientID = patientToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (patientCategories.Contains(cat.ID))
                    {
                        PatientCategory courseToRemove
                        = patientToUpdate
                        .PatientCategories
                       .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
