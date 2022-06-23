using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Projek_PBO
{
    public partial class Nota : Form
    {
        DatabaseManager databaseManager = new DatabaseManager(ConfigurationManager.AppSettings["dbString"]);
        public Nota(DataGridViewRowCollection rows = null, String date = "", String totalHarga = "")
        {
            InitializeComponent();
            if (rows != null)
                setData(rows);
            labelTime.Text = date;
            labelTotal.Text = "Total: " + totalHarga;
        }
        public Nota(int transaksi_id = -1)
        {
            InitializeComponent();
            if(transaksi_id != -1)
                setData(transaksi_id);
        }
        void setData(DataGridViewRowCollection rows)
        {
            foreach (DataGridViewRow row in rows)
            {
                if(row.Cells[0].Value != null)
                dataGridView1.Rows.Add(row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value);
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            sizeDGV(dataGridView1);
        }
        void setData(int transaksi_id)
        {
            DataSet ds = new DataSet();
            NpgsqlParameter[] parameters = new NpgsqlParameter[1];
            parameters[0] = new NpgsqlParameter("@id_transaksi", transaksi_id);
            databaseManager.ExecuteQuery(ref ds, "SELECT * FROM TRANSAKSI WHERE id_transaksi = @id_transaksi", parameters);

            //set time
            labelTime.Text = ds.Tables[0].Rows[0]["tanggal_transaksi"].ToString();

            //set total
            labelTotal.Text = "Total: " + ds.Tables[0].Rows[0]["total_harga"].ToString();

            //get all from detail_transaksi
            DataSet detail = new DataSet();
            databaseManager.ExecuteQuery(ref detail, "select * from detail_transaksi dt JOIN barang b ON dt.barang_id_barang = b.id_barang WHERE transaksi_id_transaksi = @id_transaksi", parameters);
            foreach(DataRow row in detail.Tables[0].Rows)
            {
                dataGridView1.Rows.Add(row["nama_barang"], row["jumlah_barang"], row["harga"]);
            }

            //resize
            sizeDGV(dataGridView1);
        }
        void sizeDGV(DataGridView dgv)
        {
            DataGridViewElementStates states = DataGridViewElementStates.None;
            dgv.ScrollBars = ScrollBars.None;
            var totalHeight = dgv.Rows.GetRowsHeight(states) + dgv.ColumnHeadersHeight;
            totalHeight += dgv.Rows.Count * 4;
            var totalWidth = dgv.Columns.GetColumnsWidth(states) + dgv.RowHeadersWidth;
            dgv.ClientSize = new Size(totalWidth, totalHeight);
            // resize form
            this.Size = new Size(totalWidth + 40, totalHeight + 140);
            //move label to bawah
            labelTotal.Location = new Point(labelTotal.Location.X, totalHeight + 55);
        }
    }
}
