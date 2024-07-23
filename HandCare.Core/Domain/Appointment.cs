using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandCare.Core.Domain;

public enum Status
{
	Open,
	Cancelled,
	Completed,
	Missed
}

public class Appointment
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid AppointmentId { get; set; }

	public Guid PatientId { get; set; }
	
	public DateTime CreatedDate { get; set; }

	public DateTime Time { get; set; }

	[StringLength(50)]
	public string Status { get; set; }
	
	public string? Reason { get; set; }

	public string? Description { get; set; }
	
	public Guid OfficeId { get; set; }
	
	public Patient Patient { get; set; }
	
	public Office Office { get; set; }

}
