using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Therapy_Clinic_House
{
    public partial class Search : Form
    {
        patients pat = new patients();
        patient_control control = new patient_control();
        public Search()
        {
            InitializeComponent();
        }

        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxOptions.SelectedIndex <0)
            {
                txtBoxSearch.Enabled = false;
                btnSearch.Enabled = false;
                lblSearchOp.Text = "";
            }
            else
            {
                txtBoxSearch.Enabled = true;
                lblOption.Text = "Type " + comboBoxOptions.Text +":";
                txtBoxSearch.Clear();
                txtBoxSearch.Focus();
            }
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtBoxSearch.Text != "")
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = control.ListAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedIndex == 0)
            {
                try
                {
                    int cod = Convert.ToInt32(txtBoxSearch.Text);
                    dataGridView1.DataSource = control.searchCode(cod);
                }
                catch
                {
                    MessageBox.Show("Type a number for the code!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBoxSearch.Clear();
                    txtBoxSearch.Focus();
                }

            }
            else if(comboBoxOptions.SelectedIndex == 1)
            {
                string patient = txtBoxSearch.Text;
                dataGridView1.DataSource = control.searchpatient(patient);
            }
            else if(comboBoxOptions.SelectedIndex == 2)
            {
                string id = txtBoxSearch.Text;
                dataGridView1.DataSource = control.searchid(id);
            }
            
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = control.ListAll();
        }
    }
}
