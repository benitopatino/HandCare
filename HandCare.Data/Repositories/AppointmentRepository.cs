using HandCare.Core.Domain;
using HandCare.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HandCare.Data.Repositories;

public class AppointmentRepository : Repository<Appointment,Guid>, IAppointmentRepository
{
    public AppointmentRepository(DbContext context) : base(context)
    {
        
    }
}