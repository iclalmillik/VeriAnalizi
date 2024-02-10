using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab3
{
    public class Graph
    {
      
        public MyHashtable<string, Kullanıcı> kullanıcılar {  get; set; }
        public Graph()
        {
            kullanıcılar = new MyHashtable<string, Kullanıcı>();
        }

        public void AddKullanıcı( string kullanıcıadı)
        {
            if (!kullanıcılar.ContainsKey(kullanıcıadı))
            {
                kullanıcılar[kullanıcıadı] = new Kullanıcı(kullanıcıadı);

            }
        }
        public void AddTakipilişkisi(string takipci, string takipedilen)
        {
            if(kullanıcılar.ContainsKey(takipci) )
            {
                kullanıcılar[takipci].TakipEdilenKullanıcıAdları.Add(takipedilen);
            }
        }
        public Microsoft.Msagl.Drawing.Graph ToMsaglGraph()
        {
            Microsoft.Msagl.Drawing.Graph msaglGraph = new Microsoft.Msagl.Drawing.Graph();

            
            foreach (var user in kullanıcılar)
            {
                var node = msaglGraph.AddNode(user.Key);


                foreach (var followedUser in user.Value.TakipEdilenKullanıcıAdları)
                {
                    msaglGraph.AddEdge(user.Key, followedUser);
                }
            }

            return msaglGraph;
        }
        public MyList<Kullanıcı> KısaYolBul(string basUsername, string nextUsername)
        {
            MyQueue kuyruk = new MyQueue();
            MyHashtable<string, bool> visited = new MyHashtable<string, bool>();
            MyHashtable<string, string> parent = new MyHashtable<string, string>();
            foreach(var kullanıcı in kullanıcılar)
            {
                visited[kullanıcı.Key] = false;
                parent[kullanıcı.Key] = null;
            }
            kuyruk.Enqueue(basUsername);
            visited[basUsername]=true;

            while (!kuyruk.BosMu())
            {
                string currentuser = kuyruk.Dequeue();
                if(currentuser== nextUsername)
                {
                    MyList<Kullanıcı> enKısaYol = new MyList<Kullanıcı>();
                    string current = nextUsername;
                    while(current!= null)
                    {
                        enKısaYol.Add(kullanıcılar[current]);
                        current = parent[current];
                    }
                    enKısaYol.Reverse();
                    return enKısaYol;
                }
                foreach(string komsuUsername in kullanıcılar[currentuser].TakipEdilenKullanıcıAdları )
                {
                    if (!visited[komsuUsername])
                    {

                        kuyruk.Enqueue(komsuUsername);
                        visited[komsuUsername]=true;
                        parent[komsuUsername] = currentuser;
                    }
                }
            }
            return new MyList<Kullanıcı>();
        }
        public MyList<Kullanıcı> OrtakTakipciBull(string user1username, string user2username)
        {
            var ortakTakipciler = new MyList<Kullanıcı>();
            var user1Takipciler = kullanıcılar[user1username].TakipçiKullanıcıAdları;
            var user2Takipciler = kullanıcılar[user2username].TakipçiKullanıcıAdları;

            foreach (var username in user1Takipciler)
            {
                if (user2Takipciler.Contains(username))
                {
                    ortakTakipciler.Add(kullanıcılar[username]);
                }
            }

            return ortakTakipciler;
        }

    }
}
