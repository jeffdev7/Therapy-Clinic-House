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
    public partial class MainForm : Form

    {
        patient_control control = new patient_control();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connection connection = new connection();
            MessageBox.Show(connection.connect());


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewPatient newPatient = new FormNewPatient();
            newPatient.ShowDialog();

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search newsearch = new Search();
            newsearch.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.Backup("\\BACKUP_CLINIC"),
                "Backup of the database", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "sql files (*.sql) | *sql|All files (*.*)|*.*";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string PathBackup = openFileDialog1.FileName;
                MessageBox.Show(control.Restore(PathBackup), "Database restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
    }
}
