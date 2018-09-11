using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenjualanPembelian_LIB
{
    public class Pelanggan
    {
        private string kodePelanggan;
        private string namaPelanggan;
        private string alamatPelanggan;
        private string telepon;

        #region PROPERTIES
        public string KodePelanggan
        {
            get { return kodePelanggan;  }
            set { kodePelanggan = value; }
        }
        public string NamaPelanggan
        {
            get { return namaPelanggan; }
            set { namaPelanggan = value; }
        }
        public string AlamatPelanggan
        {
            get { return alamatPelanggan; }
            set { alamatPelanggan = value; }
        }
        public string Telepon
        {
            get { return telepon; }
            set { telepon = value; }
        }
        #endregion

        #region CONSTRUCTOR
        public Pelanggan()
        {
            kodePelanggan = "";
            namaPelanggan = "";
            alamatPelanggan = "";
            telepon = "";
        }
        public Pelanggan(string kode, string nama, string alamat, string telp)
        {
            kodePelanggan = kode;
            namaPelanggan = nama;
            alamatPelanggan = alamat;
            telepon = telp;
        }
        #endregion

        #region METHOD


        #endregion

    }
}
