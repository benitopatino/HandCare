using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandCare.Core.Domain;

public class Office
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid OfficeId { get; set; }

    [StringLength(50)]
    public string? Address { get; set; }
    
    [StringLength(450)]
    public string? City { get; set; }
    
    [StringLength(10)]
    public string? State { get; set; }
    
    [StringLength(50)]
    [RegularExpression("^\\d{5}(?:-\\d{4})?$", ErrorMessage = "Please enter a valid zipcode")]
    public string? ZipCode { get; set; }
    
    [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid phone number")]
    [StringLength(50)]
    public string? Phone { get; set; }
    
    public bool Closed { get; set; }
}