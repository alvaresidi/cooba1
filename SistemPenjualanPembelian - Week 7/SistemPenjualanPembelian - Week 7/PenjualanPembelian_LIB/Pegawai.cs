using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenjualanPembelian_LIB
{
    public class Pegawai
    {
        private string kodePegawai;
        private string namaPegawai;
        private DateTime tglLahir;
       
        private string alamat;
        private int gaji;
        private string username;
        private string password;
        private Jabatan kategoriJabatan;


        #region Propreties
        public string KodePegawai
        {
            get { return kodePegawai; }
            set { kodePegawai = value; }
        }
        public string NamaPegawai
        {
            get { return namaPegawai; }
            set { namaPegawai = value; }
        }

        public DateTime TglLahir
        {
            get { return tglLahir; }
            set { tglLahir = value; }
        }
        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }
        public int Gaji
        {
            get { return gaji; }
            set { gaji = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }

        }
        public string Password
        {
            get { return password; }
            set { password = value; }

        }
        public Jabatan KategoriJabatan
        {
            get { return kategoriJabatan; }
            set { kategoriJabatan = value; }
        }


        #endregion

        #region Constructor
        public Pegawai()
        {
            kodePegawai = "";
            namaPegawai = "";
            tglLahir = new DateTime();
            alamat = "";
            gaji = 0;
            username = "";
            password = "";
            kategoriJabatan = new Jabatan();
        }
        public Pegawai(string kdpg,string nmpg,DateTime tgl,string  al,int gj,string  user,string pass, Jabatan ktgrijb)
        {
            kodePegawai=kdpg;
         namaPegawai=nmpg;
         tglLahir=tgl;
         alamat=al;
         gaji=gj;
         username=user;
         password=pass;
         kategoriJabatan= ktgrijb;
        }
        #endregion
    }
}
