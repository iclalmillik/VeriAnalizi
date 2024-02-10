using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Prolab3
{
    public class MyHashtable<Key, Value> :  IEnumerable<KeyValuePair<Key, Value>>
    {
        private const int defkapasite = 100;
        private const double loadFactor = 0.75;
        private int boyut;
        private int kapasite;
        public MyLinkedList<KeyValuePair<Key, Value>>[] buckets;

        public MyHashtable()
        {
            kapasite = defkapasite;
            buckets = new MyLinkedList<KeyValuePair<Key, Value>>[kapasite];
        }

        private int GetHashCode(Key key)
        {
            int hashCode = key.GetHashCode();
            return (hashCode < 0 ? -hashCode : hashCode) % kapasite;
        }
         public IEnumerator<KeyValuePair<Key, Value>> GetEnumerator()
         {
        foreach (var bucket in buckets)
        {
            if (bucket != null)
            {
                foreach (var element in bucket)
                {
                    yield return new KeyValuePair<Key, Value>(element.Key, element.Value);
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    public bool IsReadOnly => false;

        public void Add(Key key, Value value)
        {
            int index = GetHashCode(key);

            if (buckets[index] == null)
            {
                buckets[index] = new MyLinkedList<KeyValuePair<Key, Value>>();
            }
            else
            {
                foreach (var element in buckets[index])
                {
                    if (element.Key.Equals(key))
                    {
                        buckets[index].Remove(element);
                        buckets[index].AddLast(new KeyValuePair<Key, Value>(key, value));
                        return;
                    }
                }
            }

            buckets[index].AddLast(new KeyValuePair<Key, Value>(key, value));
            boyut++;

            if ((double)boyut / kapasite >= loadFactor)
            {
                ResizeAndRehash();
            }
        }


        public bool GetValue(Key key, out Value value)
        {
            int index = GetHashCode(key);
            if (buckets[index] != null)
            {
                foreach (var element in buckets[index])
                {
                    if (element.Key.Equals(key))
                    {
                        value = element.Value;
                        return true;
                    }
                }
            }
            value = default;
            return false;
        }
       
        public Value this[Key key]
        {
            get
            {
                if (GetValue(key, out Value value))
                {
                    return value;
                }
                throw new KeyNotFoundException("Anahtar bulunamadı.");
            }
            set
            {
                Add(key, value);
            }
        }
        public bool ContainsKey(Key key)
        {
            int index = GetHashCode(key);
            if (buckets[index] != null)
            {
                foreach (var element in buckets[index])
                {
                    if (element.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void RemoveKeys(MyList<Key> silinecekkeyler)
        {
            foreach (var key in silinecekkeyler)
            {
                int index = GetHashCode(key);
                if (buckets[index] != null)
                {
                    var currentNode = buckets[index].head;
                    while (currentNode != null)
                    {
                        if (currentNode.data.Key.Equals(key))
                        {
                            buckets[index].Remove(currentNode.data);
                            boyut--;
                            break;
                        }
                        currentNode = currentNode.next;
                    }
                }
            }
        }

        private void ResizeAndRehash()
        {
            kapasite *= 2;
            var gecicibuckets = buckets;
            buckets = new MyLinkedList<KeyValuePair<Key, Value>>[kapasite];
            boyut = 0;

            foreach (var bucket in gecicibuckets)
            {
                if (bucket != null)
                {
                    foreach (var element in bucket)
                    {
                        Add(element.Key, element.Value);
                    }
                }
            }
        }
    }


}
