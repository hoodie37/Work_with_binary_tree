using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_struct_2
{
    class Program
    {
       
        ///////////////NODE\\\\\\\\\\\\\\\
        
    public class tnode
    {
	   public int data;           // поле данных
       public tnode parent;
       public tnode left;  // левый потомок
       public tnode right; // правый потомок

       public tnode(int value)
        {
            data = value;
            left = null;
            right = null;
        }
    };
        ///////////////Tree\\\\\\\\\\\\\\\
       public class Tree
    {
        
	    public tnode _head;
        public int count;
        public Tree()
        {
            _head = null;
        }

            public tnode GetHead()
            {
                return _head;
            }

            ///////////////ADD\\\\\\\\\\\\\\\
       public void Add(int value)
            { 
            if (_head == null)
            {
                _head = new tnode(value);
            }
            else
            {
                AddTo(_head, value);
            }
            count++;
        }

        
       public void AddTo(tnode node, int value)
        {
            if (node.data > value )
            {
                if (node.left == null)
                {
                    node.left = new tnode(value);
                }
                else
                {
                    AddTo(node.left, value);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new tnode(value);
                }
                else
                {
                    AddTo(node.right, value);
                }
            }
       }

       public int Height(tnode p)
            {
                int l, r, h = 0;
                if (p != null)
                {
                    l = Height(p.left);
                    r = Height(p.right);
                    h = ((l > r) ? l : r) + 1;
                }
                return h;
            }

    ///////////////NLR\\\\\\\\\\\\\\\
    public void NLR(tnode node)
            {
                if (node != null)
                {
                    Console.Write($"{node.data}->");
                    NLR(node.left);
                    NLR(node.right);
                }
            }
            ///////////////LNR\\\\\\\\\\\\\\\

            public void LNR(tnode node)
            {
                if (node != null)
                {
                    LNR(node.left);
                    Console.Write($"{node.data}->");
                    LNR(node.right);
                }
            }

            ///////////////LRN\\\\\\\\\\\\\\\
            
            public void LRN(tnode node)
            {
                if (node != null)
                {
                    LRN(node.left);
                    LRN(node.right);
                    Console.Write($"{node.data}->");
                }
            }

           public void print_Tree(tnode head, int level)
            {
                if (head != null)
                {
                    print_Tree(head.left, level + 1);
                    for (int i = 0; i < level; i++) Console.Write("___");
                    Console.Write( $"{head.data}\n");
                    print_Tree(head.right, level + 1);
                }
            }

        };
    
    static void Main(string[] args)
        {
            int n = 20;
            int[] a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                int flag = 0;
                while (flag == 0)
                {
                    int num1 = 100 + rnd.Next() % 899;
                    int num2 = rnd.Next() % 1000;
                    a[i] = num1 * 1000 + num2;
                    flag = 1;
                    for (int j = 0; j < i; j++)
                    {
                        if (a[j] == a[i]) flag = 0;
                    }
                }
            }

            Tree t = new Tree();
            for (int i = 0; i < n; i++) {
                t.Add(a[i]);
             }

            t.print_Tree(t.GetHead(),1);
            Console.WriteLine("\nNLR :");
            t.NLR(t.GetHead());
            Console.WriteLine("\nLNR : ");
            t.LNR(t.GetHead());
            Console.WriteLine("\nLRN :");
            t.LRN(t.GetHead());
        }
    }
}
