namespace Projek_PBO
{
    internal class Item
    {
        public int Id { get; }
        public string Nama { get; }
        public int Stock { get; }
        public int Harga { get; }

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

    }
}
