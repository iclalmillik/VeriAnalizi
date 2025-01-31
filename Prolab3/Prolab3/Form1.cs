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

        MyHashtable<string, MyList<Kullanıcı>> ilgialanları = new MyHashtable<string, MyList<Kullanıcı>>();

        MyHashtable<string, MyHashtable<string, MyList<Kullanıcı>>> bölgetrendolankonullar = new MyHashtable<string, MyHashtable<string, MyList<Kullanıcı>>>();
        MyList<Kullanıcı> kullanıcılar = new MyList<Kullanıcı>();
        
        public void Form1_Load(object sender, EventArgs e)
        {
            string dosyayolu = AppDomain.CurrentDomain.BaseDirectory + "kullanıcı_verileri.json";

            string jsoniçerik = File.ReadAllText(dosyayolu);

            kullanıcılar = JsonSerializer.Deserialize<MyList<Kullanıcı>>(jsoniçerik);


            MyHashtable<string, Kullanıcı> Kullanıcıtablosu = new MyHashtable<string, Kullanıcı>();

            foreach (Kullanıcı user in kullanıcılar)
            {
                Kullanıcıtablosu.Add(user.Username, user);
                dataGridView1.Rows.Add(user.Username);

            }

            int minfrekans = 2;
            MyHashtable<string, MyHashtable<string, int>> userilgialanları = new MyHashtable<string, MyHashtable<string, int>>();

            MyHashtable<string, MyHashtable<string, int>> userkelimefrekans = new MyHashtable<string, MyHashtable<string, int>>();

            MyHashtable<string, MyList<Kullanıcı>> ilişkilistesi = new MyHashtable<string, MyList<Kullanıcı>>();



            foreach (Kullanıcı user in kullanıcılar) 
            {
                graph.AddKullanıcı(user.Username);
                foreach (string takipedilen in user.TakipEdilenKullanıcıAdları)
                {
                    graph.AddTakipilişkisi(user.Username, takipedilen);
                }
            }

            foreach (Kullanıcı user in kullanıcılar)
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

                MyList<string> kullanıcı_ilgialanları = new MyList<string>();
            
                foreach (var entry in kelimefrekans)
                {
                    if (entry.Value >= minfrekans)
                    {
                        kullanıcı_ilgialanları.Add(entry.Key);
                    }
                }

                foreach (string ilgialanı in kullanıcı_ilgialanları)
                {

                    if (!ilgialanları.ContainsKey(ilgialanı))
                    {
                        ilgialanları[ilgialanı] = new MyList<Kullanıcı>();
                    }

                    ilgialanları[ilgialanı].Add(user);
                }
            }

            MyList<string> silinecekkelimeler = new MyList<string> {"this", "that", "and","so","he","she","we","no","yes","they","them","his","her","their","by","the","those","him","pm","any","us","or" };
            ilgialanları.RemoveKeys(silinecekkelimeler);

            foreach (var x in ilgialanları)
            {
                dataGridView2.Rows.Add(x.Key);
            }
            HashSet<string> ülkeler = new HashSet<string>();

            foreach (var user in kullanıcılar)
            {
                if (!string.IsNullOrEmpty(user.Bölge))
                {
                    ülkeler.Add(user.Bölge);
                }
            }

            foreach (string ülke in ülkeler)
            {
                foreach (var ilgialanı in ilgialanları)
                {
                    foreach (Kullanıcı kullanıcı in ilgialanı.Value)
                    {
                        if (kullanıcı.Bölge.Contains(ülke))
                        {
                            bölgetrendolankonullar.Add(ülke, ilgialanları);
                        }
                    }
                }
            }

        }
     
        private void LoadDataIntoDataGridView3(string deger)
        {
            dataGridView3.Rows.Clear();
            foreach (var x in ilgialanları)
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
            Eşleşme_Tablosu eşleşme_Tablosu = new Eşleşme_Tablosu(kullanıcılar, ilgialanları);
            eşleşme_Tablosu.Show();
            //datagridview3guncelle();
        }
        public static Kullanıcı AramaYap(MyList<Kullanıcı> kullanıcılar, string arananUsername)
        {
            return kullanıcılar.FirstOrDefault(k => k.Username == arananUsername);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string arananusername = textBox2.Text;
                Kullanıcı aranankullanıcı = AramaYap(kullanıcılar, arananusername);
                Graph aranankullanıcıgraph = new Graph();
                aranankullanıcıgraph.AddKullanıcı(aranankullanıcı.Username);
                foreach (string takipedilen in aranankullanıcı.TakipEdilenKullanıcıAdları)
                {
                    aranankullanıcıgraph.AddTakipilişkisi(aranankullanıcı.Username, takipedilen);
                }

                Microsoft.Msagl.Drawing.Graph msaglGraph = aranankullanıcıgraph.ToMsaglGraph();

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