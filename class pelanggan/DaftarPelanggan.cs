using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace PenjualanPembelian_LIB
{
    public class DaftarPelanggan
    {
        private List<Pelanggan> listPelanggan;
        private string kodeTerbaru;

        #region PROPERTIES
        public List<Pelanggan> ListPelanggan
        {
            get { return listPelanggan; }
        }

        public int JumlahPelanggan
        {
            get { return listPelanggan.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }
        #endregion

        #region CONSTRUCTOR
        public DaftarPelanggan()
        {
            listPelanggan = new List<Pelanggan>();
            kodeTerbaru = "1";
        }
        #endregion

        #region METHOD
        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();
            //tuliskan perintah SQL yang akan dijalankan
            string sql = "SELECT * FROM Pelanggan";
            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data = c.ExecuteReader();

                //selama data reader masih bisa terbaca (selama masih ada data)
                while (data.Read() == true)
                {
                    //mendapatkan kode Pelanggan dari hasil data reader
                    string kode = data.GetValue(0).ToString();
                    //mendapatkan nama Pelanggan dari hasil data reader
                    string nama = data.GetValue(1).ToString();
                    //mendapatkan alamat Pelanggan dari hasil data reader
                    string alamat = data.GetValue(2).ToString();
                    //mendapatkan telp Pelanggan dari hasil data reader
                    string telp = data.GetValue(3).ToString();
                    //create objek bertipe Pelanggan
                    Pelanggan p = new Pelanggan(kode, nama, alamat, telp);
                    //simpan ke list
                    listPelanggan.Add(p);
                }
                //hapus MySqlCommand setelah selesai
                c.Dispose();
                //hapus data reader setelah selesai
                data.Dispose();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string CariData(string kriteria, string nilaiKriteria)
        {
            Koneksi k = new Koneksi();
            k.Connect();
            //tuliskan perintah SQL yang akan dijalankan
            string sql = "SELECT * FROM Pelanggan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data = c.ExecuteReader();

                //selama data reader masih bisa terbaca (selama masih ada data)
                while (data.Read() == true)
                {
                    //mendapatkan kode Pelanggan dari hasil data reader
                    string kode = data.GetValue(0).ToString();
                    //mendapatkan nama Pelanggan dari hasil data reader
                    string nama = data.GetValue(1).ToString();
                    //mendapatkan alamat Pelanggan dari hasil data reader
                    string alamat = data.GetValue(2).ToString();
                    //mendapatkan telp Pelanggan dari hasil data reader
                    string telp = data.GetValue(3).ToString();
                    //create objek bertipe Pelanggan
                    Pelanggan p = new Pelanggan(kode, nama, alamat, telp);
                    //simpan ke list
                    listPelanggan.Add(p);
                }
                //hapus MySqlCommand setelah selesai
                c.Dispose();
                //hapus data reader setelah selesai
                data.Dispose();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string GenerateKode()
        {
            Koneksi k = new Koneksi();
            k.Connect();
            //tuliskan perintah SQL yang akan dijalankan
            string sql = "SELECT KodePelanggan FROM Pelanggan ORDER BY KodePelanggan DESC LIMIT 1";
            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data = c.ExecuteReader();

                //jika data reader bisa terbaca (selama masih ada data)
                if (data.Read() == true)
                {
                    //mendapatkan kode Pelanggan dari hasil data reader
                    int kdTerbaru = int.Parse(data.GetValue(0).ToString())+1;
                    kodeTerbaru = kdTerbaru.ToString();
                }

                //hapus MySqlCommand setelah selesai
                c.Dispose();
                //hapus data reader setelah selesai
                data.Dispose();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string TambahData(Pelanggan p)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "INSERT INTO Pelanggan(KodePelanggan, Nama, Alamat, Telepon) VALUES ('" + p.KodePelanggan + "','" + p.NamaPelanggan + "','" + p.AlamatPelanggan + "','" + p.Telepon + "')";

            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                //Gunakan ExecuteNonQuery untuk menjalankan perintah INSERT/UPDATE/DELETE
                c.ExecuteNonQuery();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string UbahData(Pelanggan p)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "UPDATE Pelanggan SET Nama = '" + p.NamaPelanggan + "', Alamat = '" + p.AlamatPelanggan + "', Telepon = '" + p.Telepon + "' WHERE KodePelanggan = '" + p.KodePelanggan + "'";

            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                //Gunakan ExecuteNonQuery untuk menjalankan perintah INSERT/UPDATE/DELETE
                c.ExecuteNonQuery();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string HapusData(Pelanggan p)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "DELETE FROM Pelanggan WHERE KodePelanggan = '" + p.KodePelanggan + "'";

            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                //Gunakan ExecuteNonQuery untuk menjalankan perintah INSERT/UPDATE/DELETE
                c.ExecuteNonQuery();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

    }
}
