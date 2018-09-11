using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenjualanPembelian_LIB
{
    public class NotaBeliDetil
    {
        private Barang barangNota;
        private int hargabeli;
        private int jumlahbeli;

        #region PROPERTIES

        public Barang BarangNota
        {
            get { return barangNota; }
            set { barangNota = value; }
        }

        public int HargaBeli
        {
            get { return hargabeli; }
            set { hargabeli = value; }
        }

        public int JumlahBeli
        {
            get { return jumlahbeli; }
            set { jumlahbeli = value; }
        }
        #endregion
        #region CONSTRACTOR
        public NotaBeliDetil()
        {
            barangNota = new Barang();
            hargabeli = 0;
            jumlahbeli = 0;
        }
        public NotaBeliDetil(Barang barang, int harga, int jumlah)
        {
            barangNota = barang;
            hargabeli = harga;
            jumlahbeli = jumlah;
        }

        #endregion
    }
}
