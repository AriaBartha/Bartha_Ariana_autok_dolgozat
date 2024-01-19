using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bartha_Ariana_autok_dolgozat
{
    internal class Adatbazis
    {
        MySqlConnection conn = null;
        MySqlCommand sql = null;
        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "autok";
            builder.CharacterSet = "utf8";
            conn = new MySqlConnection(builder.ConnectionString);
            sql = conn.CreateCommand();
            try
            {
                kapcsolatNyit();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            finally
            {
                kapcsolatZar();
            }
        }

        
        internal List<Auto> getAllAuto()
        {
            List<Auto> autok = new List<Auto>();
            sql.CommandText = "SELECT * FROM `auto` ORDER BY `marka`";
            try
            {
                kapcsolatNyit();
                using (MySqlDataReader reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        string rendszam = reader.GetString("rendszam");
                        string marka = reader.GetString("marka");
                        string modell = reader.GetString("modell");
                        int gyartasiEv = reader.GetInt32("gyartasiev");
                        DateTime forgalmiErvenyesseg = reader.GetDateTime("forgalmiErvenyesseg");
                        int ar = reader.GetInt32("vetelar");
                        int km = reader.GetInt32("kmallas");
                        int hengerurtartalom = reader.GetInt32("hengerűrtartalom");
                        int tomeg = reader.GetInt32("tomeg");
                        int teljesitmeny = reader.GetInt32("teljesitmeny");
                        autok.Add(new Auto(rendszam, marka, modell, gyartasiEv, forgalmiErvenyesseg,ar, km, hengerurtartalom, tomeg, teljesitmeny));

                    }
                }
            }
            catch (MySqlException ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                kapcsolatZar();
            }
            return autok;
        }

        internal void insertAuto(Auto auto)
        {
                sql.CommandText = "INSERT INTO `auto`(`rendszam`, `marka`, `modell`, `gyartasiev`, `forgalmiErvenyesseg`, `vetelar`, `kmallas`, `hengerűrtartalom`, `tomeg`, `teljesitmeny`) VALUES (@rendszam, @marka, @modell, @gyartasiev, @forgalmiErvenyesseg, @vetelar, @kmallas, @hengerűrtartalom, @tomeg, @teljesitmeny)";
                sql.Parameters.AddWithValue("@rendszam", auto.Rendszam);
                sql.Parameters.AddWithValue("@marka", auto.Marka);
                sql.Parameters.AddWithValue("@modell", auto.Modell);
                sql.Parameters.AddWithValue("@gyartasiev", auto.GyartasiEv);
                sql.Parameters.AddWithValue("@forgalmiErvenyesseg", auto.ForgalmiErvenyesseg);
                sql.Parameters.AddWithValue("@vetelar", auto.Ar);
                sql.Parameters.AddWithValue("@kmallas", auto.Km);
                sql.Parameters.AddWithValue("@hengerűrtartalom", auto.Hengerurtartalom);
                sql.Parameters.AddWithValue("@tomeg", auto.Tomeg);
                sql.Parameters.AddWithValue("@teljesitmeny", auto.Teljesitmeny);
            try
            {
                kapcsolatNyit();
                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                kapcsolatZar();
            }

        }

        internal void updateAuto(Auto auto)
        {
                kapcsolatNyit();
                sql.CommandText = "UPDATE `auto` SET" +
                "`marka`=@marka," +
                "`modell`=@modell," +
                "`gyartasiev`=@gyartasiev," +
                "`forgalmiErvenyesseg`=@forgalmiErvenyesseg," +
                "`vetelar`=@vetelar," +
                "`kmallas`=@kmallas," +
                "`hengerűrtartalom`=@hengerűrtartalom," +
                "`tomeg`=@tomeg," +
                "`teljesitmeny`=@teljesitmeny WHERE `rendszam`=@rendszam";
                sql.Parameters.Clear();
                sql.Parameters.AddWithValue("@rendszam", auto.Rendszam);
                sql.Parameters.AddWithValue("@marka", auto.Marka);
                sql.Parameters.AddWithValue("@modell", auto.Modell);
                sql.Parameters.AddWithValue("@gyartasiev", auto.GyartasiEv);
                sql.Parameters.AddWithValue("@forgalmiErvenyesseg", auto.ForgalmiErvenyesseg);
                sql.Parameters.AddWithValue("@vetelar", auto.Ar);
                sql.Parameters.AddWithValue("@kmallas", auto.Km);
                sql.Parameters.AddWithValue("@hengerűrtartalom", auto.Hengerurtartalom);
                sql.Parameters.AddWithValue("@tomeg", auto.Tomeg);
                sql.Parameters.AddWithValue("@teljesitmeny", auto.Teljesitmeny);

            try
            {
                kapcsolatNyit();
                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                kapcsolatZar();
            }
            
        }
        internal void deleteAuto(Auto auto)
        {

                sql.CommandText = "DELETE FROM `auto` WHERE `rendszam`=@rendszam";
                sql.Parameters.AddWithValue("@rendszam", auto.Rendszam);

            try
            {
                kapcsolatNyit();
                sql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                kapcsolatZar();
            }
        }


        private void kapcsolatNyit()
        {
           if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private void kapcsolatZar()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }


    }
}
