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
    public partial class FormNewPatient : Form
    {
        public FormNewPatient()
        {
            InitializeComponent();
        }

        patients pat = new patients();
        patient_control control = new patient_control();
       
        private void limpar()
        {
            txtCode.Clear();
            txtPatient.Clear();
            txtId.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtDate.Clear();
            txtTime.Clear();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pat.Codpatient = Convert.ToInt32(txtCode.Text);
            pat.Patient = txtPatient.Text;
            pat.Id = txtId.Text;
            pat.Phone = txtPhone.Text;
            pat.Email = txtEmail.Text;
            pat.Appointment = txtDate.Text;
            pat.Time_Uhr = txtTime.Text;
            
            MessageBox.Show(control.edit(pat));
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if(txtPatient.Text == "")
            {
                MessageBox.Show("Please informe a name");
            }
            else
            {
                pat.Patient = txtPatient.Text;
                pat.Id = txtId.Text;
                pat.Phone = txtPhone.Text;
                pat.Email = txtEmail.Text;
                pat.Appointment = txtDate.Text;
                pat.Time_Uhr = txtTime.Text;
                

                MessageBox.Show(control.SignUp(pat));
                limpar();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                pat = control.search(int.Parse(txtCode.Text));
                if(pat is null)
                {
                    MessageBox.Show("Nothing found");
                    limpar();
                }
                else
                {
                    txtCode.Text = pat.Codpatient.ToString();
                    txtPatient.Text = pat.Patient;
                    txtId.Text = pat.Id;
                    txtPhone.Text = pat.Phone;
                    txtEmail.Text = pat.Email;
                    txtDate.Text = pat.Appointment;
                    txtTime.Text = pat.Time_Uhr;
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pat.Codpatient = Convert.ToInt32(txtCode.Text);
            pat.Patient = txtPatient.Text;
            pat.Id = txtId.Text;
            pat.Phone = txtPhone.Text;
            pat.Email = txtEmail.Text;
            pat.Appointment = txtDate.Text;
            pat.Time_Uhr = txtTime.Text ;
            

            MessageBox.Show(control.delete(pat));

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtPatient.Clear();
            txtId.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtDate.Clear();
            txtTime.Clear();
            txtPatient.Focus();

        }

        
    }
}
