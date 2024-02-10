using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab3
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public T data { get; set; }
            public Node next { get; set; }

            public Node(T data)
            {
                this.data = data;
                next = null;
            }
            
        }
        public Node head;
        public int count;
        
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while(current!= null)
            {
                yield return current.data;
                current = current.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyLinkedList()
        {
            head = null;
            count = 0;
        }
        public int Count => count;

        public void AddLast(T data)
        {
            Node newnode = new Node(data);
            if(head == null)
            {
                head = newnode;
            }
            else
            {
                Node current = head;
                while(current.next != null)
                {
                    current = current.next;
                }
                current.next = newnode;
            }
            count++;
        }

        public bool Remove(T data)
{
    if (head == null)
    {
        return false;
    }

    if (head.data.Equals(data))
    {
        head = head.next;
        count--;
        return true;
    }

    Node current = head;
    while (current.next != null)
    {
        if (current.next.data.Equals(data))
        {
            current.next = current.next.next;
            count--;
            return true;
        }
        current = current.next;
    }

    return false;
}

        public void clear()
        {
            head = null;
            count = 0;
        }
       
    }
}
