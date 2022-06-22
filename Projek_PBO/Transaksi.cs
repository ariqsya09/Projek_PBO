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

namespace Projek_PBO { 

    public partial class Transaksi : Form
    {
        DatabaseManager databaseManager = new DatabaseManager("Host=localhost;Database=project_pbo;Username=postgres;Password=respect1945");
        private List<Item> items = new List<Item>();
        private static Random random = new Random();
        private int operator_id = 1;
        public Transaksi()
        {
            InitializeComponent();


            
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CellClick += DataGridView1_CellClick;

            textBoxDiskon.KeyPress += inputNumeric;
            textBoxBayar.KeyPress += inputNumeric;

            textBoxDiskon.TextChanged += TextBoxDiskon_TextChanged;
            textBoxBayar.TextChanged += TextBoxBayar_TextChanged;

            buttonCheckout.Click += ButtonCheckout_Click;

            // test
            refresh_db();
            refresh_listView();
        }

        private void ButtonCheckout_Click(object sender, EventArgs e)
        {
            checkout();
        }

        private void TextBoxBayar_TextChanged(object sender, EventArgs e)
        {
            int total = int.Parse(textBoxTotal.Text == "" ? "0" : textBoxTotal.Text);
            int bayar = int.Parse(textBoxBayar.Text == "" ? "0" :textBoxBayar.Text);
            textBoxKembalian.Text = (bayar - total).ToString();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            // column harga
            if (dataGrid.CurrentCell.ColumnIndex == 4 && dataGrid.CurrentRow.Index != dataGrid.Rows.Count - 1)
            {
                dataGrid.Rows.Remove(dataGrid.CurrentRow);
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void TextBoxDiskon_TextChanged(object sender, EventArgs e)
        {
            calculateHarga();
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //cek kalo stoknya gak lebih dari
            if(e.ColumnIndex == 2)
            {
                int jumlah = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                foreach (ListViewItem item in listView1.Items)
                {
                    string listviewitem_id = item.SubItems[3].Text;
                    if (listviewitem_id == id)
                    {
                        int listviewitem_stok = int.Parse(item.SubItems[1].Text);
                        if(jumlah > listviewitem_stok)
                        {
                            //kelebihan jumlah, stoknya kurang
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = listviewitem_stok;
                            break;
                        }
                    }
                }
            }
            
            //calculate harga
            calculateHarga();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Transaksi_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ss
        }

        // search
        private void search(TextBox textBox, ListView listView)
        {

            refresh_listView();
            String val = textBox.Text;
            foreach (ListViewItem item in listView.Items)
                if (!item.Text.ToLower().Contains(val.ToLower()))
                    item.Remove();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search(sender as TextBox, listView1);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string ID = listView1.SelectedItems[0].SubItems[3].Text;
            string nama = listView1.SelectedItems[0].SubItems[0].Text;
            string harga = listView1.SelectedItems[0].SubItems[2].Text;
            // check kl udah ada / blm
            if (dataGridView1.Rows.Count != 1)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null)
                        continue;
                    if (row.Cells[0].Value.ToString() == ID)
                    {
                        return;
                    }
                }
            }

