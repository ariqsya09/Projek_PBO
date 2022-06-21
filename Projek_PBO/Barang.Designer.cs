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
            this.aksi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tbNama = new System.Windows.Forms.TextBox();
            this.nama = new System.Windows.Forms.Label();
            this.hargaBrg = new System.Windows.Forms.Label();
            this.tbHarga = new System.Windows.Forms.TextBox();
            this.stokBrg = new System.Windows.Forms.Label();
            this.tbStok = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Button();
            this.tbUpId = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUpName = new System.Windows.Forms.TextBox();
            this.tbUpStok = new System.Windows.Forms.TextBox();
            this.tbUpHarga = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblmsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aksi});
            this.dataGridView1.Location = new System.Drawing.Point(700, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(676, 323);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // aksi
            // 
            this.aksi.HeaderText = "Hapus";
            this.aksi.MinimumWidth = 6;
            this.aksi.Name = "aksi";
            this.aksi.ReadOnly = true;
            this.aksi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aksi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aksi.Text = "Hapus";
            this.aksi.Width = 125;
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbNama
            // 
            this.tbNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNama.Location = new System.Drawing.Point(98, 175);
            this.tbNama.Name = "tbNama";
            this.tbNama.Size = new System.Drawing.Size(358, 38);
            this.tbNama.TabIndex = 2;
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
            // tbHarga
            // 
            this.tbHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHarga.Location = new System.Drawing.Point(98, 382);
            this.tbHarga.Name = "tbHarga";
            this.tbHarga.Size = new System.Drawing.Size(358, 38);
            this.tbHarga.TabIndex = 6;
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
            // tbStok
            // 
            this.tbStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStok.Location = new System.Drawing.Point(98, 275);
            this.tbStok.Name = "tbStok";
            this.tbStok.Size = new System.Drawing.Size(358, 38);
            this.tbStok.TabIndex = 8;
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
            // tbUpId
            // 
            this.tbUpId.Location = new System.Drawing.Point(700, 82);
            this.tbUpId.Name = "tbUpId";
            this.tbUpId.Size = new System.Drawing.Size(150, 22);
            this.tbUpId.TabIndex = 11;
            this.tbUpId.TextChanged += new System.EventHandler(this.tbUpdate_TextChanged);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(1231, 97);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 29);
            this.Update.TabIndex = 12;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(697, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Update Data";
            // 
            // tbUpName
            // 
            this.tbUpName.Location = new System.Drawing.Point(700, 138);
            this.tbUpName.Name = "tbUpName";
            this.tbUpName.Size = new System.Drawing.Size(150, 22);
            this.tbUpName.TabIndex = 14;
            // 
            // tbUpStok
            // 
            this.tbUpStok.Location = new System.Drawing.Point(970, 82);
            this.tbUpStok.Name = "tbUpStok";
            this.tbUpStok.Size = new System.Drawing.Size(150, 22);
            this.tbUpStok.TabIndex = 15;
            // 
            // tbUpHarga
            // 
            this.tbUpHarga.Location = new System.Drawing.Point(970, 138);
            this.tbUpHarga.Name = "tbUpHarga";
            this.tbUpHarga.Size = new System.Drawing.Size(150, 22);
            this.tbUpHarga.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(697, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(697, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nama Barang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(967, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Stok";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(967, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Harga";
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(1231, 143);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 16);
            this.lblmsg.TabIndex = 21;
            // 
            // Barang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 564);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUpHarga);
            this.Controls.Add(this.tbUpStok);
            this.Controls.Add(this.tbUpName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.tbUpId);
            this.Controls.Add(this.back);
            this.Controls.Add(this.stokBrg);
            this.Controls.Add(this.tbStok);
            this.Controls.Add(this.hargaBrg);
            this.Controls.Add(this.tbHarga);
            this.Controls.Add(this.nama);
            this.Controls.Add(this.tbNama);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Barang";
            this.Text = "Barang";
            this.Load += new System.EventHandler(this.Barang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.Label nama;
        private System.Windows.Forms.Label hargaBrg;
        private System.Windows.Forms.TextBox tbHarga;
        private System.Windows.Forms.Label stokBrg;
        private System.Windows.Forms.TextBox tbStok;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.DataGridViewButtonColumn aksi;
        private System.Windows.Forms.TextBox tbUpId;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUpName;
        private System.Windows.Forms.TextBox tbUpStok;
        private System.Windows.Forms.TextBox tbUpHarga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblmsg;
    }
}