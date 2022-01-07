using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programare_Pacienti.Models
{
    public class PatientCategory
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }

}
