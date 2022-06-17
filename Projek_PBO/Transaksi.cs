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

namespace Projek_PBO
{
    public partial class Transaksi : Form
    {
        private List<Item> items = new List<Item>();
        private static Random random = new Random();
        public Transaksi()
        {
            InitializeComponent();
            refresh_listView();
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;

            textBoxDiskon.KeyPress += inputNumeric;
            textBoxBayar.KeyPress += inputNumeric;

            textBoxDiskon.TextChanged += TextBoxDiskon_TextChanged;

            for (int i = 0; i < 2; i++)
            {
                Item item = new Item(i, RandomString(10), random.Next(1, 10) * 1000);
                items.Add(item);
            }
            refresh_listView();
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
            string ID = listView1.SelectedItems[0].SubItems[1].Text;
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
            //subitem = id, harga, stock
            ListViewItem listViewItem = new ListViewItem(item.Nama);
            listViewItem.SubItems.Add(item.Id.ToString());
            listViewItem.SubItems.Add(item.Harga.ToString());
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
    }


}
