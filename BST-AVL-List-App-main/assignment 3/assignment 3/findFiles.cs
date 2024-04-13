using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_3
{
    internal class findFiles
    {



        #region ----------------------------------- FindFiles -------------------------------------
        public void FileManagement(string target, BSTree list, AVLTree listAVL  ,findFiles find)
        {
            Console.Clear();
            string pathRandom = @"C:\Users\trist\OneDrive\Desktop\assignment 3\library\Random";
            string pathOrdered = @"C:\Users\trist\OneDrive\Desktop\assignment 3\library\Ordered";

            string[] txtFilesRandom = Directory.GetFiles(pathRandom, "*.txt");
            string[] txtFilesOrdered = Directory.GetFiles(pathOrdered, "*.txt");

            Console.WriteLine("Select Folder\n1. [Random]\n2. [Ordered]");
            string userFolder = Console.ReadLine();


            if (userFolder == "1")
            {
                Console.WriteLine("Select a .txt file to open: ");
                for (int i = 0; i < txtFilesRandom.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Path.GetFileName(txtFilesRandom[i])}");
                }
                int selectedFileIndex;
                string userFile = Console.ReadLine();
                if (int.TryParse(userFile, out selectedFileIndex) && selectedFileIndex >= 1 && selectedFileIndex <= txtFilesRandom.Length)
                {
                    string selectedFilePath = txtFilesOrdered[selectedFileIndex - 1];
                    Console.WriteLine($"Now Loading: {selectedFilePath}");
                    string[] fileContents = System.IO.File.ReadAllLines(selectedFilePath);

                    Console.WriteLine("Please select the Type of Tree you wish to use: ");
                    Console.WriteLine("1. [BST]");
                    Console.WriteLine("2. [AVL]");

                    string userTree = Console.ReadLine();
                    if (userTree == "1")
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        ProcessDataBST(fileContents, list);

                        TimeSpan timespan = sw.Elapsed;
                        Console.WriteLine(@"- Time taken to insert BST file");
                        Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.ffffff") + " seconds\n");
                        Console.ReadKey();
                        App.Menu(target, listAVL, list, find);
                    }
                    else if (userTree == "2")
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        ProcessDataAVL(fileContents, listAVL);

                        sw.Stop();
                        TimeSpan timespan = sw.Elapsed;
                        Console.WriteLine(@"- Time taken to insert BST file");
                        Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.ffffff") + " seconds\n");
                        Console.ReadKey();
                        App.MenuAVL(target, list, listAVL, find);
                    }
                    else
                    {
                        Console.WriteLine(selectedFileIndex + " is not a valid option, would you like to try again? (yes/no)");
                        string userAnswer = Console.ReadLine().ToLower();
                        if (userAnswer == "yes")
                        {
                            FileManagement(target, list, listAVL ,find);
                        }
                        else
                        {
                            System.Environment.Exit(0);
                        }
                    }
                }
            }
            else if (userFolder == "2")
            {
                Console.WriteLine("Select a .txt file to open: ");
                for (int i = 0; i < txtFilesOrdered.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Path.GetFileName(txtFilesOrdered[i])}");
                }
                int selectedFileIndex;
                string userFile = Console.ReadLine();
                if (int.TryParse(userFile, out selectedFileIndex) && selectedFileIndex >= 1 && selectedFileIndex <= txtFilesOrdered.Length)
                {
                    string selectedFilePath = txtFilesOrdered[selectedFileIndex - 1];
                    Console.WriteLine($"Now Loading: {selectedFilePath}");
                    string[] fileContents = System.IO.File.ReadAllLines(selectedFilePath);

                    Console.WriteLine("Please select the Type of Tree you wish to use: ");
                    Console.WriteLine("1. [BST]");
                    Console.WriteLine("2. [AVL]");

                    string userTree = Console.ReadLine();
                    if(userTree == "1")
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        ProcessDataBST(fileContents, list);

                        TimeSpan timespan = sw.Elapsed;
                        Console.WriteLine(@"- Time taken to insert BST file");
                        Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.ffffff") + " seconds\n");
                        Console.ReadKey();
                        App.Menu(target, listAVL, list, find);
                    }
                    else if (userTree == "2")
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        ProcessDataAVL(fileContents, listAVL);

                        TimeSpan timespan = sw.Elapsed;
                        Console.WriteLine(@"- Time taken to insert BST file");
                        Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.ffffff") + " seconds\n");
                        Console.ReadKey();
                        App.MenuAVL(target, list, listAVL, find);
                    }
                    else
                    {
                        Console.WriteLine(selectedFileIndex + " is not a valid option, would you like to try again? (yes/no)");
                        string userAnswer = Console.ReadLine().ToLower();
                        if (userAnswer == "yes")
                        {
                            FileManagement(target, list, listAVL, find);
                        }
                        else
                        {
                            System.Environment.Exit(0);
                        }
                    }


                   
                    // foreach (String line in fileContents)
                    // {
                    //  Console.WriteLine($"{line}");
                    // }


                }
                else
                {
                    Console.WriteLine(selectedFileIndex + " is not a valid option, would you like to try again? (yes/no)");
                    string userAnswer = Console.ReadLine().ToLower();
                    if (userAnswer == "yes")
                    {
                        FileManagement(target, list, listAVL, find);
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }
                }

            }
            else
            {
                Console.WriteLine(userFolder + " is not a valid option, would you like to try again? (yes/no)");
                string userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "yes")
                {
                    FileManagement(target, list, listAVL, find);
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }


        }
        #endregion


        #region ----------------------------------- BST Process Files -------------------------------------
        static void ProcessDataBST(string[] fileContents, BSTree list)
        {
            foreach (string word in fileContents)
            {
                if (word.Contains("#")) continue;

                Node newNode = new Node(word, word.Length); // Create a new Node for each word
                initAddBST(list, newNode); // Insert the new Node into the tree
            }
        }
        static void initAddBST(BSTree list, Node newNode)
        {
          
            if (list.Root == null)
            {
                list.Root = newNode;
            }
            else
            {
                initInsertBST(list.Root, newNode);
            }
        }

        static void initInsertBST(Node root, Node node)
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
                    initInsertBST(root.Left, node);
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
                    initInsertBST(root.Right, node);
                }
            }
        }
        #endregion


        #region ----------------------------------- AVL Process Files -------------------------------------
        static void ProcessDataAVL(string[] fileContents, AVLTree listAVL)
        {
            foreach (string word in fileContents)
            {
                if (word.Contains("#")) continue;

                Node newNode = new Node(word, word.Length); // Create a new Node for each word
                initAddAVL(listAVL, newNode); // Insert the new Node into the tree
            }
        }
        static void initAddAVL(AVLTree list, Node newNode)
        {
            findFiles finder = new findFiles();

            if (list.Root == null)
            {
                list.Root = newNode;
            }
            else
            {
                finder.initInsertAVL(list, list.Root, newNode);
                
            }
        }

        public Node initInsertAVL(AVLTree list ,Node tree, Node node)
        {
            if (tree == null)
            {
                tree = node;
                return tree;
            }
            else if (node.Word.CompareTo(tree.Word) < 0)
            {
                tree.Left = initInsertAVL(list, tree.Left, node);
                
            }
            else if (node.Word.CompareTo(tree.Word) > 0)
            {
                tree.Right = initInsertAVL(list, tree.Right, node);
                
            }
            return tree;
        }


        
        #endregion





        #region ----------------------------------- Wipe Files -------------------------------------
        public void Wipe(string target, AVLTree listAVL, BSTree list, findFiles fileManager)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                Wipe Directory                ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Are you sure you want to wipe the entire directory? (y/n) ");
            string userwipe = Console.ReadLine();

            if (userwipe == "y")
            {
                list.Root = Clear(list.Root);
            }
            else if (userwipe == "n")
            {
                App.Menu(target,listAVL, list, fileManager);
            }

            
        }

     

        private Node Clear(Node root)
        {
            if (root == null)
            {
                return null;
            }
            root.Left = Clear(root.Left);
            root.Right = Clear(root.Right);
            return null;
        }

        #endregion


        #region ----------------------------------- Wipe Files  avl-------------------------------------
        public void WipeAVL(string target, AVLTree listAVL, BSTree list, findFiles fileManager)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                Wipe Directory                ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Are you sure you want to wipe the entire directory? (y/n) ");
            string userwipe = Console.ReadLine();

            if (userwipe == "y")
            {
                list.Root = ClearAVL(list.Root);
            }
            else if (userwipe == "n")
            {
                App.MenuAVL(target, list, listAVL, fileManager);
            }


        }



        private Node ClearAVL(Node root)
        {
            if (root == null)
            {
                return null;
            }
            root.Left = ClearAVL(root.Left);
            root.Right = ClearAVL(root.Right);
            return null;
        }

      

        #endregion



    }
}
