using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int[] arr) : this(arr.Select(x => x as int?).ToList())
        {

        }
        public TreeNode(List<int?> arr)
        {
            CreateTree(arr, this);
        }
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
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
        // 0, 0 1, 0 1 10 11, 0 1 10 11 100 101 110 111
        public static TreeNode CreateTree(int[] arr, TreeNode tree = null)
        {
            return CreateTree(new List<int?>(arr.Select(x => x as int?)), tree);
        }
        public static TreeNode CreateTree(List<int?> arr, TreeNode tree = null)
        {
            tree ??= new TreeNode();
            if (arr.Count == 0) return null;
            tree.val = arr[0]!.Value;
            var l = "";

            for (int i = 1; i < arr.Count; i++)
            {
                TreeNode? temp = null;
                var curr = tree;
                l = addOne(l);
                for (int j = 0; j < l.Length; j++)
                {
                    temp = curr;
                    if (l[j] == 'l') curr = curr.left;
                    if (l[j] == 'r') curr = curr.right;
                    if (curr == null) break;
                }
                if (temp != null && arr[i] != null)
                {
                    if (l.Last() == 'l') temp.left = new TreeNode(arr[i].Value);
                    if (l.Last() == 'r') temp.right = new TreeNode(arr[i].Value);
                }
            }

            // 0, 0 1, 0 1 10 11, 0 1 10 11 100 101 110 111

            return tree;
        }
        // 0 1 2 3 4 5 6 
        // 0 1 1 2 2 2 2 3 3 3 ...
        private static string addOne(string l)
        {
            if (l == "") return "l";
            var arr = l.ToCharArray();
            var check = true;
            var i = arr.Length - 1;
            var dict = new Dictionary<char, char>()
            {
                { 'l','r'},
                { 'r','l'}
            };
            while (check)
            {
                if (check)
                {
                    check = false;
                    if (arr[i] == 'r') check = true;
                    arr[i] = dict[arr[i]];
                }
                else break;
                i--;
                if (i == -1) break;
            }
            var res = check ? "l" : "";
            foreach (var item in arr)
            {
                res += item;
            }
            return res;
        }
        public TreeNode Print()
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(this);
            Console.WriteLine("==========TREE==========");
            int i = 0, j = 1;
            do
            {
                var tree = queue.Dequeue();
                Console.Write(" ");
                Console.Write(tree != null ? tree : "*");
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
            if (i != 0) Console.WriteLine();
            Console.WriteLine("========================");
            return this;
        }
        public override string ToString()
        {
            return $"{val}";
        }
    }
}
