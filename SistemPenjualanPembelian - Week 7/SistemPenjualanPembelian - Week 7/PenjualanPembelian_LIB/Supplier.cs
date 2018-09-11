using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenjualanPembelian_LIB
{
    public class Supplier
    {
        private string kodeSupplier;
        private string namaSupplier;
        private string alamatSupplier;

        #region PROPERTIES
        public string KodeSupplier
        {
            get { return kodeSupplier; }
            set { kodeSupplier = value; }
        }
        public string NamaSupplier
        {
            get { return namaSupplier; }
            set { namaSupplier = value; }
        }
        public string AlamatSupplier
        {
            get { return alamatSupplier; }
            set { alamatSupplier = value; }
        }
       
        #endregion

         #region CONSTRUCTOR
        public Supplier()
        {
            kodeSupplier = "";
            namaSupplier = "";
            alamatSupplier = "";
            
        }
        public Supplier(string kode, string nama, string alamat)
        {
            kodeSupplier = kode;
            namaSupplier = nama;
            alamatSupplier = alamat;
           
        }
        #endregion
    }
}
