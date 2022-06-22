using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Projek_PBO
{
    public partial class HistoryTransaksi : Form
    {
        DatabaseManager databaseManager = new DatabaseManager("Host=localhost;Database=project_pbo;Username=postgres;Password=respect1945");
        DataSet ds = new DataSet();
        int totalPendapatan = 0;
        public HistoryTransaksi()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;
            initData();
            Debug.Print(dateTimePicker1.Value.ToString());
            Debug.Print(dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month + '-' + dateTimePicker1.Value.Day);
        }
        void initData()
        {
            //reset
            totalPendapatan = 0;
            ds.Clear();
            listView1.Items.Clear();

            //query
            String query = "SELECT distinct(t.id_transaksi), o.nama_lengkap, t.tanggal_transaksi, t.total_harga FROM transaksi t JOIN detail_transaksi dt ON t.id_transaksi = dt.transaksi_id_transaksi JOIN operator o ON dt.operator_id_operator = o.id_operator ORDER BY id_transaksi";
            NpgsqlParameter[] parameters = new NpgsqlParameter[1];
            switch (comboBox1.SelectedIndex)
            {
                // semua
                case 0:
                    break;
                // bulanan
                case 1:
                    query = "SELECT distinct(t.id_transaksi), o.nama_lengkap, t.tanggal_transaksi, t.total_harga FROM transaksi t JOIN detail_transaksi dt ON t.id_transaksi = dt.transaksi_id_transaksi JOIN operator o ON dt.operator_id_operator = o.id_operator WHERE EXTRACT(MONTH FROM t.tanggal_transaksi) = @bulan ORDER BY id_transaksi";
                    parameters[0] = new NpgsqlParameter("@bulan", dateTimePicker1.Value.Month);
                    break;
                // harian
                case 2:
                    query = "SELECT distinct(t.id_transaksi), o.nama_lengkap, t.tanggal_transaksi, t.total_harga FROM transaksi t JOIN detail_transaksi dt ON t.id_transaksi = dt.transaksi_id_transaksi JOIN operator o ON dt.operator_id_operator = o.id_operator WHERE DATE(t.tanggal_transaksi) = DATE(@tanggal_transaksi) ORDER BY id_transaksi";
                    parameters[0] = new NpgsqlParameter("@tanggal_transaksi", dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString());
                    break;
                default:
                    break;
            }
            if (comboBox1.SelectedIndex == 0)
                databaseManager.ExecuteQuery(ref ds, query);
            else
                databaseManager.ExecuteQuery(ref ds, query, parameters);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                String op = row[1].ToString();
                String dt = row[2].ToString();
                String pendapatan = row[3].ToString();
                String id = row[0].ToString();
                ListViewItem item = new ListViewItem(op);
                item.SubItems.Add(dt);
                item.SubItems.Add(pendapatan);
                item.SubItems.Add(id);
                listView1.Items.Add(item);

                totalPendapatan += int.Parse(pendapatan);
            }

            label1.Text = "Total: " + totalPendapatan;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string ID = listView1.SelectedItems[0].SubItems[3].Text;
            Nota nota = new Nota(int.Parse(ID));
            nota.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dateTimePicker1.Enabled=false;
                    break;
                case 1:
                    dateTimePicker1.Enabled=true;
                    break;
                case 2:
                    dateTimePicker1.Enabled = true;
                    break;
                default:
                    dateTimePicker1.Enabled=true;
                    break;
            }
            initData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            initData();
        }
    }
}
