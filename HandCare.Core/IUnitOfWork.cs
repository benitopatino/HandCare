using HandCare.Core.Repositories;

namespace HandCare.Core;

public interface IUnitOfWork : IDisposable
{
    IPatientRepository Patients { get; }
    IOfficeRepository Offices { get; }
    IAppointmentRepository Appointments{get;}
    int Complete();
}