using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ZensaMicrosoft
{
    class Program
    {
        public static void Main(string[] args)
        {
            Node head = null;
            LinkedList.Append(ref head, 1);
            LinkedList.Append(ref head, 2);
            LinkedList.Append(ref head, 3);
            LinkedList.Append(ref head, 4);
            LinkedList.Append(ref head, 5);
            LinkedList.Append(ref head, 6);

            Console.WriteLine("Our list:");
            LinkedList.Print(head);

            LinkedList.Reverse(ref head);
            Console.WriteLine();
            Console.WriteLine("Our Reversed list:");
            LinkedList.Print(head);


            LinkedList.ReverseUsingRecursion(head);
            head = LinkedList.newHead;


            MergerTwoArray();

        }      

        public static class LinkedList
        { 

            public static void Append(ref Node head, int data)
            {
                if (head != null)
                {
                    Node current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    current.Next = new Node();
                    current.Next.Data = data;
                }
                else
                {
                    head = new Node();
                    head.Data = data;
                }
            }

            public static void Print(Node head)
            {
                if (head == null) return;

                Node current = head;
                do
                {
                    Console.Write("{0} ", current.Data);
                    current = current.Next;
                } while (current != null);
            }

            public static void PrintRecursive(Node head)
            {
                if (head == null)
                {
                    Console.WriteLine();
                    return;
                }

                Console.Write("{0} ", head.Data);
                PrintRecursive(head.Next);
            }

            public static void Reverse(ref Node head)
            {
                if (head == null) return;

                Node prev = null, current = head, next = null;

                while (current.Next != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                current.Next = prev;
                head = current;
            }

            public static Node newHead;

            public static void ReverseUsingRecursion(Node head)
            {
                if (head == null) return;

                if (head.Next == null)
                {
                    newHead = head;
                    return;
                }

                ReverseUsingRecursion(head.Next);
                head.Next.Next = head;
                head.Next = null;

            }
        }

        public class Node
        {
            public int Data = 0;
            public Node Next = null;
        }

        //Merge two arrays
        public static void MergerTwoArray()
        {
            int[] array1 = new int[] { 3, 5, 6, 8, 9, 12, 14, 18, 20, 25, 28, 50 };
            int[] array2 = new int[] { 2, 4, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48 };

            int a1Length = array1.Length;
            int a2Length = array2.Length;
            int[] arrayResult = new int[a1Length + a2Length];

            int a = 0, b = 0;   // indexes in origin arrays
            int i = 0;          // index in result array

            // join
            while (a < a1Length && b < a2Length)
            {
                if (array1[a] <= array2[b])
                {
                    // element in first array at current index 'a'
                    // is less or equals to element in second array at index 'b'
                    // arrayResult[i++] = array1[a++];
                    arrayResult[i] = array1[a];
                    i++;
                    a++;
                }
                else
                {
                    arrayResult[i] = array2[b];
                    i++;
                    b++;
                }
            }

            // tail
            if (a < a1Length)
            {
                // fill tail from first array
                for (int j = a; j < a1Length; j++)
                {
                    arrayResult[i] = array1[j];
                    i++;
                }
            }
            else
            {
                // fill tail from second array
                for (int j = b; j < a2Length; j++)
                {
                    arrayResult[i] = array2[j];
                    i++;
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("First Array {{ {0} }}", string.Join(",", array1.Select(e => e.ToString())));
            Console.WriteLine("\n");
            Console.WriteLine("Second Array {{ {0} }}", string.Join(",", array2.Select(e => e.ToString())));
            Console.WriteLine("\n");
            Console.WriteLine("Result is {{ {0} }}", string.Join(",", arrayResult.Select(e => e.ToString())));
        }
    }
}