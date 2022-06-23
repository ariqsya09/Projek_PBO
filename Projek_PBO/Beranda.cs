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
        private int id_operator;
        public Beranda(int id_operator)
        {
            InitializeComponent();
            this.id_operator = id_operator;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Barang barang = new Barang();
            this.Hide();
            barang.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transaksi transaksi = new Transaksi(id_operator);
            this.Hide();
            transaksi.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HistoryTransaksi historyTransaksi = new HistoryTransaksi();
            this.Hide();
            historyTransaksi.ShowDialog();
            this.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
