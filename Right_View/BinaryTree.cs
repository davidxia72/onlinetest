using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_View
{
    public class Node
    {

        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    // class to access maximum level by reference
    public class Max_level
    {

        public int max_level;
    }

    public class BinaryTree
    {

        public Node root;
        public Max_level max = new Max_level();

        // Recursive function to print right view of a binary tree.
        public virtual void rightViewUtil(Node node, int level,
                                            Max_level max_level)
        {

            // Base Case
            if (node == null)
            {
                return;
            }

            // If this is the last Node of its level
            if (max_level.max_level < level)
            {
                Console.Write(node.data + " ");
                max_level.max_level = level;
            }

            // Recur for right subtree first, then left subtree
            rightViewUtil(node.right, level + 1, max_level);
            rightViewUtil(node.left, level + 1, max_level);
        }

        public virtual void rightView()
        {
            rightView(root);
        }

        // A wrapper over rightViewUtil()
        public virtual void rightView(Node node)
        {

            rightViewUtil(node, 1, max);
        }
    }
}
