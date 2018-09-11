using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PenjualanPembelian_LIB
{
    public class DaftarSupplier
    {
        private List<Supplier> listSupplier;
        private string kodeTerbaru;

        #region PROPERTIES
        public List<Supplier> ListSupplier
        {
            get { return listSupplier; }
        }

        public int JumlahSupplier
        {
            get { return listSupplier.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }
        #endregion

         #region CONSTRUCTOR
        public DaftarSupplier()
        {
            listSupplier = new List<Supplier>();
            kodeTerbaru = "1";
        }
        #endregion

        #region METHOD
        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();
            //tuliskan perintah SQL yang akan dijalankan
            string sql = "SELECT * FROM Supplier";
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
                    
                    //create objek bertipe Pelanggan
                    Supplier s = new Supplier(kode, nama, alamat);
                    //simpan ke list
                    listSupplier.Add(s);
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
            string sql = "SELECT * FROM Supplier WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
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
                   
                    //create objek bertipe Pelanggan
                    Supplier s = new Supplier(kode, nama, alamat);
                    //simpan ke list
                    listSupplier.Add(s);
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
            string sql = "SELECT KodeSupplier FROM Supplier ORDER BY KodeSupplier DESC LIMIT 1";
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
                    int kdTerbaru = int.Parse(data.GetValue(0).ToString()) + 1;
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

        public string TambahData(Supplier s)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "INSERT INTO Supplier(KodePelanggan, Nama, Alamat) VALUES ('" + s.KodeSupplier + "','" + s.NamaSupplier + "','" + s.AlamatSupplier + "')";

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
        public string UbahData(Supplier s)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "UPDATE Supplier SET Nama = '" + s.NamaSupplier + "', Alamat = '" + s.AlamatSupplier +  "' WHERE KodePelanggan = '" + s.KodeSupplier + "'";

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
        public string HapusData(Supplier s)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "DELETE FROM Supplier WHERE KodeSupplier = '" + s.KodeSupplier + "'";

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
