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

        MyHashtable<string, MyList<Kullanýcý>> ilgialanlarý = new MyHashtable<string, MyList<Kullanýcý>>();

        MyHashtable<string, MyHashtable<string, MyList<Kullanýcý>>> bölgetrendolankonullar = new MyHashtable<string, MyHashtable<string, MyList<Kullanýcý>>>();
        MyList<Kullanýcý> kullanýcýlar = new MyList<Kullanýcý>();
        
        public void Form1_Load(object sender, EventArgs e)
        {
            string dosyayolu = AppDomain.CurrentDomain.BaseDirectory + "kullanýcý_verileri.json";

            string jsoniçerik = File.ReadAllText(dosyayolu);

            kullanýcýlar = JsonSerializer.Deserialize<MyList<Kullanýcý>>(jsoniçerik);


            MyHashtable<string, Kullanýcý> Kullanýcýtablosu = new MyHashtable<string, Kullanýcý>();

            foreach (Kullanýcý user in kullanýcýlar)
            {
                Kullanýcýtablosu.Add(user.Username, user);
                dataGridView1.Rows.Add(user.Username);

            }

            int minfrekans = 2;
            MyHashtable<string, MyHashtable<string, int>> userilgialanlarý = new MyHashtable<string, MyHashtable<string, int>>();

            MyHashtable<string, MyHashtable<string, int>> userkelimefrekans = new MyHashtable<string, MyHashtable<string, int>>();

            MyHashtable<string, MyList<Kullanýcý>> iliþkilistesi = new MyHashtable<string, MyList<Kullanýcý>>();



            foreach (Kullanýcý user in kullanýcýlar) 
            {
                graph.AddKullanýcý(user.Username);
                foreach (string takipedilen in user.TakipEdilenKullanýcýAdlarý)
                {
                    graph.AddTakipiliþkisi(user.Username, takipedilen);
                }
            }

            foreach (Kullanýcý user in kullanýcýlar)
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

                MyList<string> kullanýcý_ilgialanlarý = new MyList<string>();
            
                foreach (var entry in kelimefrekans)
                {
                    if (entry.Value >= minfrekans)
                    {
                        kullanýcý_ilgialanlarý.Add(entry.Key);
                    }
                }

                foreach (string ilgialaný in kullanýcý_ilgialanlarý)
                {

                    if (!ilgialanlarý.ContainsKey(ilgialaný))
                    {
                        ilgialanlarý[ilgialaný] = new MyList<Kullanýcý>();
                    }

                    ilgialanlarý[ilgialaný].Add(user);
                }
            }

            MyList<string> silinecekkelimeler = new MyList<string> {"this", "that", "and","so","he","she","we","no","yes","they","them","his","her","their","by","the","those","him","pm","any","us","or" };
            ilgialanlarý.RemoveKeys(silinecekkelimeler);

            foreach (var x in ilgialanlarý)
            {
                dataGridView2.Rows.Add(x.Key);
            }
            HashSet<string> ülkeler = new HashSet<string>();

            foreach (var user in kullanýcýlar)
            {
                if (!string.IsNullOrEmpty(user.Bölge))
                {
                    ülkeler.Add(user.Bölge);
                }
            }

            foreach (string ülke in ülkeler)
            {
                foreach (var ilgialaný in ilgialanlarý)
                {
                    foreach (Kullanýcý kullanýcý in ilgialaný.Value)
                    {
                        if (kullanýcý.Bölge.Contains(ülke))
                        {
                            bölgetrendolankonullar.Add(ülke, ilgialanlarý);
                        }
                    }
                }
            }

        }
     
        private void LoadDataIntoDataGridView3(string deger)
        {
            dataGridView3.Rows.Clear();
            foreach (var x in ilgialanlarý)
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
            Eþleþme_Tablosu eþleþme_Tablosu = new Eþleþme_Tablosu(kullanýcýlar, ilgialanlarý);
            eþleþme_Tablosu.Show();
            //datagridview3guncelle();
        }
        public static Kullanýcý AramaYap(MyList<Kullanýcý> kullanýcýlar, string arananUsername)
        {
            return kullanýcýlar.FirstOrDefault(k => k.Username == arananUsername);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string arananusername = textBox2.Text;
                Kullanýcý aranankullanýcý = AramaYap(kullanýcýlar, arananusername);
                Graph aranankullanýcýgraph = new Graph();
                aranankullanýcýgraph.AddKullanýcý(aranankullanýcý.Username);
                foreach (string takipedilen in aranankullanýcý.TakipEdilenKullanýcýAdlarý)
                {
                    aranankullanýcýgraph.AddTakipiliþkisi(aranankullanýcý.Username, takipedilen);
                }

                Microsoft.Msagl.Drawing.Graph msaglGraph = aranankullanýcýgraph.ToMsaglGraph();

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
            foreach (var x in bölgetrendolankonullar)
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