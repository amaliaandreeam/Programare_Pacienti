using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programare_Pacienti.Models
{
    public class Consultation
    {
        public int ID { get; set; }
        public string ConsultationReview { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
