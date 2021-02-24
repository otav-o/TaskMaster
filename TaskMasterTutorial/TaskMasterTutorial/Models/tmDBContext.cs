using System.Data.Entity;

namespace TaskMasterTutorial.Models
{
    class tmDBContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; } 
        
        // Lembrar de adicionar aqui para que as tabelas sejam criadas
        // > add-migration AddTaskToDB -Force (sobrescrever)
        // update-database -targetmigration AddStatusSeedDataToDB (desfaz uma migração já aplicada)
    }
}
