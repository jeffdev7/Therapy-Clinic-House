using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Therapy_Clinic_House
{
    class patient_control
    {
        connection c = new connection();
        patients pat = new patients();

        public string SignUp(patients pat)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO patients (patient, id, phone, email, appointment, time_Uhr)" +
                    "VALUES ('" + pat.Patient + "', '" + pat.Id + "',  '" + pat.Phone + "', '" + pat.Email + "','" + pat.Appointment + "','" + pat.Time_Uhr + "')", c.con);

                c.connect();
                cmd.ExecuteNonQuery();
                c.disconnect();
                return ("Appointment is successfully booked!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());

            }
        }

        public string edit(patients pat)
        {
            try
            {
                string sql = "update patients set patient = '" + pat.Patient + "', " + "id='" + pat.Id + "', " + "phone='" + pat.Phone + "', " + "email='" + pat.Email + "', " + "appointment='" + pat.Appointment + "', " + "time_Uhr='" + pat.Time_Uhr + "'where codpatient = " + pat.Codpatient + ";";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.connect();
                cmd.ExecuteNonQuery();
                c.disconnect();
                return ("Data has been sucessfully updated!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string delete(patients pat)
        {
            try
            {
                string sql = "delete from patients where codpatient = " + pat.Codpatient + ";";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.connect();
                cmd.ExecuteNonQuery();
                c.disconnect();
                return ("Information deleted");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }
        public patients search(int cod)
        {
            try
            { string sql = "select *from patients where codpatient = " + cod + ";";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                c.connect();

                MySqlDataReader objData = cmd.ExecuteReader();
                if(!objData.HasRows)
                {
                    return null;
                }
                else
                {
                    objData.Read();
                    pat.Codpatient = Convert.ToInt32(objData["codpatient"]);
                    pat.Patient = objData["patient"].ToString();
                    pat.Id = objData["id"].ToString();
                    pat.Phone = objData["phone"].ToString();
                    pat.Email = objData["email"].ToString();
                    pat.Appointment = objData["appointment"].ToString();
                    pat.Time_Uhr = objData["time_Uhr"].ToString();
                 

                    objData.Close();
                    return pat;
                }
                

            }
            catch (MySqlException e)
            {
                throw (e);
            }
            finally
            {
                c.disconnect();
            }
        }
        public DataTable searchCode(int cod)
        {
            string sql = "select codpatient as 'Cod', patient as Patient, id as id,phone as Phone, " + "appointment as Appointment from patients where codpatient =" + cod + ";";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.connect();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable patients = new DataTable();
            da.Fill(patients);
            c.disconnect();
            return patients;
        }
        public DataTable searchpatient(string patient)
        {
            string sql = "select codpatient as 'Cod', patient as Patient, id as id,phone as Phone,appointment as Appointment, " + "patient as Patient from patients where patient like '%" + patient + "%'";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.connect();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable patients = new DataTable();
            da.Fill(patients);
            c.disconnect();
            return patients;

        }
        public DataTable searchid(string id)
        {
            string sql = "select codpatient as 'Cod', patient as Patient, id as id,phone as Phone, appointment as Appointment, " + "id as Id from patients where id like '%" + id + "%'";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.connect();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable patients = new DataTable();
            da.Fill(patients);
            c.disconnect();
            return patients;
        }
        public DataTable ListAll()
        {
            string sql = "select codpatient as 'Cod', patient as Patient, id as id,phone as Phone," + "" + "appointment as Appointment from patients;";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.connect();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable patients = new DataTable();
            da.Fill(patients);
            c.disconnect();
            return patients;
        }
        public string Backup (string Path)
        {
            string dataToday = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string PathBackup = Path + "\\BACKUP_CLINIC" + dataToday + ".sql";

            try
            {
                MySqlCommand cmd = new MySqlCommand(PathBackup, c.con);
                MySqlBackup bu = new MySqlBackup(cmd);
                c.connect();
                bu.ExportToFile(PathBackup);
                c.disconnect();
                return ("Backup sucessful");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string Restore(string Path)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(Path, c.con);
                MySqlBackup bu = new MySqlBackup(cmd);
                c.connect();
                bu.ImportFromFile(Path);
                c.disconnect();
                return ("Database has been sucessfully restored!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }
    }
}
         
         
