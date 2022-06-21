using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Barang()
        {
            InitializeComponent();
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=minimarket;User Id=postgres; Password=takuya123;"))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Select * from barang";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Dispose();
                connection.Close();

                
                dataGridView1.DataSource = dt;
            }
        }

        int id,i, j;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Apakah yakin ingin menghapus Barang ID: {0}?", row.Cells["id_barang"].Value), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=minimarket;User Id=postgres; Password=takuya123;"))
                    {
                            connection.Open();
                            NpgsqlCommand cmd = new NpgsqlCommand();
                            cmd.Connection = connection;
                            cmd.CommandText = "DELETE FROM barang WHERE id_barang = @id_barang";
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@id_barang", row.Cells["id_barang"].Value);
                            cmd.ExecuteNonQuery();
                            connection.Close();
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
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=minimarket;User Id=postgres; Password=takuya123;"))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Select * from barang";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Dispose();
                connection.Close();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=minimarket;User Id=postgres; Password=takuya123;"))
            {
                //connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into barang(id_barang,nama_barang,harga_barang,stok_barang) values (@id,@nama,@harga,@stok)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@id",6));
                cmd.Parameters.Add(new NpgsqlParameter("@nama", tbNama.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@harga", Convert.ToInt32(tbHarga.Text)));
                cmd.Parameters.Add(new NpgsqlParameter("@stok", Convert.ToInt32(tbStok.Text)));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();

                dataGridView1.AutoGenerateColumns = false;
                load_data();
                
                

            }
        }

        private void Barang_Load(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=minimarket;User Id=postgres; Password=takuya123;"))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update barang set id_barang=@ID,nama_barang=@nama,stok_barang=@stok, harga_barang=@harga where id_barang=@ID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@ID", Convert.ToInt32(tbUpId.Text)));
                cmd.Parameters.Add(new NpgsqlParameter("@nama", tbUpName.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@stok", Convert.ToInt32(tbUpStok.Text)));
                cmd.Parameters.Add(new NpgsqlParameter("@harga", Convert.ToInt32(tbUpHarga.Text)));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                tbUpId.Text = "";
                tbUpName.Text = "";
                tbUpStok.Text = "";
                tbUpHarga.Text = "";
                lblmsg.Text = "Data berhasil di update";
                load_data();

            }
        }

        private void tbUpdate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
