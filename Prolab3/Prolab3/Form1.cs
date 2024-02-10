using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
using System.Text.Json.Nodes;
using System.IO;
using System.Text.Json;
using System;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace Prolab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graph graph = new Graph();

        MyHashtable<string, MyList<Kullan�c�>> ilgialanlar� = new MyHashtable<string, MyList<Kullan�c�>>();

        MyHashtable<string, MyHashtable<string, MyList<Kullan�c�>>> b�lgetrendolankonullar = new MyHashtable<string, MyHashtable<string, MyList<Kullan�c�>>>();
        MyList<Kullan�c�> kullan�c�lar = new MyList<Kullan�c�>();
        
        public void Form1_Load(object sender, EventArgs e)
        {
            string dosyayolu = AppDomain.CurrentDomain.BaseDirectory + "kullan�c�_verileri.json";

            string jsoni�erik = File.ReadAllText(dosyayolu);

            kullan�c�lar = JsonSerializer.Deserialize<MyList<Kullan�c�>>(jsoni�erik);


            MyHashtable<string, Kullan�c�> Kullan�c�tablosu = new MyHashtable<string, Kullan�c�>();

            foreach (Kullan�c� user in kullan�c�lar)
            {
                Kullan�c�tablosu.Add(user.Username, user);
                dataGridView1.Rows.Add(user.Username);

            }

            int minfrekans = 2;
            MyHashtable<string, MyHashtable<string, int>> userilgialanlar� = new MyHashtable<string, MyHashtable<string, int>>();

            MyHashtable<string, MyHashtable<string, int>> userkelimefrekans = new MyHashtable<string, MyHashtable<string, int>>();

            MyHashtable<string, MyList<Kullan�c�>> ili�kilistesi = new MyHashtable<string, MyList<Kullan�c�>>();



            foreach (Kullan�c� user in kullan�c�lar) 
            {
                graph.AddKullan�c�(user.Username);
                foreach (string takipedilen in user.TakipEdilenKullan�c�Adlar�)
                {
                    graph.AddTakipili�kisi(user.Username, takipedilen);
                }
            }

            foreach (Kullan�c� user in kullan�c�lar)
            {
                MyHashtable<string, int> kelimefrekans = new MyHashtable<string, int>();
                foreach (string tweet in user.Tweetler)
                {
                    string[] kelimeler = tweet.Split(' ');

                    for (int i = 0; i < kelimeler.Length; i++)
                    {
                        string kelime = kelimeler[i];
                        kelime = kelime.Replace(".", "").Replace(",", "").Replace("!", "").Replace("?", "").Replace(":", "").Replace(";", "");
                        kelime = kelime.ToLower();
                        kelimeler[i] = kelime;
                        if (kelimefrekans.ContainsKey(kelime))
                        {
                            kelimefrekans[kelime]++;
                        }
                        else
                        {
                            kelimefrekans[kelime] = 1;
                        }
                    }
                }

                MyList<string> kullan�c�_ilgialanlar� = new MyList<string>();
            
                foreach (var entry in kelimefrekans)
                {
                    if (entry.Value >= minfrekans)
                    {
                        kullan�c�_ilgialanlar�.Add(entry.Key);
                    }
                }

                foreach (string ilgialan� in kullan�c�_ilgialanlar�)
                {

                    if (!ilgialanlar�.ContainsKey(ilgialan�))
                    {
                        ilgialanlar�[ilgialan�] = new MyList<Kullan�c�>();
                    }

                    ilgialanlar�[ilgialan�].Add(user);
                }
            }

            MyList<string> silinecekkelimeler = new MyList<string> {"this", "that", "and","so","he","she","we","no","yes","they","them","his","her","their","by","the","those","him","pm","any","us","or" };
            ilgialanlar�.RemoveKeys(silinecekkelimeler);

            foreach (var x in ilgialanlar�)
            {
                dataGridView2.Rows.Add(x.Key);
            }
            HashSet<string> �lkeler = new HashSet<string>();

            foreach (var user in kullan�c�lar)
            {
                if (!string.IsNullOrEmpty(user.B�lge))
                {
                    �lkeler.Add(user.B�lge);
                }
            }

            foreach (string �lke in �lkeler)
            {
                foreach (var ilgialan� in ilgialanlar�)
                {
                    foreach (Kullan�c� kullan�c� in ilgialan�.Value)
                    {
                        if (kullan�c�.B�lge.Contains(�lke))
                        {
                            b�lgetrendolankonullar.Add(�lke, ilgialanlar�);
                        }
                    }
                }
            }

        }
     
        private void LoadDataIntoDataGridView3(string deger)
        {
            dataGridView3.Rows.Clear();
            foreach (var x in ilgialanlar�)
            {
                if (x.Key == deger)
                {
                    foreach (var y in x.Value)
                    {
                        dataGridView3.Rows.Add(y.Username);
                    }
                }

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView3(girilendeger);
        }
        string girilendeger;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            girilendeger = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            E�le�me_Tablosu e�le�me_Tablosu = new E�le�me_Tablosu(kullan�c�lar, ilgialanlar�);
            e�le�me_Tablosu.Show();
            //datagridview3guncelle();
        }
        public static Kullan�c� AramaYap(MyList<Kullan�c�> kullan�c�lar, string arananUsername)
        {
            return kullan�c�lar.FirstOrDefault(k => k.Username == arananUsername);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string arananusername = textBox2.Text;
                Kullan�c� aranankullan�c� = AramaYap(kullan�c�lar, arananusername);
                Graph aranankullan�c�graph = new Graph();
                aranankullan�c�graph.AddKullan�c�(aranankullan�c�.Username);
                foreach (string takipedilen in aranankullan�c�.TakipEdilenKullan�c�Adlar�)
                {
                    aranankullan�c�graph.AddTakipili�kisi(aranankullan�c�.Username, takipedilen);
                }

                Microsoft.Msagl.Drawing.Graph msaglGraph = aranankullan�c�graph.ToMsaglGraph();

                GViewer viewer = new GViewer();
                viewer.Graph = msaglGraph;

                Form form = new Form();
                form.Show();
                viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                form.Controls.Add(viewer);
                form.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = textBox3.Text;
            foreach (var x in b�lgetrendolankonullar)
            {
                if (x.Key == a)
                {
                    dataGridView4.Rows.Clear();
                    foreach (var konular in x.Value)
                    {

                        dataGridView4.Rows.Add(konular.Key);
                    }
                }

            }
        }
    }

}