using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zzkluck.OBDD.Library;

namespace Zzkluck.OBDD.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeBaseNode<int> b6 = new BinaryTreeBaseNode<int>(6, null, null);
            BinaryTreeBaseNode<int> b7 = new BinaryTreeBaseNode<int>(7, null, null);
            BinaryTreeBaseNode<int> b9 = new BinaryTreeBaseNode<int>(9, null, null);
            BinaryTreeBaseNode<int> b8 = new BinaryTreeBaseNode<int>(8, null, b9);
            BinaryTreeBaseNode<int> b5 = new BinaryTreeBaseNode<int>(5, b8, null);
            BinaryTreeBaseNode<int> b4 = new BinaryTreeBaseNode<int>(4, null, null);
            BinaryTreeBaseNode<int> b2 = new BinaryTreeBaseNode<int>(2, b4, b5);
            BinaryTreeBaseNode<int> b3 = new BinaryTreeBaseNode<int>(3, b6, b7);
            BinaryTreeBaseNode<int> b1 = new BinaryTreeBaseNode<int>(1, null, b3);
            BinaryTreeRootNode<int> b0 = new BinaryTreeRootNode<int>(0, b1, b2);

            foreach(BinaryTreeBaseNode<int> b in b0)
            {
                System.Console.WriteLine(b.Value);
            }
            System.Console.ReadLine();
        }
    }
}
