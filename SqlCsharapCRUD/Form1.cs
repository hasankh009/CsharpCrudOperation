using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlCsharapCRUD
{
    public partial class Form1 : Form
    {

        EmployeeRepository employeeRepository = new EmployeeRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = employeeRepository.GetAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAddFN.Text)&& !string.IsNullOrEmpty(txtAddLN.Text))
            {
                employeeRepository.Add(new Employee
                {
                    FirstName = txtAddFN.Text,
                LastName = txtAddLN.Text
                });
                txtAddFN.Text = string.Empty;
                txtAddLN.Text = string.Empty;
                dataGridView1.DataSource = employeeRepository.GetAll();
            }
        }

        private void dataGridView1_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                var row = dataGridView1.SelectedRows[0];
                var employee = (Employee)row.DataBoundItem;
                txtid.Text = employee.id.ToString();
                txtFN.Text = employee.FirstName.ToString();
                txtLN.Text = employee.LastName.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text)&& !string.IsNullOrEmpty(txtFN.Text)&& !string.IsNullOrEmpty(txtLN.Text))
            {
                employeeRepository.Update(new Employee
                {
                    id = int.Parse(txtid.Text),
                    FirstName = txtFN.Text,
                    LastName = txtLN.Text
                });
                dataGridView1.DataSource = employeeRepository.GetAll();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text) && !string.IsNullOrEmpty(txtFN.Text) && !string.IsNullOrEmpty(txtLN.Text))
            {
                employeeRepository.Delete(int.Parse(txtid.Text));
                txtid.Text = string.Empty;
                txtFN.Text = string.Empty;
                txtLN.Text = string.Empty;
                dataGridView1.DataSource = employeeRepository.GetAll();

            }
        }
    }
}
