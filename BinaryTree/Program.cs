using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.root = new Node(1);
            binaryTree.root.left = new Node(2);
            binaryTree.root.right = new Node(3);
            binaryTree.root.left.left = new Node(4);
            binaryTree.root.left.right = new Node(5);
            binaryTree.root.right.left = new Node(6);
            binaryTree.root.right.right = new Node(7);
            
            Console.WriteLine("\t LevelOrder traversal of binary tree is : \n");
            binaryTree.printLevelOrder(binaryTree.root);

            Console.WriteLine("\t Inserting node with Level Order \n");
            binaryTree.insertNodewithLO(binaryTree.root, 8);

            Console.WriteLine("\t LevelOrder traversal of binary tree is : \n");
            binaryTree.printLevelOrder(binaryTree.root);

            Console.WriteLine("\t Deleting Deepest Node of binary tree : \n");
            binaryTree.deleteDeepestNode();

            Console.WriteLine("\t LevelOrder traversal of binary tree is : \n");
            binaryTree.printLevelOrder(binaryTree.root);

            Console.WriteLine("\t Inserting node with Level Order \n");
            binaryTree.insertNodewithLO(binaryTree.root, 8);

            binaryTree.deleteNodeWithParticularValue(4);
            Console.WriteLine("\t LevelOrder traversal of binary tree is : \n");
            binaryTree.printLevelOrder(binaryTree.root);

            Console.WriteLine("\t Preorder traversal of binary tree is : \n");
            binaryTree.printPreOrder(binaryTree.root);
            Console.WriteLine("\t Inorder traversal of binary tree is : \n");
            binaryTree.printInOrder(binaryTree.root);
            Console.WriteLine("\t Postorder traversal of binary tree is : \n");
            binaryTree.printInOrder(binaryTree.root);

            Console.WriteLine("\t Delete Node with value 4 : \n");
            binaryTree.deleteNodeWithParticularValue(4);

            Console.WriteLine("\t LevelOrder traversal of binary tree is : \n");
            binaryTree.printLevelOrder(binaryTree.root);

            Console.ReadKey();
        }
    }

    class Node
    {
        public int key;
        public Node left, right;
        public Node(int item)
        {
            this.key = item;
            this.left = this.right = null;
        }
        public void setKey(int value)
        {
            this.key = value;
        }
    }

    class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            this.root = null;
        }

        public void printPreOrder(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine("\t" + node.key + " \n");

            printPreOrder(node.left);

            printPreOrder(node.right);
        }

        public void printInOrder(Node node)
        {
            if (node == null)
                return;

            printInOrder(node.left);

            Console.WriteLine("\t" + node.key + " \n");

            printInOrder(node.right);
        }

        public void printPostOrder(Node node)
        {
            if (node == null)
                return;

            printPostOrder(node.left);

            printPostOrder(node.right);

            Console.WriteLine("\t" + node.key + " \n");
        }

        public void printLevelOrder(Node node)
        {
            List<List<int>> result = new List<List<int>>();
            Queue<Node> queue = new Queue<Node>();
            if (node == null)
            {
                return;
            }

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<int> current = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    Node presentNode = queue.Dequeue();
                    current.Add(presentNode.key);
                    Console.WriteLine(presentNode.key + " ");
                    if (presentNode.left != null)
                    {
                        queue.Enqueue(presentNode.left);
                    }
                    if (presentNode.right != null)
                    {
                        queue.Enqueue(presentNode.right);
                    }
                }
                result.Add(current);
            }
        }

        public void insertNodewithLO(Node node,int value)
        {
            if(node == null)
            {
                node = new Node(value);
                Console.WriteLine("Successfully inserted new node at Root !");
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while(queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();

                if(currentNode.left == null)
                {
                    currentNode.left = new Node(value);
                    Console.WriteLine("Successfully inserted new node !");
                    return;
                }
                else if(currentNode.right == null)
                {
                    currentNode.right = new Node(value);
                    Console.WriteLine("Successfully inserted new node !");
                    return;
                }
                else
                {
                    queue.Enqueue(currentNode.left);
                    queue.Enqueue(currentNode.right);
                }
            }
        }

        private Node getDeepestNode()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node currentNode = null;
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                if(currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }

            return currentNode;
        }

        public void deleteDeepestNode()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            Node prevoiusNode, currentNode = null; 

            while(queue.Count > 0)
            {
                prevoiusNode = currentNode;
                currentNode = queue.Dequeue();

                if(currentNode.left == null)
                {
                    prevoiusNode.right = null;
                    return;
                }
                else if(currentNode.right == null)
                {
                    currentNode.left = null;
                    return;
                }
                queue.Enqueue(currentNode.left);
                queue.Enqueue(currentNode.right);
            }
        }

        public void deleteNodeWithParticularValue(int value)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                if(currentNode.key == value)
                {
                    currentNode.key = getDeepestNode().key;
                    deleteDeepestNode();
                    Console.WriteLine("Node Deleted !!");
                }
                else
                {
                    if(currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }
            }
            Console.WriteLine("Node not found!!");
        }

        public void deleteTree()
        {
            root = null;
            Console.WriteLine("Tree Deleted.");
        }
    }
}
