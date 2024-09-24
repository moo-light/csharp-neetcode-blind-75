using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Tree
{
    public class TreeNode
    {
        public int? val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int? val = null, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        //public static TreeNode CreateSortedTree(IEnumerable<int> arr, TreeNode tree = null)
        //{
        //    arr.ToList().Sort();
        //    return CreateTree(arr, tree);
        //}
        // 
        // [root,l,r,ll,lr,rl,rr,lll,llr,lrl,lrr,...]
        // [0,1,2,3,4,5,6,7,8,9,10... ]
        // [1,2,4,8] 0 1, 0 ,10,11,100
        public static TreeNode CreateTree(int[] arr, TreeNode tree = null)
        {
            return CreateTree(new List<int?>(arr.Select(x=>x as int?)), tree);
        }
        public static TreeNode CreateTree(List<int?> arr, TreeNode tree = null)
        {
            tree ??= new TreeNode();
            if (arr.Count == 0) return null;
            var q = new Queue<TreeNode>();
            var array = arr.ToList();
            tree.val = array[0];
            q.Enqueue(tree);
            for (int i = 1; i < array.Count; i++)
            {
                var node = q.Peek();
                if (node.left == null )
                {

                    node.left = new TreeNode(array[i]);
                    q.Enqueue(node.left);
                }
                else if (node.right == null)
                {
                    node.right = new TreeNode(array[i]);
                    q.Enqueue(node.right);
                    q.Dequeue();
                }
                else
                {
                }
            }
            return tree;
        }

        public void Print()
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(this);
            Console.WriteLine("==========TREE==========");
            int i = 0, j = 1;
            do
            {
                var tree = queue.Dequeue();
                Console.Write(" ");
                if(tree != null)
                Console.Write(tree?.val != null ? tree : "*");
                if (tree != null)
                {
                    queue.Enqueue(tree.left);
                    queue.Enqueue(tree.right);
                }
                if (++i == j)
                {
                    j *= 2; i = 0;
                    Console.WriteLine();
                }
            } while (queue.Count != 0);
            if(i!=0) Console.WriteLine();
            Console.WriteLine("========================");
        }
        public override string ToString()
        {
            return $"{val}";
        }
    }
}
