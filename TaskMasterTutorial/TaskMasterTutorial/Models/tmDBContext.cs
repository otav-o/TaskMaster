using System.Data.Entity;

namespace TaskMasterTutorial.Models
{
    class tmDBContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
    }
}
