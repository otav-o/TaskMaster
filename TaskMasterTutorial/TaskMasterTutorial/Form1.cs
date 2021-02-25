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

            refreshData();
        }

        private void refreshData()
        {
            BindingSource bi = new BindingSource(); // objeto intermediário para não adicionar o data grid diretamente à query

            var query = from t in tmContext.Tasks
                        orderby t.DueDate
                        select new { t.Id, TaskName = t.Name, StatusName = t.Status.Name, t.DueDate };

            bi.DataSource = query.ToList();

            dataGridView1.DataSource = bi;
            dataGridView1.Refresh();
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

                refreshData();
            }
            else
                MessageBox.Show("Preencha o formulário corretamente.");
        }
    }
}
