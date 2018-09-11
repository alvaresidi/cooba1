using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using System.Configuration;

namespace PenjualanPembelian_LIB
{
    public class Jabatan
    {
         private string idJabatan;
        private string namaJabatan;

        #region PROPERTIES
        public string IdJabatan
        {
            get { return idJabatan;  }
            set { idJabatan = value; }
        }
        public string NamaJabatan
        {
            get { return namaJabatan; }
            set { namaJabatan = value; }
        }
        #endregion

        #region CONSTRUCTOR
        public Jabatan()
        {
            idJabatan = "";
            namaJabatan = "";
        }
        public Jabatan(string kode, string nama)
        {
            idJabatan = kode;
            namaJabatan = nama;
        }
        #endregion
    }
}
