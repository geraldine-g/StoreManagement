using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StoreManagementModels;
using StoreManagementAppService;

namespace StoreManagement
{
    internal class Program
    {
        static string[] branchName = new string[5];
        static string[] branchLocation = new string[5];

        static List<string> accessLogs = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("STORE BRANCH MANAGER\n");
            PopulateBranches();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n---------- MENU ----------\n");
                Console.WriteLine("1. Add a Branch");
                Console.WriteLine("2. View All Branches");
                Console.WriteLine("3. Update Branch Information");
                Console.WriteLine("4. Remove Branch");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter Choice (1 - 5): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addBranch();
                        break;
                    case 2:
                        ViewBranch();
                        break;
                    case 3:
                        UpdateBranch();
                        break;
                    case 4:
                        RemoveBranch();
                        break;
                    case 5:
                        isRunning = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            static void PopulateBranches()
            {
                branchName[0] = "Main Branch";
                branchLocation[0] = "Manila";

                branchName[1] = "North Branch";
                branchLocation[1] = "Baguio City";

                branchName[2] = "South Branch";
                branchLocation[2] = "Binan City";
            }
            static void addBranch()
            {
                for (int i = 0; i < branchName.Length; i++)
                {
                    if (branchName[i] == null)
                    {
                        Console.WriteLine("ADD A NEW STORE BRANCH\n");
                        Console.WriteLine("Enter Desired Store Branch Name: ");
                        branchName[i] = Console.ReadLine();

                        Console.WriteLine("Enter Branch Location: ");
                        branchLocation[i] = Console.ReadLine();

                        Console.WriteLine("Branch added successfully!");
                        return;

                    }
                }
            }

            static void ViewBranch()
            {
                Console.WriteLine("\nVIEW BRANCH INFORMATION\n");
                for (int i = 0; i < branchName.Length; i++)
                {
                    if (branchName[i] != null)
                    {
                        Console.WriteLine($"Branch No: {i}");
                        Console.WriteLine($"Branch Name: {branchName[i]}");
                        Console.WriteLine($"Branch Location: {branchLocation[i]}");

                    }
                }
            }


            static void UpdateBranch()
            {
                Console.WriteLine("\nUPDATE A BRANCH\n");
                Console.WriteLine("Enter Branch No.: ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index >= 0 && index < branchName.Length && branchName[index] != null)
                {
                    Console.WriteLine("Enter New Branch Name: ");
                    branchName[index] = Console.ReadLine();

                    Console.WriteLine("Enter New Branch Location: ");
                    branchLocation[index] = Console.ReadLine();

                    Console.WriteLine("Branch updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid branch number.");
                }
            }

            static void RemoveBranch()
            {
                Console.WriteLine("\nREMOVE A BRANCH\n");
                Console.WriteLine("Enter Branch Number to Remove: ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index >= 0 && index < branchName.Length && branchName[index] != null)
                {
                    branchName[index] = null;
                    branchLocation[index] = null;
                    Console.WriteLine("Branch removed successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid branch number.");
                }

            }
        }
    }
}