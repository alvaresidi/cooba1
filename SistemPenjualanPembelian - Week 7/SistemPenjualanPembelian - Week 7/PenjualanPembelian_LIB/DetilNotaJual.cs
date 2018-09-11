using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenjualanPembelian_LIB
{
    public class DetilNotaJual
    {
        private Barang barangNota;
        private int hargaJual;
        private int jumlahJual;

        #region PROPERTIES

        public Barang BarangNota
        {
            get { return barangNota; }
            set { barangNota = value; }
        }

        public int HargaJual
        {
            get { return hargaJual; }
            set { hargaJual = value; }
        }

        public int JumlahJual
        {
            get { return jumlahJual; }
            set { jumlahJual = value; }
        }
        #endregion

        #region CONSTRACTOR
        public DetilNotaJual()
        {
            barangNota = new Barang();
            hargaJual = 0;
            jumlahJual = 0;
        }
        public DetilNotaJual(Barang barang, int harga, int jumlah)
        {
            barangNota = barang;
            hargaJual = harga;
            jumlahJual = jumlah;
        }

        #endregion
    }
}
