using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenjualanPembelian_LIB
{
    public class NotaJual
    {
        private string noNota;
        private DateTime tanggal;
        private Pelanggan pelanggan;
        private Pegawai pegawai;

        private List<DetilNotaJual> listNotaDetil;

        #region PROPERTIES
        public string NoNota
        {
            get { return noNota; }
            set { noNota = value; }
        }

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }
        public Pelanggan Pelanggan
        {
            get { return pelanggan; }
            set { pelanggan = value; }
        }
        public Pegawai Pegawai
        {
            get { return pegawai; }
            set { pegawai = value; }
        }
        public List<DetilNotaJual> ListNotaDetil
        {
            get { return listNotaDetil; }
        }

        public int JumlahBarangNota
        {
            get { return listNotaDetil.Count; }
        }
        #endregion

        #region CONSTRUCTOR

        public NotaJual()
        {
            noNota = "";
            tanggal = new DateTime();
            pelanggan = new Pelanggan();
            pegawai = new Pegawai();
            List<DetilNotaJual> listnotaDetil = new List<DetilNotaJual>();

        }
        public NotaJual(string _noNota, DateTime _tanggalNota, Pelanggan _pelanggan, Pegawai pembuat, List<DetilNotaJual> listNotaJualDetil)
        {
            noNota = _noNota;
            tanggal = _tanggalNota;
            pelanggan = _pelanggan;
            pegawai = pembuat;
            listNotaDetil = listNotaJualDetil;

        }
        #endregion
    }
}
