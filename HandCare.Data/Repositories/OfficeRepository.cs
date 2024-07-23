using HandCare.Core.Domain;
using HandCare.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HandCare.Data.Repositories;

public class OfficeRepository : Repository<Office,Guid>, IOfficeRepository
{
    public OfficeRepository(DbContext context) : base(context)
    {
    }
}