using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMasterTutorial.Models
{
    class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }

        public int StatusId { get; set; } // seguir a convenção de nomes faz o EF gerar a FK

        public Status Status { get; set; } // navigation properties são diferentes de foreign key. 
        // Não aparece na tabela do BD
    }
}
