using HandCare.Core.Domain;
using HandCare.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HandCare.Data.Repositories;

public class PatientRepository : Repository<Patient,Guid>, IPatientRepository
{
    public PatientRepository(DbContext context) : base(context)
    {
    }
    
}