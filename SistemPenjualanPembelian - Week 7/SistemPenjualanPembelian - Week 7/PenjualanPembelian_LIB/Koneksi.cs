using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using System.Configuration;

namespace PenjualanPembelian_LIB
{
    public class Koneksi
    {
        private MySqlConnection koneksi;
        private string namaServer;
        private string namaDatabase;
        private string username;
        private string password;

        #region PROPERTIES
        public MySqlConnection KoneksiDB
        {
            get { return koneksi;  }
        }
        public string NamaServer
        {
            set { namaServer = value; }
            get { return namaServer;  }
        }
        public string NamaDatabase
        {
            set { namaDatabase = value; }
            get { return namaDatabase;  }
        }
        public string Username
        {
            set { username = value; }
            get { return username;  }
        }
        public string Password
        {
            set { password = value; }
            get { return password;  }
        }
        #endregion

        #region CONSTRUCTOR
        public Koneksi()
        {
            koneksi = new MySqlConnection();
            //Set connection string sesuai dengan yang ada di App.Config
            koneksi.ConnectionString = ConfigurationManager.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString;

            //panggil method Connect
            string hasilConnect = Connect();
        }
        public Koneksi(string server, string database, string user, string pwd)
        {
            namaServer = server;
            namaDatabase = database;
            username = user;
            password = pwd;

            string strCon = "server=" + namaServer + "; database=" + namaDatabase + "; uid=" + username + "; pwd=" + password;

            koneksi = new MySqlConnection();
            //Set connection string sesuai dengan nama server, database, username, dan password yang dimasukkan user
            koneksi.ConnectionString = strCon;

            //panggil method Connect
            string hasilConnect = Connect();

            if (hasilConnect == "sukses")
            {
                //Ubah app config dengan memanggil method UpdateAppConfig
                UpdateAppConfig(strCon);
            }
        }
        #endregion

        #region METHOD
        public string Connect()
        {
            try
            {
                if (koneksi.State == System.Data.ConnectionState.Open)
                {
                    koneksi.Close();
                }
                koneksi.Open();
                return "sukses"; //artinya sukses connect
            }
            catch (Exception e)
            {
                return e.Message; //artinya gagal connect
            }
        }

        public void UpdateAppConfig(string connectionString)
        {
            // Buka konfigurasi App.Config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Set App.Config pada nama tag koneksi dengan string koneksi yang dimasukkan pengguna
            config.ConnectionStrings.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString = connectionString;

            // Simpan App.Config yang telah diperbarui
            config.Save(ConfigurationSaveMode.Modified, true);

            // Reload App.Config dengan pengaturan yang baru
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        #endregion
      
    }
}
