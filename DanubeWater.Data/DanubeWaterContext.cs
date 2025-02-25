using DanubeWater.Entities;
using Microsoft.EntityFrameworkCore;

namespace DanubeWater.Data
{
    public class DanubeWaterContext : DbContext
    {
        public DbSet<WaterReport> WaterReports { get; set; }

        public DanubeWaterContext(DbContextOptions<DanubeWaterContext> options) : base(options)
        {
            Database.EnsureCreated();
        }        
    }
}
