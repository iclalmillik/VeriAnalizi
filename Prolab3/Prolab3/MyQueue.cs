using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab3
{
    public class MyQueue
    {
        private Node front, rear;
        private class Node
        {
            public string data;
            public Node next;
            public Node(string data)
            {
                this.data = data;
                this.next = null;
            }

        }
        public void Enqueue(string  data)
        {
            Node newNode = new Node(data);
            if(rear== null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear= newNode;
            }
        }
        public string Dequeue()
        {
            if (BosMu())
            {
                throw new InvalidOperationException("Kuyruk Boş");
            }
            string data = front.data;
            front = front.next;
            if(front == null)
            {
                rear = null;
            }
            return data;
        }
        public bool BosMu() => front == null;
    }
}
