using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programare_Pacienti.Models
{
    public class PatientData
    {
        public IEnumerable<Patient> Patient { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<PatientCategory> BookCategories { get; set; }
    }
}
