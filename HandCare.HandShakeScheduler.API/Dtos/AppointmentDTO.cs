namespace HandCare.HandShakeScheduler.API.Dtos;

public class AppointmentDTO
{
    public Guid AppointmentId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime Time { get; set; }
    public string Status { get; set; }
    public string? Reason { get; set; }
    public string? Description { get; set; }
    public Guid OfficeId { get; set; }

}

public class AppointmentDTOView
{

    public Guid AppointmentId { get; set; }
    public Guid PatientId { get; set;}



}