using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programare_Pacienti.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryAge { get; set; }
        public ICollection<PatientCategory> PatientCategories { get; set; }
    }
}
