using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace PenjualanPembelian_LIB
{
    public class DaftarKategori
    {
        private List<Kategori> listKategori;
        private string kodeTerbaru;

        #region PROPERTIES
        public List<Kategori> DaftarKategoriBarang
        {
            get { return listKategori; }
        }

        public int JumlahKategoriBarang
        {
            get { return listKategori.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }
        #endregion

        #region CONSTRUCTOR
        public DaftarKategori()
        {
            listKategori = new List<Kategori>();
            kodeTerbaru = "01";
        }
        #endregion

        #region METHOD
        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();
            //tuliskan perintah SQL yang akan dijalankan
            string sql = "SELECT * FROM Kategori";
            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data = c.ExecuteReader();

                //selama data reader masih bisa terbaca (selama masih ada data)
                while (data.Read() == true)
                {
                    //mendapatkan kode kategori dari hasil data reader
                    string kode = data.GetValue(0).ToString();
                    //mendapatkan nama kategori dari hasil data reader
                    string nama = data.GetValue(1).ToString();
                    //create objek bertipe Kategori
                    Kategori kt = new Kategori(kode, nama);
                    //simpan ke list
                    listKategori.Add(kt);
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
            string sql = "SELECT * FROM Kategori WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data = c.ExecuteReader();

                //selama data reader masih bisa terbaca (selama masih ada data)
                while (data.Read() == true)
                {
                    //mendapatkan kode kategori dari hasil data reader
                    string kode = data.GetValue(0).ToString();
                    //mendapatkan nama kategori dari hasil data reader
                    string nama = data.GetValue(1).ToString();
                    //create objek bertipe Kategori
                    Kategori kt = new Kategori(kode, nama);
                    //simpan ke list
                    listKategori.Add(kt);
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
            string sql = "SELECT KodeKategori FROM Kategori ORDER BY KodeKategori DESC LIMIT 1";
            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data = c.ExecuteReader();

                //jika data reader bisa terbaca (selama masih ada data)
                if (data.Read() == true)
                {
                    //mendapatkan kode kategori dari hasil data reader
                    int kdTerbaru = int.Parse(data.GetValue(0).ToString())+1;
                    kodeTerbaru = kdTerbaru.ToString();

                    //Format kode kategori
                    if (kodeTerbaru.Length == 1)
                    {
                        kodeTerbaru = "0" + kodeTerbaru;
                    }
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

        public string TambahData(Kategori kat)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "INSERT INTO kategori(KodeKategori, Nama) VALUES ('" + kat.KodeKategori + "','" + kat.NamaKategori + "')";

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
        public string UbahData(Kategori kat)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "UPDATE kategori SET nama = '" + kat.NamaKategori + "' WHERE KodeKategori = '" + kat.KodeKategori + "'";

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
        public string HapusData(Kategori kat)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "DELETE FROM kategori WHERE KodeKategori = '" + kat.KodeKategori + "'";

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
