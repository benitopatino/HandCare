using HandCare.Core;
using HandCare.Core.Repositories;
using HandCare.Data.Repositories;

namespace HandCare.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly HandCareContext _context;
    
    public IPatientRepository Patients { get; }
    public IOfficeRepository Offices { get;}
    
    public UnitOfWork(HandCareContext context)
    {
        _context = context;
        Patients = new PatientRepository(_context);
        Offices = new OfficeRepository(_context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}