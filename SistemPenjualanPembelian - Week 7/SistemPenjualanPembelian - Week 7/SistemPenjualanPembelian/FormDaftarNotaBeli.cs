using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemPenjualanPembelian
{
    public partial class FormDaftarNotaBeli : Form
    {
        public FormDaftarNotaBeli()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaBeli ftb = new FormTambahNotaBeli();
            ftb.Owner = this;
            ftb.ShowDialog();
        }

        private void FormDaftarNotaBeli_Load(object sender, EventArgs e)
        {

        }
    }
}
