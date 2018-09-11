using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PenjualanPembelian_LIB
{
    public class DaftarNotaBeli
    {
        private List<NotaBeli> listNotaBeli;
        private string noNotaTerbaru;

        #region PROPERTIES
        public List<NotaBeli> ListNotaBeli
        {
            get { return listNotaBeli; }
        }
        public int JumlahNotaBeli
        {
            get { return listNotaBeli.Count; }
        }
        public string NoNotaTerbaru
        {
            get { return noNotaTerbaru; }
        }
        #endregion 

        #region CONSTRUCTOR

        public DaftarNotaBeli()
        {
            listNotaBeli = new List<NotaBeli>();
            noNotaTerbaru = "20171115001";
        }

        #endregion

        #region METHOD
        public string GenerateNoNota()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT SUBSTRING(NoNota,9,3) AS noUrutTransaksi " +
                "FROM NotaBeli WHERE Date(Tanggal)=Date(CURRENT_DATE) " +
                "ORDER BY NoNota DESC LIMIT 1";
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {

                MySqlDataReader data = c.ExecuteReader();

                string noUrutTransTerbaru = "";
                if (data.Read() == true)
                {
                    int noUrutTrans = int.Parse(data.GetValue(0).ToString()) + 1;
                    noUrutTransTerbaru = noUrutTrans.ToString();
                    if (noUrutTransTerbaru.Length == 1)
                    {
                        noUrutTransTerbaru = "00" + noUrutTransTerbaru;

                    }
                    else if (noUrutTransTerbaru.Length == 2)
                    {
                        noUrutTransTerbaru = "0" + noUrutTransTerbaru;
                    }
                }
                else
                {
                    noUrutTransTerbaru = "001";
                }

                string tahun = DateTime.Now.Year.ToString();
                string bulan = DateTime.Now.Month.ToString();

                if (bulan.Length == 1)
                {
                    bulan = "0" + bulan;
                }

                string tanggal = DateTime.Now.Day.ToString();
                if (tanggal.Length == 1)
                {
                    tanggal = "0" + tanggal;
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

        public string TambahData(NotaBeli nota)
        {
            Koneksi k1 = new Koneksi();
            k1.Connect();

            string sql1 = "INSERT INTO NotaBeli(NoNota,Tanggal,KodeSupplier,KodePegawai) VALUES('" + nota.NoNota + "','" +
                nota.Tanggal.ToString("yyyy-MM-dd hh:mm;ss") + "','" + nota.Supplier.KodeSupplier + "','" +
                nota.Pegawai.KodePegawai + "')";

            MySqlCommand c1 = new MySqlCommand(sql1, k1.KoneksiDB);
            try
            {

                c1.ExecuteNonQuery();
                for (int i = 0; i < nota.JumlahBarangNota; i++)
                {
                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "INSERT INTO NotaBeliDetil(NoNota,KodeBarang,Harga,Jumlah) VALUES ('" + nota.NoNota + "','" +
                        nota.ListNotaDetil[i].BarangNota.KodeBarang + "','" + nota.ListNotaDetil[i].HargaBeli + "','" +
                        nota.ListNotaDetil[i].JumlahBeli + "')";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    c2.ExecuteNonQuery();
                }
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
