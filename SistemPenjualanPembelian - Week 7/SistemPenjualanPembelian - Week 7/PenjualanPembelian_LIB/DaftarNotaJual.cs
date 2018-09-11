using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PenjualanPembelian_LIB
{
    public class DaftarNotaJual
    {
        private List<NotaJual> listNotaJual;
        private string noNotaTerbaru;

        #region PROPERTIES
        public List<NotaJual> ListNotaJual
        {
            get { return listNotaJual; }
        }
        public int JumlahNotaJual
        {
            get { return listNotaJual.Count; }
        }
        public string NoNotaTerbaru
        {
            get { return noNotaTerbaru; }
        }
        #endregion 

        #region CONSTRUCTOR

        public DaftarNotaJual()
        {
            listNotaJual = new List<NotaJual>();
            noNotaTerbaru = "20171109001";
        }

        #endregion

        #region METHOD
        public string BacaSemuaData()
        {
            Koneksi k1 = new Koneksi();
            k1.Connect();

            string sql1 = "SELECT N.NoNota,N.Tanggal, N.KodePelanggan, Plg.Nama AS NamaPelanggan, Plg.Alamat AS AlamatPelanggan, N.KodePegawai, Peg.Nama AS NamaPegawai " +
                " FROM NotaJual N INNER JOIN Pelanggan Plg ON N.KodePelanggan=Plg.KodePelanggan " +
                " INNER JOIN Pegawai Peg ON N.KodePegawai=Peg.KodePegawai " +
                " ORDER BY N.NoNota DESC ";
            MySqlCommand c1 = new MySqlCommand(sql1, k1.KoneksiDB);

            try
            {
                MySqlDataReader data1 = c1.ExecuteReader();
                while (data1.Read() == true)
                {
                    string nomorNota = data1.GetValue(0).ToString();
                    DateTime tglNota = DateTime.Parse(data1.GetValue(1).ToString());
                    string kdPelanggan = data1.GetValue(2).ToString();
                    string nmPelanggan = data1.GetValue(3).ToString();
                    string alamatPelanggan = data1.GetValue(4).ToString();

                    Pelanggan Plg = new Pelanggan();
                    Plg.KodePelanggan = kdPelanggan;
                    Plg.NamaPelanggan = nmPelanggan;
                    Plg.AlamatPelanggan = alamatPelanggan;

                    string kdPegawai = data1.GetValue(5).ToString();
                    string nmPegawai = data1.GetValue(6).ToString();

                    Pegawai Peg = new Pegawai();
                    Peg.KodePegawai=kdPegawai;
                    Peg.NamaPegawai=nmPegawai;

                    List<DetilNotaJual> listDetilNota = new List<DetilNotaJual>();

                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "SELECT NJD.KodeBarang, B.Nama, NJD.Harga, NJD.Jumlah " +
                        " FROM notajual N INNER JOIN notajualdetil NJD ON N.NoNota=NJD.NoNota " +
                        " INNER JOIN Barang B ON NJD.KodeBarang = B.KodeBarang " +
                        " WHERE N.NoNota = '" + nomorNota + "'";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    MySqlDataReader data2 = c2.ExecuteReader();
                    while (data2.Read() == true)
                    {
                        string kdBarang = data2.GetValue(0).ToString();
                        string nmBarang = data2.GetValue(1).ToString();
                        Barang Brg = new Barang();
                        Brg.KodeBarang = kdBarang;
                        Brg.NamaBarang = nmBarang;

                        int hrgJual = int.Parse(data2.GetValue(2).ToString());
                        int jmlJual = int.Parse(data2.GetValue(3).ToString());

                        DetilNotaJual detilNota = new DetilNotaJual(Brg, hrgJual, jmlJual);

                        listDetilNota.Add(detilNota);
                    }

                    c2.Dispose();
                    data2.Dispose();

                    NotaJual nota = new NotaJual(nomorNota, tglNota, Plg, Peg, listDetilNota);

                    listNotaJual.Add(nota);

                }
                c1.Dispose();
                data1.Dispose();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string GenerateNoNota()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT SUBSTRING(NoNota,9,3) AS noUrutTransaksi " +
                "FROM NotaJual WHERE Date(Tanggal)=Date(CURRENT_DATE) " +
                "ORDER BY NoNota DESC LIMIT 1";
            MySqlCommand c = new MySqlCommand(sql,k.KoneksiDB);

            try{
               
                MySqlDataReader data = c.ExecuteReader();

                string noUrutTransTerbaru="";
                if(data.Read()==true)
                {
                    int noUrutTrans = int.Parse(data.GetValue(0).ToString()) + 1;
                    noUrutTransTerbaru=noUrutTrans.ToString();
                    if(noUrutTransTerbaru.Length==1)
                    {
                        noUrutTransTerbaru="00" + noUrutTransTerbaru;

                    }
                    else if (noUrutTransTerbaru.Length==2)
                    {
                        noUrutTransTerbaru="0" + noUrutTransTerbaru;
                    }
                }
                else
                {
                    noUrutTransTerbaru="001";
                }

                string tahun = DateTime.Now.Year.ToString();
                string bulan = DateTime.Now.Month.ToString();

                if(bulan.Length==1)
                {
                    bulan="0" + bulan;
                }

                string tanggal = DateTime.Now.Day.ToString();
                if(tanggal.Length==1)
                {
                    tanggal="0"+tanggal;
                }
                noNotaTerbaru = tahun + bulan + tanggal + noUrutTransTerbaru.ToString();

                c.Dispose();
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
            Koneksi k1 = new Koneksi();
            k1.Connect();
            //tuliskan perintah SQL yang akan dijalankan
            string sql = "SELECT N.NoNota,N.Tanggal, N.KodePelanggan, Plg.Nama AS NamaPelanggan, Plg.Alamat AS AlamatPelanggan, N.KodePegawai, Peg.Nama AS NamaPegawai " +
                " FROM NotaJual N INNER JOIN Pelanggan Plg ON N.KodePelanggan=Plg.KodePelanggan " +
                " INNER JOIN Pegawai Peg ON N.KodePegawai=Peg.KodePegawai " +
                " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            //Buat MySqlCommand 
            MySqlCommand c1 = new MySqlCommand(sql, k1.KoneksiDB);
            try
            {
                //Gunakan MySqlDataReader dan ExecuteReader untuk menjalankan perintah SELECT
                MySqlDataReader data1 = c1.ExecuteReader();

                //selama data reader masih bisa terbaca (selama masih ada data)
                while (data1.Read() == true)
                {
                    //mendapatkan kode kategori dari hasil data reader
                    string nomorNota = data1.GetValue(0).ToString();
                    //mendapatkan nama kategori dari hasil data reader
                    DateTime tglNota = DateTime.Parse(data1.GetValue(1).ToString());
                    string kdPlg = data1.GetValue(2).ToString();

                    string nmPlg = data1.GetValue(3).ToString();
                    string almatPlg = data1.GetValue(4).ToString();

                    Pelanggan Plg = new Pelanggan();
                    Plg.KodePelanggan = kdPlg;
                    Plg.NamaPelanggan = nmPlg;
                    Plg.AlamatPelanggan = almatPlg;

                    string kodePeg = data1.GetValue(5).ToString();
                    string nmPeg = data1.GetValue(6).ToString();
                    Pegawai Peg = new Pegawai();
                    Peg.KodePegawai = kodePeg;
                    Peg.NamaPegawai = nmPeg;

                    List<DetilNotaJual> listDetilNota = new List<DetilNotaJual>();

                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "SELECT NJD.KodeBarang, B.Nama, NJD.Harga, NJD.Jumlah " +
                        " FROM notajual N INNER JOIN notajualdetil NJD ON N.NoNota=NJD.NoNota " +
                        " INNER JOIN Barang B ON NJD.KodeBarang = B.KodeBarang " +
                        " WHERE N.NoNota = '" + nomorNota + "'";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    MySqlDataReader data2 = c2.ExecuteReader();
                    while (data2.Read() == true)
                    {
                        string kdBarang = data2.GetValue(0).ToString();
                        string nmBarang = data2.GetValue(1).ToString();
                        Barang Brg = new Barang();
                        Brg.KodeBarang = kdBarang;
                        Brg.NamaBarang = nmBarang;

                        int hrgJual = int.Parse(data2.GetValue(2).ToString());
                        int jmlJual = int.Parse(data2.GetValue(3).ToString());

                        DetilNotaJual detilNota = new DetilNotaJual(Brg, hrgJual, jmlJual);

                        listDetilNota.Add(detilNota);
                    }

                    c2.Dispose();
                    data2.Dispose();

                    NotaJual nota = new NotaJual(nomorNota, tglNota, Plg, Peg, listDetilNota);

                    listNotaJual.Add(nota);

                }
                c1.Dispose();
                data1.Dispose();
                return "sukses";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public string TambahData(NotaJual nota)
        {
            Koneksi k1 = new Koneksi();
            k1.Connect();

            string sql1 = "INSERT INTO NotaJual(NoNota,Tanggal,KodePelanggan,KodePegawai) VALUES('" + nota.NoNota + "','" +
                nota.Tanggal.ToString("yyyy-MM-dd hh:mm;ss") + "','" + nota.Pelanggan.KodePelanggan + "','" +
                nota.Pegawai.KodePegawai + "')";

            MySqlCommand c1 = new MySqlCommand(sql1, k1.KoneksiDB);
            try{

                c1.ExecuteNonQuery();
                for(int i=0;i<nota.JumlahBarangNota;i++)
                {
                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "INSERT INTO NotaJualDetil(NoNota,KodeBarang,Harga,Jumlah) VALUES ('" +nota.NoNota + "','"+
                        nota.ListNotaDetil[i].BarangNota.KodeBarang + "','" + nota.ListNotaDetil[i].HargaJual + "','" +
                        nota.ListNotaDetil[i].JumlahJual + "')";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    c2.ExecuteNonQuery();

                    string hasilUpdateBrg = UpdateStokBarang(nota.ListNotaDetil[i]);
                }
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdateStokBarang(DetilNotaJual detilNota)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "";
            sql = " UPDATE barang SET Stok = Stok - " + detilNota.JumlahJual +
                " WHERE KodeBarang = '" + detilNota.BarangNota.KodeBarang + "'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                c.ExecuteNonQuery();

                return "sukses";
            }
            catch(Exception e)
            {
                return e.Message;
            }

        }

        #endregion
    }
}
