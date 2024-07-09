using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCare.Core.Domain
{

    public class Patient
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PatientId { get; set; }
        
        [StringLength(450)]
        public string? FirstName { get; set; }
        
        [StringLength(450)]
        public string? LastName { get; set; }
        
        [Column(TypeName ="date")]
        public DateTime? DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid phone number")]
        [StringLength(50)]
        public string? CellPhone { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }
        
        [StringLength(450)]
        public string? City { get; set; }


        [StringLength(10)]
        public string? State { get; set; }
        
        [StringLength(50)]
        [RegularExpression("^\\d{5}(?:-\\d{4})?$", ErrorMessage = "Please enter a valid zipcode")]
        public string? ZipCode { get; set; }
    }
    
}
