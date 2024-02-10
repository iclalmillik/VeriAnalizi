using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab3
{
    public class MyList<T> : IEnumerable<T>, IEnumerable, ICollection<T>
    {
        public T[] liste;
        private int boyut;
        public int defaultkapasite = 10;
        public MyList()
        {
            liste = new T[defaultkapasite];
        }
        public int count => boyut;

        public void Add(T item)
        {
            if (boyut == defaultkapasite)
            {
               
                defaultkapasite *= 2;
                T[] newArray = new T[defaultkapasite];
                Array.Copy(liste, newArray, boyut);
                liste = newArray;
            }
            liste[boyut] = item;
            boyut++;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= liste.Length)
                {
                    throw new IndexOutOfRangeException("İndex listenin dışında bir değer!");

                }
                return liste[index];
            }
            set
            {
                if (index < 0 || index >= liste.Length)
                {
                    throw new IndexOutOfRangeException("İndex listenin dışında bir değer!");

                }
                liste[index] = value;
            }
        }
        public void Sil(int index)
        {
            if (index < 0 || index >= liste.Length)
            {
                throw new IndexOutOfRangeException("İndex listenin dışında bir değer!");
            }
            for (int i = index; i < liste.Length - 1; i++)
            {
                liste[i] = liste[i + 1];
            }
            boyut--;
            liste[boyut] = default;
        }
        public bool IsReadOnly => false;

        public int Count => boyut;// throw new NotImplementedException();

        public bool contains(T item)
        {
            return this.liste.Contains(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return liste[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(liste[i], item))
                {
                    return true;
                }
            }
            return false;
        }
        public T FirstOrDefault(Func<T, bool> predicate)
        {
            foreach (var item in liste)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Invalid starting index.");
            }

            if (count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The destination array has fewer elements than the collection.");
            }

            Array.Copy(liste, 0, array, arrayIndex, count);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
