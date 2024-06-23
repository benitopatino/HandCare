using System.Data.Common;
using HandCare.Domain;
using Microsoft.EntityFrameworkCore;
namespace HandCare.Data.DbContext;

public class HandCareContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Patient> Patients { get; set; }
    
    //
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlServer("Server=LocalHost,1433;Database=HandCare;User Id=sa;Password=yourStrong(!)Password; TrustServerCertificate=True");
    public HandCareContext()
    {
        
    }
    public HandCareContext(DbContextOptions<HandCareContext> options)
        : base(options)
    {
    }
    
}