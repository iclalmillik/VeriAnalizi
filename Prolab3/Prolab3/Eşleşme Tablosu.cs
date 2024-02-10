using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prolab3
{
    public partial class Eşleşme_Tablosu : Form
    {
        MyList<Kullanıcı> kullanıcılar { get; set; }
        MyHashtable<string, MyList<Kullanıcı>> ilgialanları = new MyHashtable<string, MyList<Kullanıcı>>();

        public Eşleşme_Tablosu(MyList<Kullanıcı> kullanıcılar, MyHashtable<string, MyList<Kullanıcı>> ilgialanları)
        {
            InitializeComponent();
            this.kullanıcılar = kullanıcılar;
            this.ilgialanları = ilgialanları;
        }
        public double JaccardBenzerligi(MyList<string> tweetler1, MyList<string> tweetler2)
        {
            HashSet<string> kelimeler1 = new HashSet<string>(tweetler1.SelectMany(tweet => tweet.Split(' ')));
            HashSet<string> kelimeler2 = new HashSet<string>(tweetler2.SelectMany(tweet => tweet.Split(' ')));

            HashSet<string> kesisim = new HashSet<string>(kelimeler1);
            kesisim.IntersectWith(kelimeler2);

            HashSet<string> birlesim = new HashSet<string>(kelimeler1);
            birlesim.UnionWith(kelimeler2);

            return (double)kesisim.Count / birlesim.Count;
        }
        public void kullanıcılarıeşleştir(MyList<Kullanıcı> kullanıcılar)
        {


            double benzerlikSiniri = 0.05;
            if (kullanıcılar != null)
            {
                var filteredUsers = kullanıcılar.Where(u => u != null && u.TakipEdilenKullanıcıAdları != null);

                foreach (Kullanıcı user1 in filteredUsers)
                {
                    var filteredFollowedUsers = filteredUsers.Where(u => u != user1 && !user1.TakipEdilenKullanıcıAdları.Contains(u.Username) && u.TakipEdilenKullanıcıAdları != null);

                    foreach (Kullanıcı user2 in filteredFollowedUsers)
                    {
                        double benzerlikOrani = JaccardBenzerligi(user1.Tweetler, user2.Tweetler);

                        if (benzerlikOrani >= benzerlikSiniri)
                        {
                            user1.TakipEdilenKullanıcıAdları.Add(user2.Username);
                            user1.TakipEdilenSayısı++;
                            user2.TakipçiSayısı++;
                            user2.TakipçiKullanıcıAdları.Add(user2.Username);
                        }
                    }
                }
            }
        }


        private void Eşleşme_Tablosu_Load(object sender, EventArgs e)
        {


            MyList<int> eslesmeöncesitakipcisay = new MyList<int>();
            MyList<int> eslesmeöncesitakipsay = new MyList<int>();
            int i = 0;
            foreach (Kullanıcı user in kullanıcılar)
            {
                dataGridView1.Rows.Add(user.Username, user.TakipçiSayısı, user.TakipEdilenSayısı);
                eslesmeöncesitakipcisay.Add(user.TakipçiSayısı);
                eslesmeöncesitakipsay.Add(user.TakipEdilenSayısı);
                i++;
            }
            i = 0;
            kullanıcılarıeşleştir(kullanıcılar);
            MyList<string> eslestirilentakipciler = new MyList<string>();
            MyList<string> eslestirilentakipedilenler = new MyList<string>();

            foreach (Kullanıcı user in kullanıcılar)
            {
                for (int j = 0; j < user.TakipEdilenSayısı - eslesmeöncesitakipsay[i]; j++)
                {
                    eslestirilentakipciler.Add(user.TakipEdilenKullanıcıAdları[eslesmeöncesitakipsay[i] + 1]);
                }

                dataGridView2.Rows.Add(user.Username, user.TakipçiSayısı, user.TakipEdilenSayısı);
            }

        }
    }
}
