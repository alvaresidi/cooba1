using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenjualanPembelian_LIB
{
    public class Barang
    {
        private string kodeBarang;
        private string namaBarang;
        private int hargaJual;
        private int stok;
        private Kategori kategoriBarang;

        #region PRopreties
        public string KodeBarang
        {
            get { return kodeBarang; }
            set { kodeBarang = value; }
        }
        public string NamaBarang
        {
            get { return namaBarang; }
            set { namaBarang = value; }
        }
        public int HargaJual
        {
            get { return hargaJual; }
            set { hargaJual = value; }
        }
        public int Stok
        {
            get { return stok; }
            
        }
        public Kategori KategoriBarang
        {
            get { return kategoriBarang; }
            set { kategoriBarang = value; }
        }


        #endregion
        #region Constructor
        public Barang()
        {
            kodeBarang = "";
            namaBarang = "";
            hargaJual = 0;
            stok = 0;
            kategoriBarang = new Kategori();
        }
        public Barang(string kbrng,string nmbrng,int hjual,int stk,Kategori ktgribrng)
        {
            kodeBarang = kbrng;
            namaBarang = nmbrng;
            hargaJual = hjual;
            stok = stk;
            kategoriBarang = ktgribrng;
        }
        #endregion
    }
}
