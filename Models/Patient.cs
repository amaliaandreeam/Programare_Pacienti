using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Programare_Pacienti.Models
{
    public class Patient
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = " Patient Name")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage ="Numele doctorului trebuie sa fie de forma 'Nume Prenume'"), Required,
StringLength(50, MinimumLength = 3)]

        [Display(Name = " Doctor Name")]
        public string Doctor { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ConsultationDate { get; set; }

        public int ConsultationID { get; set; }
        public Consultation Consultation { get; set; }
       
        public ICollection<PatientCategory> PatientCategories { get; set; }
        

    }
}
