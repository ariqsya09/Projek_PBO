using Npgsql;
using System.Configuration;

namespace Projek_PBO
{
    internal class Item
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Stock { get; set; }
        public int Harga { get; set; }

        public Item(int id, string nama, int harga, int stock = 1)
        {
            Id = id;
            Nama = nama;
            Stock = stock;
            Harga = harga;
        }
        public Item(System.Data.DataRow row)
        {
            Id = int.Parse(row[0].ToString());
            Nama = (string)row[1];
            Stock = (int)row[3];
            Harga = (int)row[2];
        }
        public void updateNama(string nama)
        {
            Nama = nama;
            DatabaseManager databaseManager = new DatabaseManager(ConfigurationManager.AppSettings["dbString"]);
            NpgsqlParameter[] parameters = new NpgsqlParameter[2];
            parameters[0] = new NpgsqlParameter("@nama_barang", Nama);
            parameters[1] = new NpgsqlParameter("@id_barang", Id);
            databaseManager.ExecuteNonQuery("UPDATE barang SET nama_barang = @nama_barang WHERE id_barang = @id_barang", parameters);
        }
        public void updateHarga(int harga)
        {
            Harga = harga;
            DatabaseManager databaseManager = new DatabaseManager(ConfigurationManager.AppSettings["dbString"]);
            NpgsqlParameter[] parameters = new NpgsqlParameter[2];
            parameters[0] = new NpgsqlParameter("@harga_barang", Harga);
            parameters[1] = new NpgsqlParameter("@id_barang", Id);
            databaseManager.ExecuteNonQuery("UPDATE barang SET harga_barang = @harga_barang WHERE id_barang = @id_barang", parameters);
        }
        public void updateStock(int stock)
        {
            Stock = stock;
            DatabaseManager databaseManager = new DatabaseManager(ConfigurationManager.AppSettings["dbString"]);
            NpgsqlParameter[] parameters = new NpgsqlParameter[2];
            parameters[0] = new NpgsqlParameter("@stok_barang", Stock);
            parameters[1] = new NpgsqlParameter("@id_barang", Id);
            databaseManager.ExecuteNonQuery("UPDATE barang SET stok_barang = @stok_barang WHERE id_barang = @id_barang", parameters);
        }
        public static Item insertItem(string nama, int harga, int stock = 1)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            DatabaseManager databaseManager = new DatabaseManager(ConfigurationManager.AppSettings["dbString"]);
            NpgsqlParameter[] parameters = new NpgsqlParameter[3];
            parameters[0] = new NpgsqlParameter("@nama_barang", nama);
            parameters[1] = new NpgsqlParameter("@harga_barang", harga);
            parameters[2] = new NpgsqlParameter("@stok_barang", stock);
            databaseManager.ExecuteQuery(ref ds, "INSERT INTO barang(nama_barang, harga_barang, stok_barang) VALUES(@nama_barang, @harga_barang, @stok_barang) RETURNING *", parameters);

            int id = int.Parse(ds.Tables[0].Rows[0]["id_barang"].ToString());
            Item item = new Item(id, nama, harga, stock);
            return item;
        }
    }
}
