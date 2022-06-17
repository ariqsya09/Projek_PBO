using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
