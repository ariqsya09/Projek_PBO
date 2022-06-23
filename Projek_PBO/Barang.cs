using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projek_PBO
{
    public partial class Barang : Form
    {
        List<Item> items = new List<Item>();
        public Barang()
        {
            InitializeComponent();
            load_data();
        }

        int id,i, j;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Apakah yakin ingin menghapus Barang ID: {0}?", row.Cells["id_barang"].Value), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(row.Cells["id_barang"].Value);
                    foreach(Item item in items)
                    {
                        if (item.Id== id)
                        {
                            item.updateStock(0);
                            break;
                        }
                    }
                    }

                load_data();
                }

            else
            {
                //i = dataGridView1.CurrentCell.e.RowIndex;
                //j = dataGridView1.CurrentCell.e.ColumnIndex;
                //tbUpId.Text = dataGridView1.Rows[i].Cells[j].Value.ToString();
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                tbUpId.Text = row.Cells["id_barang"].Value.ToString();
                tbUpName.Text = row.Cells["nama_barang"].Value.ToString();
                tbUpStok.Text = row.Cells["stok_barang"].Value.ToString();
                tbUpHarga.Text = row.Cells["harga_barang"].Value.ToString();
            }


        }
      
        public void load_data()
        {
            items.Clear();
            DatabaseManager db = new DatabaseManager(ConfigurationManager.AppSettings["dbString"]);
            DataSet ds = new DataSet();
            db.ExecuteQuery(ref ds, "SELECT * FROM barang WHERE id_barang > -1");
            dataGridView1.DataSource = ds.Tables[0];
            foreach (DataRow Row in ds.Tables[0].Rows)
            {
                Item item = new Item(Convert.ToInt32(Row["id_barang"].ToString()), Row["nama_barang"].ToString(), Convert.ToInt32(Row["harga_barang"].ToString()), Convert.ToInt32(Row["stok_barang"].ToString()));
                items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
                Item item = Item.insertItem(tbNama.Text, Convert.ToInt32(tbHarga.Text), Convert.ToInt32(tbStok.Text));
                items.Add(item);


                dataGridView1.AutoGenerateColumns = false;
                load_data();
                
                
        }

        private void Barang_Load(object sender, EventArgs e)
        {

        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
                var id = Convert.ToInt32(tbUpId.Text);
                foreach (Item item in items)
                {
                    if (item.Id == id)
                    {
                        item.updateNama(tbUpName.Text);
                        item.updateStock(Convert.ToInt32(tbUpStok.Text));
                        item.updateHarga(Convert.ToInt32(tbUpHarga.Text));
                        break;
                    }
                }
            load_data();

 
        }

        private void tbUpdate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
