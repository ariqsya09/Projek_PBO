using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projek_PBO
{
    public partial class Beranda : Form
    {
        public Beranda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Barang barang = new Barang();
            barang.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transaksi transaksi = new Transaksi();
            transaksi.Show();
        }
    }
}
