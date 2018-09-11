using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenjualanPembelian_LIB
{
    public class NotaBeli
    {
        private string noNota;
        private DateTime tanggal;
        private Supplier supplier;
        private Pegawai pegawai;

        private List<NotaBeliDetil> listNotaDetil;

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
        public Supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
        public Pegawai Pegawai
        {
            get { return pegawai; }
            set { pegawai = value; }
        }
        public List<NotaBeliDetil> ListNotaDetil
        {
            get { return listNotaDetil; }
        }

        public int JumlahBarangNota
        {
            get { return listNotaDetil.Count; }
        }
        #endregion

        #region CONSTRUCTOR

        public NotaBeli()
        {
            noNota = "";
            tanggal = new DateTime();
            supplier = new Supplier();
            pegawai = new Pegawai();
            List<NotaBeliDetil> listnotaDetil = new List<NotaBeliDetil>();

        }
        public NotaBeli(string _noNota, DateTime _tanggalNota, Supplier _supplier, Pegawai pembuat, List<NotaBeliDetil> listNotaJualDetil)
        {
            noNota = _noNota;
            tanggal = _tanggalNota;
            supplier = _supplier;
            pegawai = pembuat;
            listNotaDetil = listNotaJualDetil;

        }
        #endregion

    }
}
