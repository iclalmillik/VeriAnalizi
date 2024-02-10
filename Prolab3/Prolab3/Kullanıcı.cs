using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Prolab3
{
    public class Kullanıcı
    {
        public string Username { get; set; }
        public string  Name {get; set;}   
        public string Surname { get; set;}
        public int TakipçiSayısı { get; set;}
        public int TakipEdilenSayısı {  get; set;}
        public string Dil { get; set;}
        public string Bölge {  get; set;}
        public MyList<string> Tweetler { get; set; }
        public MyList<string> TakipçiKullanıcıAdları { get; set; }
        public MyList<string> TakipEdilenKullanıcıAdları { get; set; }


        public Kullanıcı()
        {
            this.TakipEdilenKullanıcıAdları = new MyList<string>(); 
        }

        public Kullanıcı(string username)
        {
            Username = username;
            this.TakipEdilenKullanıcıAdları = new MyList<string>(); 
        }

    }
    
}
