using Npgsql;
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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=minimarket;User Id=postgres; Password=takuya123;"))
            {
                //connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select id_operator from operator where username='" + tbUsername.Text + "' and password='" + tbPass.Text + "'";
                cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();

                if (cmd != null)
                {
                    cmd.Dispose();
                    connection.Close();
                    Beranda sd = new Beranda();
                    sd.Show();
                }
                else
                {
                    lblMsg.Text = "Username atau password salah, Silahkan coba kembali!";
                }
            }
        }
    }
}

