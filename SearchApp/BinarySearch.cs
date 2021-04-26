using System;
using System.Collections.Generic;
using System.Text;

namespace SearchApp
{
    public class Node
    {
        public int value;
        public Node leftChild;
        public Node rightChild;
        public Node()
        {
            value = 0;
            leftChild = null;
            rightChild = null;
        }

        public Node(int val)
        {
            value = val;
            leftChild = null;
            rightChild = null;
        }
    };
    //The nodes to the left are smaller than the current node.
    public class BinarySearch
    {
        Node root;
        public BinarySearch(int rootValue)
        {
            root = new Node(rootValue);
        }
        public BinarySearch()
        {
            root = null;
        }
        public Node GetRoot()
        {
            return root;
        }
        private Node insert(Node currentNode, int val)
        {
            if (currentNode == null)
            {
                return new Node(val);
            }
            else if (currentNode.value > val)
            {

                currentNode.leftChild = insert(currentNode.leftChild, val);

            }
            else
            {
                currentNode.rightChild = insert(currentNode.rightChild, val);
            }

            return currentNode;

        }

        public int findValue_BST(int value)
        {
            if (this.GetRoot() == null)
                return -1;
            else
                return findValue(this.GetRoot(), value);
        }

        private int findValue(Node node, int value)
        {
            if (node.value == value)
                return value;
            if (node.leftChild != null && node.value > value)
                return findValue(node.leftChild, value);
            else if (node.rightChild != null && node.value <= value)
                return findValue(node.rightChild, value);
            return -1; // not found
        }

        public void insertBST(int value)
        {

            if (GetRoot() == null)
            {
                root = new Node(value);
                return;
            }
            insert(this.GetRoot(), value);
        }
        public void inOrderPrint(Node currentNode)
        {
            if (currentNode != null)
            {
                inOrderPrint(currentNode.leftChild);
                Console.WriteLine(currentNode.value);
                inOrderPrint(currentNode.rightChild);
            }
        }
        Node searchBST(int value)
        {

            //let's start with the root 
            Node currentNode = root;
            while ((currentNode != null) && (currentNode.value != value))
            {
                //the loop will run until the currentNode IS NOT null
                //and until we get to our value
                if (value < currentNode.value)
                {
                    //traverse to the left subtree
                    currentNode = currentNode.leftChild;
                }
                else
                { //traverse to the right subtree
                    currentNode = currentNode.rightChild;

                }

            }
            //after the loop, we'll have either the searched value
            //or null in case the value was not found
            return currentNode;
        }
        public Node search(Node currentNode, int value)
        {
            if (currentNode == null)
                return null;
            else if (currentNode.value == value)
                return currentNode;
            else if (currentNode.value > value)
                return search(currentNode.leftChild, value);
            else
                return search(currentNode.rightChild, value);
        }
        public bool deleteBST(int value)
        {
            return Delete(root, value);
        }
        public bool Delete(Node currentNode, int value)
        {

            if (root == null)
            {
                return false;
            }

            Node parent = root; //To Store parent of currentNode
            while ((currentNode != null) && (currentNode.value != value))
            {
                parent = currentNode;
                if (currentNode.value > value)
                    currentNode = currentNode.leftChild;
                else
                    currentNode = currentNode.rightChild;

            }

            if (currentNode == null)
                return false;
            else if ((currentNode.leftChild == null) && (currentNode.rightChild == null))
            {
                //1. Node is Leaf Node
                //if that leaf node is the root (a tree with just root)
                if (root.value == currentNode.value)
                {

                    root = null;
                    return true;
                }
                else if (currentNode.value < parent.value)
                {

                    parent.leftChild = null;
                    return true;
                }
                else
                {

                    parent.rightChild = null;
                    return true;
                }

            }
            else if (currentNode.rightChild == null)
            {

                if (root.value == currentNode.value)
                {

                    root = currentNode.leftChild;
                    return true;
                }
                else if (currentNode.value < parent.value)
                {

                    parent.leftChild = currentNode.leftChild;
                    return true;
                }
                else
                {

                    parent.rightChild = currentNode.leftChild;
                    return true;
                }

            }
            else if (currentNode.leftChild == null)
            {
                if (root.value == currentNode.value)
                {

                    root = currentNode.rightChild;
                    return true;
                }
                else if (currentNode.value < parent.value)
                {

                    parent.leftChild = currentNode.rightChild;
                    return true;
                }
                else
                {

                    parent.rightChild = currentNode.rightChild;
                    return true;
                }

            }
            else
            {
                //Find Least Value Node in right-subtree of current Node
                Node leastNode = findLeastNode(currentNode.rightChild);
                //Set CurrentNode's Data to the least value in its right-subtree
                int tmp = leastNode.value;
                Delete(root, tmp);
                currentNode.value = leastNode.value;
                //Delete the leafNode which had the least value


                return true;
            }

        }

        //Helper function to find least value node in right-subtree of currentNode
        public Node findLeastNode(Node currentNode)
        {

            Node temp = currentNode;

            while (temp.leftChild != null)
            {
                temp = temp.leftChild;
            }

            return temp;

        }
        public void preOrderPrint(Node currentNode)
        {
            if (currentNode != null)
            {
                Console.WriteLine(currentNode.value);
                preOrderPrint(currentNode.leftChild);
                preOrderPrint(currentNode.rightChild);
            }

        }
        public int findMin(Node rootNode)
        {
            // So keep traversing (in order) towards left till you reach leaf node,
            //and then return leaf node's value
            if (rootNode == null)
                return -1;
            else if (rootNode.leftChild == null)
                return rootNode.value;
            else
                return findMin(rootNode.leftChild);
        }
        /*
         * Base case: If there is no node, return 0.

             Else: If there are 1 or 2 children, return the maximum of the height of the left and right sub-trees, plus 1 to account for the current node. The height of a sub-tree is found by recursively calling the function, and passing the child node as the parameter.
        */
        private int findMax(int a, int b)
        {
            if (a >= b)
                return a;
            else
                return b;
        }

        public int findHeight(Node root)
        {
            // Base case:
            if (root == null)
                return 0;

            return findMax(findHeight(root.leftChild), findHeight(root.rightChild)) + 1;
        }

    }
}
