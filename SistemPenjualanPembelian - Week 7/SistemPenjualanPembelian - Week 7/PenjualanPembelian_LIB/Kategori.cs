using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using System.Configuration;

namespace PenjualanPembelian_LIB
{
    public class Kategori
    {
        private string kodeKategori;
        private string namaKategori;

        #region PROPERTIES
        public string KodeKategori
        {
            get { return kodeKategori;  }
            set { kodeKategori = value; }
        }
        public string NamaKategori
        {
            get { return namaKategori; }
            set { namaKategori = value; }
        }
        #endregion

        #region CONSTRUCTOR
        public Kategori()
        {
            kodeKategori = "";
            namaKategori = "";
        }
        public Kategori(string kode, string nama)
        {
            kodeKategori = kode;
            namaKategori = nama;
        }
        #endregion

        #region METHOD


        #endregion
    }
}
