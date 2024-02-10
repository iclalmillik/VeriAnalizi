namespace Prolab3
{
    partial class Eşleşme_Tablosu
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
            dataGridView1 = new DataGridView();
            Kullanıcılar = new DataGridViewTextBoxColumn();
            takipçisayısı = new DataGridViewTextBoxColumn();
            takipedilensayisi = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            kullanıcılar2 = new DataGridViewTextBoxColumn();
            takipçisayısı2 = new DataGridViewTextBoxColumn();
            takipedilensayısı2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Kullanıcılar, takipçisayısı, takipedilensayisi });
            dataGridView1.Location = new Point(31, 34);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(664, 150);
            dataGridView1.TabIndex = 0;
            // 
            // Kullanıcılar
            // 
            Kullanıcılar.HeaderText = "Kullanıcılar";
            Kullanıcılar.Name = "Kullanıcılar";
            // 
            // takipçisayısı
            // 
            takipçisayısı.HeaderText = "Takipçi Sayısı";
            takipçisayısı.Name = "takipçisayısı";
            // 
            // takipedilensayisi
            // 
            takipedilensayisi.HeaderText = "Takip Sayısı";
            takipedilensayisi.Name = "takipedilensayisi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 8);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 1;
            label1.Text = "Eşleşme Öncesi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 203);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 2;
            label2.Text = "Eşleşme Sonrası";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { kullanıcılar2, takipçisayısı2, takipedilensayısı2 });
            dataGridView2.Location = new Point(31, 230);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(664, 150);
            dataGridView2.TabIndex = 3;
            // 
            // kullanıcılar2
            // 
            kullanıcılar2.HeaderText = "Kullanıcılar";
            kullanıcılar2.Name = "kullanıcılar2";
            // 
            // takipçisayısı2
            // 
            takipçisayısı2.HeaderText = "Takipçi Sayısı";
            takipçisayısı2.Name = "takipçisayısı2";
            // 
            // takipedilensayısı2
            // 
            takipedilensayısı2.HeaderText = "Takip Sayısı";
            takipedilensayısı2.Name = "takipedilensayısı2";
            // 
            // Eşleşme_Tablosu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Eşleşme_Tablosu";
            Text = "Eşleşme_Tablosu";
            Load += Eşleşme_Tablosu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Kullanıcılar;
        private DataGridViewTextBoxColumn takipçisayısı;
        private DataGridViewTextBoxColumn takipedilensayisi;
        private DataGridViewTextBoxColumn kullanıcılar2;
        private DataGridViewTextBoxColumn takipçisayısı2;
        private DataGridViewTextBoxColumn takipedilensayısı2;
    }
}