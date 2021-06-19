using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Therapy_Clinic_House
{
    class patients
    {
        private int codpatient;
        private string patient;
        private string id;
        
        private string phone;
        private string email;
        private string appointment;
        private string time_Uhr;
       

        public int Codpatient { get => codpatient; set => codpatient = value; }
        public string Patient { get => patient; set => patient = value; }
        public string Id { get => id; set => id = value; }
       
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Appointment { get => appointment; set => appointment = value; }
        public string Time_Uhr { get => time_Uhr; set => time_Uhr = value; }
        
    }
}
