using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace assignment_3
{
    internal class BSTree
    {
        
      

        public Node Root { get; set; }
        public BSTree() {
            Root = null;
        }


        #region ----------------------------------- Insert -------------------------------------
        public void Add()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("              BSTree Insert New               ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please type the word you wish to add to the list: ");
            string newWord = Console.ReadLine();
            Node newNode = new Node(newWord, newWord.Length);


            if (Search(Root, newNode) != null)
            {
                Console.WriteLine("The word" + newWord + " is already in the directory.");
                Console.WriteLine("Do you wish to try another word? y/n");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    Add();
                }
                else if (choice == "n")
                {
                    return;
                }
            }
            else
            {
                
                if (Root == null)
                {

                    Root = newNode;

                }
                else
                {
                    Insert(Root, newNode);
                }
                Console.WriteLine("Your chosen " + newNode + " has been added to the directory");
                Console.WriteLine("Do you wish to add another word? y/n");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    Add();
                }
                else if (choice == "n")
                {
                    return;
                }
            }

            
        }
        public void Insert(Node root, Node node)
        {
            //this is a recursive method used to traverse the tree
            //compare node for less than node in tree
          
            if (root.Word.CompareTo(node.Word) < 0)
            {
                if (root.Left == null)
                {//2 left is empty, insert node
                    root.Left = node;
                }
                else
                {// 3. left not empty traverse the tree using recursive call
                    Insert(root.Left, node);
                }
            }
            else if (root.Word.CompareTo(node.Word) > 0)
            {
                if (root.Right == null)
                {
                    // 5. right is empty, insert node
                    root.Right = node;
                }
                else
                {
                    // 6. right not empty traverse the tree using recursive call
                    Insert(root.Right, node);
                }
            }
        }
        #endregion
        //insert complete

        #region ----------------------------------- Delete -------------------------------------

        public string Delete()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                BSTree Delete                 ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please type the word you wish to Delete from the list: ");
            string deleteWord = Console.ReadLine();

            Node deleteNode = new Node(deleteWord, deleteWord.Length);
            deleteNode = Search(Root, deleteNode);
            if (deleteNode != null)
            {
                Root = DeleteProcess(Root, deleteNode);
                Console.WriteLine("Target: " + deleteNode.ToString() + ", NODE removed");
            }
            else
            {
                Console.WriteLine("Target: " + deleteNode.ToString() + ", NODE not found");
               
            }
            Console.WriteLine();
            Console.WriteLine("Do you want to find another word? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "y")
            {
                return null; // Exit the loop if the user's response is not "yes"
            }
            else
            {
                return Delete();
            }
        }



        public Node DeleteProcess(Node root, Node deleteNode)
        {

            


            if (root == null)
            {//reached null side of the tree, return to unload stack
                return root;
            }
            if (root.Word.CompareTo(deleteNode.Word) < 0)
            {
                Console.WriteLine("Visiting: " + root.Word);
                root.Left = DeleteProcess(root.Left, deleteNode);
            }
            else if (root.Word.CompareTo(deleteNode.Word) > 0)
            {
                Console.WriteLine("Visiting: " + root.Word);
                root.Right = DeleteProcess(root.Right, deleteNode);
            }
            else
            {//found node to delete
             //check if node has only one child or no child
             if (root.Left == null)
                {
                    return root.Right;
                }
             else if (root.Right == null)
                {
                    return root.Left;
                }
                else
                {
                    root.Length = MinValue(root.Right);
                    root.Right = DeleteProcess(root.Right, root);
                }
            }
            return root;
        }

        private int MinValue(Node node)
        {
            int minval = node.Word.Length;
            while (node.Left != null)
            {
                minval = node.Left.Length;
                node = node.Left;
            }
            return minval;
        }


        #endregion 
        //delete complete


        public void Find()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                 BSTree Find                  ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please type the word you wish to Find in the list: ");
            string findWord = Console.ReadLine();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Node newNode = new Node(findWord, findWord.Length);
            newNode = Search(Root, newNode);
            
            
                if (newNode != null)
                {
                    Console.WriteLine("FOUND Target: " + newNode.ToString() + "  Length: " + findWord.Length.ToString());
                TimeSpan timespan = sw.Elapsed;
                Console.WriteLine(@"- Time taken to insert BST file");
                Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.ffffff") + " seconds\n");
                Console.ReadKey();
            }
                else
                {
                    Console.WriteLine("Target: " + findWord + " NOT FOUND");
                }
            Console.WriteLine("Do you want to find another word? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "y")
            {
                return; // Exit the loop if the user's response is not "yes"
            }
            else
            {
                Find();
            }
        }

        public Node Search(Node root, Node node)
        {
            if (root != null)
            {
                
                if (root.Word.CompareTo(node.Word) == 0)
                {
                    return root;
                }
                if (root.Word.CompareTo(node.Word) < 0)
                {
                    return Search(root.Left, node);
                }
                else
                {
                    return Search(root.Right, node);
                }
            }
            return null;

        }



        #region ----------------------------------- Traversal -------------------------------------
        public string TraversePreOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(node.ToString() + " ");
                sb.Append(TraversePreOrder(node.Left));
                sb.Append(TraversePreOrder(node.Right));
            }
            return sb.ToString();
        }

        public string TraversePostOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraversePostOrder(node.Left));
                sb.Append(TraversePostOrder(node.Right));
                sb.Append(node.ToString() + " ");
            }
            return sb.ToString();
        }

        public string TraverseInOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraverseInOrder(node.Left));
                sb.Append(node.ToString() + " ");
                sb.Append(TraverseInOrder(node.Right));
            }
            return sb.ToString();
        }
        #endregion

        #region ------------------------------ Ordering Print -------------------------------------
        public string Print()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("            BSTree Traversal order            ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please choose a traversal order");
            Console.WriteLine("1. [PreOrder]");
            Console.WriteLine("2. [InOrder]");
            Console.WriteLine("3. [PostOrder]");
            string ordered = Console.ReadLine();



            StringBuilder sb = new StringBuilder();

            if (Root == null)
            {
                sb.Append("TREE is EMPTY");
            }
            else if (ordered == "1")
            {
                sb.Append(TraversePreOrder(Root));
            }
            else if (ordered == "2")
            {
                sb.Append(TraverseInOrder(Root));
            }
            else if (ordered == "3")
            {
                sb.Append(TraversePostOrder(Root));
            }
            else
            {
                sb.Append("Invalid order specified");
            }
            
            Console.WriteLine(sb.ToString());
            Console.WriteLine();
            Console.WriteLine("Do you want to print again? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "y")
            {
                return sb.ToString(); // Exit the loop if the user's response is not "yes"
            }
            else
            {
               return Print();
            }
            

        }




        #endregion
        //Traversal Complete (connect to find functions)


    }
}
