using assignment_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace assignment_3
{
    internal class AVLTree
    {
       public Node Root { get; set; }
        public AVLTree()
        {
            Root = null;
        }

        public void Add()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("              AVLTree Insert New               ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please type the word you wish to add to the list: ");
            string newWord = Console.ReadLine();
            Node node = new Node(newWord, newWord.Length);
            
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                if(Search(Root, newWord) == null)
                {
                    Root = InsertNode(Root, node);
                }
                else
                {
                    Console.WriteLine($"Duplication, will not add");
                }
                
            }
        }
        public Node InsertNode(Node tree, Node node)
        {
            if (tree == null)
            {
                tree = node;
                return tree;
            }
            else if (node.Word.CompareTo(tree.Word) < 0)
            {
                tree.Left = InsertNode(tree.Left, node);
                tree = BalanceTree(tree);
            }
            else if (node.Word.CompareTo(tree.Word) > 0)
            {
                tree.Right = InsertNode(tree.Right, node);
                tree = BalanceTree(tree);
            }
            return tree;
        }

        public Node BalanceTree(Node current)
        {
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        #region ----------------------Rotations---------------------------


        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }

        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }

        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }

        private int GetHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int left = GetHeight(current.Left);
                int right = GetHeight(current.Right);
                int max = Max(left, right);
                height = max + 1;
            }
            return height;
        }

        private int Max(int left, int right)
        {
            return left > right ? left : right;
        }

        private int BalanceFactor(Node current)
        {
            int left = GetHeight(current.Left);
            int right = GetHeight(current.Right);
            int b_factor = left - right;
            return b_factor;
        }
        #endregion


        #region -------------------------traversal-----------------------

        private string TraversePreOrder(Node node, StringBuilder sb)
        {
            
            if (node != null)
            {
               sb.Append(node.ToString() + " ");
               TraversePreOrder(node.Left, sb);
               TraversePreOrder(node.Right, sb);
            }
            return sb.ToString();
        }

        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("TREE is EMPTY");
            }
            else
            {
                sb.Append(TraversePreOrder(Root, sb));
            }
            return sb.ToString();
        }


        #endregion



        #region -------------------------Delete-----------------------

        public Node Delete(Node current, string target)
        {
            Node parent = null;

            if (current == null)
            {
                return null;
            }
            else
            {
                if (target.CompareTo(current.Word) < 0)
                {
                    current.Left = Delete(current.Left, target);
                    if (BalanceFactor(current) == -2)
                    {
                        if (BalanceFactor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }

                    }
                }
                else if (target.CompareTo(current.Word) > 0)
                {
                    current.Right = Delete(current.Right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                else
                {
                    if (current.Right != null)
                    {
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Word = parent.Word;
                        current.Right = Delete(current.Right, parent.Word);
                        if (BalanceFactor(current) == 2)
                        {
                            if (BalanceFactor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else
                            {
                                current = RotateLR(current);
                            }
                        }
                    }
                    else
                    {
                        return current.Left;
                    }
                }
            }
            return current;
        }


        public string Remove(string target)
        { 
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                AVLTree Delete                 ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please type the word you wish to Delete from the list: ");
            string deleteWord = Console.ReadLine();

        Node deleteNode = new Node(deleteWord, deleteWord.Length);
        deleteNode = Search(Root, deleteWord);
            if (deleteNode != null)
            {
                Root = Delete(Root, deleteWord);
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
                return Remove(target);
            }
                    }


        #endregion


        #region -------------------------Find-----------------------

        public void Find()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                 AVLTree Find                  ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please type the word you wish to Find in the list: ");
            string findWord = Console.ReadLine();

            Node foundNode = Search(Root, findWord);
            
            

            if (foundNode != null)
            {
                Console.WriteLine("FOUND Target: " + foundNode.ToString() + "  Length: " + findWord.Length.ToString());
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


        public Node Search(Node tree, string findWord)
        {
            if (tree != null)
            {

                if (tree.Word.CompareTo(findWord) == 0)
                {
                    return tree;
                }
                if (tree.Word.CompareTo(findWord) < 0)
                {
                    return Search(tree.Left, findWord);
                }
                else
                {
                    return Search(tree.Right, findWord);
                }
            }
            return null;

        }


        #endregion

        #region ------------------------------ Ordering Print -------------------------------------
        public string PrintAVL()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("            AVLTree Print                     ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");




            StringBuilder sb = new StringBuilder();
            sb.Append(PreOrder());

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
                return PrintAVL();
            }


        }
        #endregion
    }



}


