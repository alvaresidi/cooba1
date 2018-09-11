using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PenjualanPembelian_LIB
{
    public class DaftarBarang
    {
        private List<Barang> listBarang;
        private string kodeterbaru;

        #region Properties
        public List<Barang> ListBarang
        {
            get { return listBarang; }
        }
        public int JumlahBarang
        {
            get { return listBarang.Count; }
        }
        public string KodeTerbaru
        {
            get { return kodeterbaru; }
        }
        #endregion

        #region Constractor
        public DaftarBarang()
        {
            listBarang = new List<Barang>();
            kodeterbaru = "B0001";
        }
        #endregion

        #region Method
        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();
            //tuliskan perintah SQL yang akan dijalankan
            string sql = "SELECT B.KodeBarang, B.Nama,B.HargaJual, B.Stok, K.KodeKategori, K.Nama AS kategori" + 
                " FROM Barang B INNER JOIN Kategori K ON B.kodeKategori=K.KodeKategori ";
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
                    int hrgJual = int.Parse(data.GetValue(2).ToString());
                    int stok = int.Parse(data.GetValue(3).ToString());

                    string kdKategori = data.GetValue(4).ToString();

                    string nmKategori = data.GetValue(5).ToString();
                    //create objek bertipe Kategori
                    Kategori kat = new Kategori(kdKategori, nmKategori);
                    //simpan ke list
                    Barang brg = new Barang(kode, nama, hrgJual, stok, kat);
                    listBarang.Add(brg);
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
            string sql = "SELECT B.KodeBarang, B.Nama, B.HargaJual, B.Stok, K.KodeKategori, K.Nama AS kategori FROM Barang B " +
                "INNER JOIN Kategori K ON B.kodeKategori=K.KodeKategori " +
                "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
           
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
                    int hrgJual = int.Parse(data.GetValue(2).ToString());
                    int stok = int.Parse(data.GetValue(3).ToString());

                    string kdKategori = data.GetValue(4).ToString();

                    string nmKategori = data.GetValue(5).ToString();
                    //create objek bertipe Kategori
                    Kategori kat = new Kategori(kdKategori, nmKategori);
                    //simpan ke list
                    Barang brg = new Barang(kode, nama, hrgJual, stok, kat);
                    listBarang.Add(brg);
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
            string sql = "SELECT SUBSTRING(KodeBarang,2,4) FROM Barang ORDER BY KodeBarang DESC LIMIT 1";
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
                    int kdTerbaru = int.Parse(data.GetValue(0).ToString()) + 1;
                    kodeterbaru = kdTerbaru.ToString();

                    //Format kode kategori
                    if (kodeterbaru.Length == 1)
                    {
                        kodeterbaru = "B000" + kodeterbaru;
                    }
                    else if(kodeterbaru.Length == 2)
                    {
                        kodeterbaru = "B00" + kodeterbaru;
                    }
                    else if (kodeterbaru.Length == 3)
                    {
                        kodeterbaru = "B0" + kodeterbaru;
                    }
                    else 
                    {
                        kodeterbaru = "B" + kodeterbaru;
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
        public string TambahData(Barang brg)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "INSERT INTO Barang(KodeBarang, Nama,HargaJual,Stok,KodeKategori) VALUES ('" + brg.KodeBarang + "','" + brg.NamaBarang + "','" +brg.HargaJual + "','"+ brg.Stok+ "','"+ brg.KategoriBarang.KodeKategori + "')";

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
        public string UbahData(Barang brg)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "UPDATE barang SET Nama = '" + brg.NamaBarang +"', HargaJual = '" + brg.HargaJual + "', Stok = '" + brg.Stok + "', KodeKategori = '" + brg.KategoriBarang.KodeKategori 
                +"' WHERE KodeBarang = '" + brg.KodeBarang + "'";

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

        public string HapusData(Barang brg)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "DELETE FROM Barang WHERE KodeBarang = '" + brg.KodeBarang + "'";

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

        private void FormatDataGrid()
        {
            
        }

        #endregion

        
    }
}
