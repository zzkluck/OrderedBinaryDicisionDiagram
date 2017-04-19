using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zzkluck.OBDD.Library
{
    public class BinaryTreeBaseNode<T>
    {
        public BinaryTreeBaseNode(T value,BinaryTreeBaseNode<T> left,BinaryTreeBaseNode<T> right, BinaryTreeBaseNode<T> parent=null)
        {
            Parent = parent;
            Left = left;
            Right = right;
            Value = value;
        }
        public T Value;
        public BinaryTreeBaseNode<T> Parent;
        public BinaryTreeBaseNode<T> Left;
        public BinaryTreeBaseNode<T> Right;
        public virtual bool isRoot() { return Parent != null; }
        public virtual bool isEnd() { return Left == null && Right == null; }
    }

    public sealed class BinaryTreeRootNode<T> : BinaryTreeBaseNode<T>, IEnumerable
    {
        public BinaryTreeRootNode(T value, BinaryTreeBaseNode<T> left, BinaryTreeBaseNode<T> right, BinaryTreeBaseNode<T> parent = null) 
            : base(value, left, right, parent)
        {
        }
        public override bool isRoot() { return true; }
        public IEnumerator GetEnumerator()
        {
            return PreorderTraversal();
        }

        public IEnumerator PreorderTraversal()
        {
            Stack<BinaryTreeBaseNode<T>> traversalStack = new Stack<BinaryTreeBaseNode<T>>();
            BinaryTreeBaseNode<T> nowTraveling = this;

            traversalStack.Push(nowTraveling);
            while (traversalStack.Count != 0)
            {
                while (nowTraveling != null)
                {
                    traversalStack.Push(nowTraveling);
                    yield return nowTraveling;
                    nowTraveling = nowTraveling.Left;
                }
                nowTraveling = traversalStack.Pop().Right;
            }
        }
        public IEnumerator<object> BreadthFirst()
        { 
            Queue<BinaryTreeBaseNode<T>> traveralQueue = new Queue<BinaryTreeBaseNode<T>>();
            traveralQueue.Enqueue(this);

            while(traveralQueue.Count!=0)
            {
                BinaryTreeBaseNode<T> node = traveralQueue.Dequeue();
                yield return node;
                if (node.Left != null)
                {
                    traveralQueue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    traveralQueue.Enqueue(node.Right);
                }
            }
        }



    }

}
