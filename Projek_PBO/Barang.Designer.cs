namespace Projek_PBO
{
    partial class Barang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nama = new System.Windows.Forms.Label();
            this.hargaBrg = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.stokBrg = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.namaBarang,
            this.stok,
            this.harga,
            this.hapus});
            this.dataGridView1.Location = new System.Drawing.Point(728, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(676, 323);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(198, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tambah";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(98, 175);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(358, 38);
            this.textBox1.TabIndex = 2;
            // 
            // nama
            // 
            this.nama.AutoSize = true;
            this.nama.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nama.Location = new System.Drawing.Point(92, 128);
            this.nama.Name = "nama";
            this.nama.Size = new System.Drawing.Size(188, 32);
            this.nama.TabIndex = 5;
            this.nama.Text = "Nama Barang";
            // 
            // hargaBrg
            // 
            this.hargaBrg.AutoSize = true;
            this.hargaBrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hargaBrg.Location = new System.Drawing.Point(92, 338);
            this.hargaBrg.Name = "hargaBrg";
            this.hargaBrg.Size = new System.Drawing.Size(91, 32);
            this.hargaBrg.TabIndex = 7;
            this.hargaBrg.Text = "Harga";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(98, 382);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(358, 38);
            this.textBox2.TabIndex = 6;
            // 
            // stokBrg
            // 
            this.stokBrg.AutoSize = true;
            this.stokBrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stokBrg.Location = new System.Drawing.Point(92, 240);
            this.stokBrg.Name = "stokBrg";
            this.stokBrg.Size = new System.Drawing.Size(71, 32);
            this.stokBrg.TabIndex = 9;
            this.stokBrg.Text = "Stok";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(98, 275);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(358, 38);
            this.textBox3.TabIndex = 8;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 125;
            // 
            // namaBarang
            // 
            this.namaBarang.HeaderText = "Nama";
            this.namaBarang.MinimumWidth = 6;
            this.namaBarang.Name = "namaBarang";
            this.namaBarang.Width = 125;
            // 
            // stok
            // 
            this.stok.HeaderText = "Stok";
            this.stok.MinimumWidth = 6;
            this.stok.Name = "stok";
            this.stok.Width = 125;
            // 
            // harga
            // 
            this.harga.HeaderText = "Harga";
            this.harga.MinimumWidth = 6;
            this.harga.Name = "harga";
            this.harga.Width = 125;
            // 
            // hapus
            // 
            this.hapus.HeaderText = "aksi";
            this.hapus.MinimumWidth = 6;
            this.hapus.Name = "hapus";
            this.hapus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hapus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hapus.Width = 125;
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(16, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(104, 41);
            this.back.TabIndex = 10;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            // 
            // Barang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 564);
            this.Controls.Add(this.back);
            this.Controls.Add(this.stokBrg);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.hargaBrg);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.nama);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Barang";
            this.Text = "Barang";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn stok;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga;
        private System.Windows.Forms.DataGridViewButtonColumn hapus;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label nama;
        private System.Windows.Forms.Label hargaBrg;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label stokBrg;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button back;
    }
}