            //id, nama, stock, harga
            addToKeranjang(ID, nama, harga);
        }
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            // column harga
            if (dataGrid.CurrentCell.ColumnIndex == 2)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += inputNumeric;
                    //prevent null value, set to 1
                    textBox.LostFocus += (sender2, e2) =>
                    {
                        if (textBox.Text.Length == 0)
                        {
                            textBox.Text = "1";
                        }
                    };
                }
            }
        }
        /**************** INPUT THINGS ****************/
        private void refresh_db()
        {
            items.Clear();
            DataSet ds = new DataSet();
            databaseManager.ExecuteQuery(ref ds, "SELECT * FROM BARANG WHERE stok_barang > 0 ORDER BY id_barang ASC");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Item item = new Item(row);
                items.Add(item);
            }
        }
        private void refresh_listView()
        {

            listView1.Items.Clear();
            foreach (Item item in items)
            {
                addToListView(item);
            }
        }
        private void addToListView(Item item)
        {
            //subitem = stok, harga, id
            ListViewItem listViewItem = new ListViewItem(item.Nama);
            listViewItem.SubItems.Add(item.Stock.ToString());
            listViewItem.SubItems.Add(item.Harga.ToString());
            listViewItem.SubItems.Add(item.Id.ToString());
            listView1.Items.Add(listViewItem);
        }
        private void addToKeranjang(string ID, string nama, string harga)
        {
            dataGridView1.Rows.Add(ID, nama, 1, harga, SystemIcons.Hand);
            calculateHarga();
        }
        private void addToKeranjang(Item item)
        {
            dataGridView1.Rows.Add(item.Id, item.Nama, 1, item.Harga, SystemIcons.Hand);
        }
        private void inputNumericOne(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar)) && ((sender as TextBox).Text.Length <= 1 || (byte)e.KeyChar != 8);
        }
        private void inputNumeric(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar)) && (byte)e.KeyChar != 8;
        }
        private void calculateHarga()
        {
            DataGridView dataGridView = dataGridView1;
            int harga = 0;
            if (dataGridView.Rows.Count != 1)
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    //column harga
                    if (row.Cells[3].Value != null)
                    {
                        harga += int.Parse(row.Cells[3].Value.ToString()) * int.Parse(row.Cells[2].Value.ToString());
                    }
                }

            //get diskon
            int diskon = textBoxDiskon.TextLength > 0 ? int.Parse(textBoxDiskon.Text.ToString()) : 0;
            textBoxTotal.Text = (harga - diskon < 0 ? 0 : harga - diskon).ToString();
        }
        private void checkout()
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("Keranjang masih kosong.");
                return;
            }
            if (textBoxBayar.Text.Length == 0)
            {
                MessageBox.Show("Mohon isi nominal bayar.");
                return;
            }
            if(textBoxKembalian.Text.Length != 0 && int.Parse(textBoxKembalian.Text) < 0)
            {
                MessageBox.Show("Uang bayar kurang.");
                return;
            }

            // insert ke transaksi
            int totalHarga = int.Parse(textBoxTotal.Text);
            NpgsqlParameter[] transaksiParameter = new NpgsqlParameter[1];
            transaksiParameter[0] = new NpgsqlParameter("@total_harga", totalHarga);
            //databaseManager.ExecuteNonQuery("INSERT INTO transaksi(tanggal_transaksi, total_harga) VALUES(NOW(), @total_harga)", transaksiParameter);
            DataSet dataSetTR = new DataSet();
            databaseManager.ExecuteQuery(ref dataSetTR, "INSERT INTO transaksi(tanggal_transaksi, total_harga) VALUES(NOW(), @total_harga) RETURNING *", transaksiParameter);
            // get id from returning
            int transaksi_id = int.Parse(dataSetTR.Tables[0].Rows[0]["id_transaksi"].ToString());

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // null check
                if(row.Cells[0].Value != null && row.Cells[0].Value.ToString().Length >= 1)
                {
                    int id = int.Parse(row.Cells[0].Value.ToString());
                    int jumlah = int.Parse(row.Cells[2].Value.ToString());
                    int harga = 0;
                    int stok = 0;
                    foreach(Item item in items)
                    {
                        if(item.Id == id)
                        {
                            stok = item.Stock;
                            harga = item.Harga;
                            break;
                        }
                    }
                    // update stok
                    int newStok = stok - jumlah;
                    NpgsqlParameter[] parameters = new NpgsqlParameter[2];
                    parameters[0] = new NpgsqlParameter("@stok", newStok);
                    parameters[1] = new NpgsqlParameter("@id", id);
                    databaseManager.ExecuteNonQuery("UPDATE barang SET stok_barang = @stok WHERE id_barang = @id", parameters);

                    // insert ke detail_transaksi
                    NpgsqlParameter[] dtParameters = new NpgsqlParameter[5];
                    dtParameters[0] = new NpgsqlParameter("@jumlah_barang", jumlah);
                    dtParameters[1] = new NpgsqlParameter("@harga", jumlah * harga);
                    dtParameters[2] = new NpgsqlParameter("@barang_id_barang", id);
                    dtParameters[3] = new NpgsqlParameter("@transaksi_id_transaksi", transaksi_id);
                    dtParameters[4] = new NpgsqlParameter("@operator_id_operator", operator_id);
                    databaseManager.ExecuteNonQuery("INSERT INTO detail_transaksi(jumlah_barang, harga, barang_id_barang, transaksi_id_transaksi, operator_id_operator) VALUES(@jumlah_barang, @harga, @barang_id_barang, @transaksi_id_transaksi, @operator_id_operator)", dtParameters);
                }
            }

            //get date
            String dt = dataSetTR.Tables[0].Rows[0]["tanggal_transaksi"].ToString();
            //nota
            Nota nota = new Nota(dataGridView1.Rows, dt, totalHarga.ToString());
            var p = dataGridView1.Rows;
            nota.ShowDialog();

            refresh_db();
            refresh_listView();

            //clear all, post checkout
            dataGridView1.Rows.Clear();
            textBoxDiskon.Text = "";
            textBoxTotal.Text = "";
            textBoxBayar.Text = "";
            textBoxKembalian.Text = "";
        }
    }


}
