using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Node
    {
        public int info;
        public Node link;
        public Node(int i)
        {
            info = i;
            link = null;
        }
    }
    class LinkedList
    {
        private Node start;

        public LinkedList()
        {
            start = null;
        }

        public void InsertAtEnd(int data)
        {
            Node p;
            Node temp = new Node(data);

            if(start==null)
            {
                start = temp;
                return;
            }

            p = start;
            while (p.link != null)
                p = p.link;

            p.link = temp;
        }

        public void InsertAtPosition(int data, int k)
        {
            Node temp;
            int i;
            if(k==1)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }

            Node p = start;
            for (i = 1; i < k - 1 && p != null; i++)
                p = p.link;

            if (p == null)
                Console.WriteLine($"you can add only upto {i} position ");
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void DeleteNode(int x)
        {
            if(start==null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            if(start.info==x)
            {
                start = start.link;
                return;
            }

            Node p = start;
            while(p.link!=null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }

            if (p.link == null)
                Console.WriteLine($"Element {x} not in the list");
            else
                p.link = p.link.link;
        }
        public void DeletekNode(int k)
        {
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            if (k==0)
            { 
                start = start.link;
                return;
            }
            int i = 0;
            Node p = start;
            while (p.link != null)
            {
                i++;
                if (i == k)
                    break;
                p = p.link;
            }

            if (p.link == null)
                Console.WriteLine($"{k+1} element is not in the list");
            else
                p.link = p.link.link;
        }
        public void DisplayNode(int k)
        {
            int i = 0;
            Node p;
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            p = start;
            while (i < k)
            {
                
                p = p.link;
                i++;
            }
            Console.Write($"The element at position {k + 1} is {p.info}");
        }
        public void CreateList()
        {
            int i, n, data;

            Console.Write("Enter number of elements ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;
            for(i=1;i<=n; i++)
            {
                Console.Write("Enter element : ");
                data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
        }
        public void DisplayList()
        {
            Node p;
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            Console.Write("List is : ");
            p = start;
            while (p != null)
            {
                Console.Write(p.info + " ");
                p = p.link;
            }
            Console.WriteLine();
        }

        public void CountNodes()
        {
            int n = 0;
            Node p = start;
            while (p != null)
            {
                n++;
                p = p.link; 
            }
            Console.WriteLine($"number of elements in the list is {n}");
        }


    }
    class Programm
    {
        static void Main(string[] args)
        {
            int choice, data, k, x;
            LinkedList list = new LinkedList();

            list.CreateList();
            
            while(true)
            {

                Console.WriteLine();
                Console.WriteLine("1:Print");
                Console.WriteLine("2:Number of nodes");
                Console.WriteLine("3:Add element");
                Console.WriteLine("4:Delete element by value");
                Console.WriteLine("5:Delete element by position");
                Console.WriteLine("6:View element bye position");
                Console.WriteLine("7:Exit");
                Console.WriteLine();

                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 7)
                    break;
                switch(choice)
                {
                    case 1:
                        list.DisplayList();
                        break;
                    case 2:
                        list.CountNodes();
                        break;
                    case 3:
                        Console.Write("Enter element to be added:");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter position:");
                        k = Convert.ToInt32(Console.ReadLine());
                        list.InsertAtPosition(data, k);
                        break;
                    case 4:
                        Console.Write("Enter value of the element to be deleted:");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.DeleteNode(data);
                        break;
                    case 5:
                        Console.Write("Enter position of the element to be deleted");
                        k = Convert.ToInt32(Console.ReadLine());
                        list.DeletekNode(k-1);
                        break;
                    case 6:
                        Console.Write("Enter the place of the element: ");
                        k = Convert.ToInt32(Console.ReadLine());
                        list.DisplayNode(k-1);
                        break;
                }

            }
        }

    }
}
