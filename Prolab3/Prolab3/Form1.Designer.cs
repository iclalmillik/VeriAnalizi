namespace Prolab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            dataGridView2 = new DataGridView();
            İlgi_Alanları = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            button1 = new Button();
            dataGridView3 = new DataGridView();
            column2 = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button3 = new Button();
            textBox2 = new TextBox();
            dataGridView4 = new DataGridView();
            column3 = new DataGridViewTextBoxColumn();
            textBox3 = new TextBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridView1.Location = new Point(12, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_2;
            // 
            // Column1
            // 
            Column1.HeaderText = "Kullanıcılar";
            Column1.Name = "Column1";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ButtonShadow;
            label1.Location = new Point(347, 9);
            label1.Name = "label1";
            label1.Size = new Size(103, 36);
            label1.TabIndex = 1;
            label1.Text = "İlgi Alanları";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { İlgi_Alanları });
            dataGridView2.Location = new Point(281, 48);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(243, 150);
            dataGridView2.TabIndex = 2;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick_1;
            // 
            // İlgi_Alanları
            // 
            İlgi_Alanları.HeaderText = "İlgi Alanları";
            İlgi_Alanları.Name = "İlgi_Alanları";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(611, 236);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(147, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(571, 265);
            button1.Name = "button1";
            button1.Size = new Size(240, 23);
            button1.TabIndex = 4;
            button1.Text = "Seçilen ilgi alanına göre kullanıcıları sırala";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { column2 });
            dataGridView3.Location = new Point(571, 48);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(240, 150);
            dataGridView3.TabIndex = 6;
            // 
            // column2
            // 
            column2.HeaderText = "İlgi Alanına Sahip Kullanıcılar";
            column2.Name = "column2";
            // 
            // button2
            // 
            button2.Location = new Point(12, 350);
            button2.Name = "button2";
            button2.Size = new Size(240, 23);
            button2.TabIndex = 7;
            button2.Text = "Ortak ilgi alanına sahip kullanıcıları eşleştir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 265);
            button3.Name = "button3";
            button3.Size = new Size(240, 23);
            button3.TabIndex = 8;
            button3.Text = "Girilen Kullanıcıyı Graph Olarak Modelle";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(75, 236);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Columns.AddRange(new DataGridViewColumn[] { column3 });
            dataGridView4.Location = new Point(284, 247);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.RowTemplate.Height = 25;
            dataGridView4.Size = new Size(240, 150);
            dataGridView4.TabIndex = 10;
            // 
            // column3
            // 
            column3.HeaderText = "Ülkede Trend Olan Konular";
            column3.Name = "column3";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(350, 431);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 11;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // button4
            // 
            button4.Location = new Point(284, 460);
            button4.Name = "button4";
            button4.Size = new Size(240, 23);
            button4.TabIndex = 13;
            button4.Text = "Girilen Ülkede Trend Olan Konular";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(dataGridView4);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView3);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        public Label label1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn İlgi_Alanları;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn column2;
        private Button button2;
        private Button button3;
        private TextBox textBox2;
        private DataGridView dataGridView4;
        private TextBox textBox3;
        private Button button4;
        private DataGridViewTextBoxColumn column3;
    }
}