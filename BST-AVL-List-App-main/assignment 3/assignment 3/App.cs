using System;
using System.Net.NetworkInformation;

namespace assignment_3
{
    internal class App
    {
        
        static void Main(string[] args)
        {
            BSTree myList = new BSTree();
            AVLTree listAVL = new AVLTree();
            findFiles find = new findFiles();
            string target = "";
            findFiles fileManager = new findFiles();

            fileManager.FileManagement(target, myList, listAVL, find);

        }

      

        
        static public void Menu(string target, AVLTree listAVL, BSTree list, findFiles fileManager)
        {
            string UserChoice = null;
            while (UserChoice != "6")
            {


                Console.Clear();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("                 Main Menu BST                ");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Please select an option:");
                Console.WriteLine();
                Console.WriteLine("1. [Insert]");
                Console.WriteLine("   - Add a new item to the list.");
                Console.WriteLine("2. [Delete]");
                Console.WriteLine("   - Remove an item from the list.");
                Console.WriteLine("3. [Find]");
                Console.WriteLine("   - Search for an item in the list.");
                Console.WriteLine("4. [Print]");
                Console.WriteLine("   - Display the contents of the list.");
                Console.WriteLine("5. [New List]");
                Console.WriteLine("   - Clear cache and add a new txt. File to the list");
                Console.WriteLine("6. [Exit]");
                Console.WriteLine("   - Exit the application");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------");


                UserChoice = Console.ReadLine();

                if (UserChoice == "1")
                {
                    Console.Clear();

                    list.Add();

                    // Menu(target, listAVL, list, fileManager);

                }
                else if (UserChoice == "2")
                {
                    Console.Clear();

                    list.Delete();

                    //Menu(target, listAVL, list, fileManager);
                }
                else if (UserChoice == "3")
                {
                    Console.Clear();
                    list.Find();
                    //Menu(target, listAVL, list, fileManager);
                }
                else if (UserChoice == "4")
                {
                    Console.Clear();
                    list.Print();
                    //Menu(target, listAVL, list, fileManager);
                }
                else if (UserChoice == "5")
                {
                    Console.Clear();
                    fileManager.Wipe(target, listAVL, list, fileManager);
                    fileManager.FileManagement(target, list, listAVL, fileManager);
                    //Menu(target, listAVL, list, fileManager);
                }
                else if (UserChoice == "6")
                {
                    Environment.Exit(0);
                }
            }
        }









        static public void MenuAVL(string target, BSTree list, AVLTree listAVL, findFiles fileManager)
        {
            string UserChoice = null;
            while (UserChoice != "6")
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("                 Main Menu AVL                ");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Please select an option:");
                Console.WriteLine();
                Console.WriteLine("1. [Insert]");
                Console.WriteLine("   - Add a new item to the list.");
                Console.WriteLine("2. [Delete]");
                Console.WriteLine("   - Remove an item from the list.");
                Console.WriteLine("3. [Find]");
                Console.WriteLine("   - Search for an item in the list.");
                Console.WriteLine("4. [Print]");
                Console.WriteLine("   - Display the contents of the list.");
                Console.WriteLine("5. [New List]");
                Console.WriteLine("   - Clear cache and add a new txt. File to the list");
                Console.WriteLine("6. [Exit]");
                Console.WriteLine("   - Exit the application");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------");


                UserChoice = Console.ReadLine();

                if (UserChoice == "1")
                {
                    Console.Clear();

                    listAVL.Add();

                   // MenuAVL(target, list, listAVL, fileManager);

                }
                else if (UserChoice == "2")
                {
                    Console.Clear();

                    listAVL.Remove(target);

//                    MenuAVL(target, list, listAVL, fileManager);
                }
                else if (UserChoice == "3")
                {
                    Console.Clear();
                    listAVL.Find();
                    //MenuAVL(target, list, listAVL, fileManager);
                }
                else if (UserChoice == "4")
                {
                    Console.Clear();
                    listAVL.PrintAVL();
                   // MenuAVL(target, list, listAVL, fileManager);
                }
                else if (UserChoice == "5")
                {
                    Console.Clear();
                    fileManager.WipeAVL(target, listAVL, list, fileManager);
                    fileManager.FileManagement(target, list, listAVL, fileManager);
                   // MenuAVL(target, list, listAVL, fileManager);
                }
                else if (UserChoice == "6")
                {
                    Environment.Exit(0);
                }
                else
                {

                }
            }
        }





        //to do
        //create visual of all bstree implementation results. then call back to menu
        //implement avl tree implementation

        //implement an AVL tree




    }
}
