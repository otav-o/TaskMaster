using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskMasterTutorial.Models;

namespace TaskMasterTutorial
{
    public partial class Form1 : Form
    {
        private tmDBContext tmContext;
        public Form1()
        {
            InitializeComponent();

            tmContext = new tmDBContext();

            var statuses = tmContext.Statuses.ToList();

            foreach (Status s in statuses)
                cboStatus.Items.Add(s); // não poderia usar o s.Name!
        }

        private void cmdCreateTask_Click(object sender, EventArgs e)
        {
            if (cboStatus.SelectedItem != null & txtTask.Text != String.Empty)
            {
                var newTask = new Models.Task
                {
                    Name = txtTask.Text,
                    StatusId = (cboStatus.SelectedItem as Models.Status).Id, // fk na tabela task
                    DueDate = dateTimePicker1.Value
                };

                tmContext.Tasks.Add(newTask);  // adicionar à coleção Tasks
                tmContext.SaveChanges(); // registrar no banco
            }
            else
                MessageBox.Show("Preencha o formulário corretamente.");
        }
    }
}
