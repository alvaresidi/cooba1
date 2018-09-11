using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using MySql.Data.MySqlClient;

namespace PenjualanPembelian_LIB
{
   public class DaftarPegawai
    {
        private List<Pegawai> listPegawai;
        private string kodeTerbaru;

        #region Properties
        public List<Pegawai> ListPegawai
        {
            get { return listPegawai; }
        }
        public int JumlahPegawai
        {
            get { return listPegawai.Count; }
        }
        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }
        #endregion

       #region Constractor
        public DaftarPegawai()
        {
            listPegawai = new List<Pegawai>();
            kodeTerbaru = "1";
        }
        #endregion

        #region Method
        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();
            //tuliskan perintah SQL yang akan dijalankan
            string sql = "SELECT B.KodePegawai, B.Nama,B.TglLahir, B.Alamat,B.Gaji,B.Username,B.Password ,K.IdJabatan, K.Nama AS kategori " +
                " FROM Pegawai B INNER JOIN Jabatan K ON B.IdJabatan=K.IdJabatan" +
                " ORDER BY B.KodePegawai ASC";
            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data = c.ExecuteReader();

                //selama data reader masih bisa terbaca (selama masih ada data)
                while (data.Read() == true)
                {
                    
                    string kode = data.GetValue(0).ToString();
                   
                    string nama = data.GetValue(1).ToString();
                   
                    DateTime tgl = DateTime.Parse(data.GetValue(2).ToString());
                    string alamat = data.GetValue(3).ToString();
                    int gaji = int.Parse(data.GetValue(4).ToString());
                    string user = data.GetValue(5).ToString();
                    string pass = data.GetValue(6).ToString();
                   

                    string idJ = data.GetValue(7).ToString();
                    
                    string nmJ = data.GetValue(8).ToString();
                    //create objek bertipe Kategori
                    Jabatan jb = new Jabatan(idJ, nmJ);
                    //simpan ke list
                    Pegawai pg = new Pegawai(kode, nama,tgl,alamat,gaji,user,pass,jb);
                    listPegawai.Add(pg);
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
            string sql = "SELECT B.KodePegawai, B.Nama,B.TglLahir, B.Alamat,B.Gaji,B.Username,B.Password ,K.IdJabatan, K.Nama AS kategori" +
                " FROM Pegawai B INNER JOIN Jabatan K ON B.IdJabatan=K.IdJabatan" +
                " WHERE B." + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data = c.ExecuteReader();

                //selama data reader masih bisa terbaca (selama masih ada data)
                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();

                    string nama = data.GetValue(1).ToString();
                    DateTime tgl = DateTime.Parse(data.GetValue(2).ToString());
                    string alamat = data.GetValue(3).ToString();
                    int gaji = int.Parse(data.GetValue(4).ToString());
                    string user = data.GetValue(5).ToString();
                    string pass = data.GetValue(6).ToString();


                    string idJ = data.GetValue(7).ToString();

                    string nmJ = data.GetValue(8).ToString();
                    //create objek bertipe Kategori
                    Jabatan jb = new Jabatan(idJ, nmJ);
                    //simpan ke list
                    Pegawai pg = new Pegawai(kode, nama, tgl, alamat, gaji, user, pass, jb);
                    listPegawai.Add(pg);
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
            string sql = "SELECT KodePegawai FROM Pegawai ORDER BY KodePegawai DESC LIMIT 1";
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
                   

                    //Format kode kategori
                    int kdTerbaru = int.Parse(data.GetValue(0).ToString()) + 1;
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
        public string TambahData(Pegawai pg)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "INSERT INTO Pegawai(KodePegawai, Nama,TglLahir,Alamat,Gaji,Username,Password,IdJabatan) VALUES ('" + pg.KodePegawai + "','" + pg.NamaPegawai + "','" + pg.TglLahir.ToString("yyyy-MM-dd") + "','" + pg.Alamat + "','" + pg.Gaji + "','" +
                  pg.Username + "','" + pg.Password + "','" + pg.KategoriJabatan.IdJabatan +"')";

            //Buat MySqlCommand 
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                //Gunakan ExecuteNonQuery untuk menjalankan perintah INSERT/UPDATE/DELETE
                c.ExecuteNonQuery();

                string hasilBuatUser = BuatUserBaru(pg, "localhost");
                if(hasilBuatUser=="sukses")
                {
                    string hasilberiHak = BeriHakAkses(pg, "localhost");
                    if(hasilberiHak=="sukses")
                    {
                        return "sukses";
                    }
                    else
                    {
                        return "gagal memberikan hak akses. pesan kesalanhan = " + hasilberiHak;
                    }
                    
                }
                else
                {
                    return "Gagal  membuat user. pesan Kesalahan = " + hasilBuatUser;

                }
                
               
            }
            catch (Exception e)
            {
                return "pesan gagal "  + e.Message;
            }
        }
        public string UbahData(Pegawai pg)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan
            string sql = "UPDATE pegawai SET Nama='" +pg.NamaPegawai+ "',TglLahir='" + pg.TglLahir.ToString("yyyy-MM-dd") + "', Alamat='" +
                pg.Alamat + "', Gaji='" + pg.Gaji+"',Username='"+ pg.Username + "', Password='" + pg.Password + "', IdJabatan='" +
                pg.KategoriJabatan.IdJabatan+"' WHERE KodePegawai = '"+ pg.KodePegawai + "'";

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

        public string BuatUserBaru(Pegawai pg,string namaServer)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "CREATE USER '" + pg.Username + "'@'" + namaServer + "' IDENTIFIED BY '" + pg.Password + "'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                c.ExecuteNonQuery();

                return "sukses";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

       public string BeriHakAkses(Pegawai pg, string namaServer)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "GRANT ALL PRIVILEGES ON si_jual_beli.* TO '" + pg.Username + "'@'" + namaServer+ "'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                c.ExecuteNonQuery();

                return "sukses";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       public string ubahPasswordUser( string user, string pass)
       {
           Koneksi k = new Koneksi();
           k.Connect();

           string sql = "SET PASSWORD FOR '"+user+"'@'localhost=PASSWORD('"+pass+"')";

           MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

           try
           {
               c.ExecuteNonQuery();

               return "sukses";
           }
           catch (Exception ex)
           {
               return ex.Message;
           }
       }

       public string HapusData(Pegawai pg)
       {
           Koneksi k = new Koneksi();
           k.Connect();

           //tuliskan perintah SQL yang akan dijalankan
           string sql = "DELETE FROM Pegawai WHERE KodeBarang = '" + pg.KodePegawai + "'";

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

       public string HapusUser(string user, string pass)
       {
           Koneksi k = new Koneksi();
           k.Connect();

           string sql = "DROP USER '"+ user +"'@'localhost'";

           MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

           try
           {
               c.ExecuteNonQuery();

               return "sukses";
           }
           catch (Exception ex)
           {
               return ex.Message;
           }
       }

        #endregion
    }
}
