using Npgsql;
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
            DatabaseManager db = new DatabaseManager("Server=localhost; Port=5432; Database=minimarket;User Id=postgres; Password=takuya123;");
            DataSet ds = new DataSet();
            NpgsqlParameter[] p = new NpgsqlParameter[2];
            p[0] = new NpgsqlParameter("@username", tbUsername.Text);
            p[1] = new NpgsqlParameter("@password", tbPass.Text);
            db.ExecuteQuery(ref ds, "select id_operator from operator where username = @username and password = @password",p);
            Debug.Print(ds.Tables[0].Rows.Count.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
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

