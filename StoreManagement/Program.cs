using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StoreManagementModels;
using StoreManagementAppService;
using StoreManagementDataService;

namespace StoreManagement
{
    internal class Program
    {
        static BranchAppService branchService =
            new BranchAppService(new BranchJsonData());

        

        static void Main(string[] args)
        {
            Console.WriteLine("STORE BRANCH MANAGER\n");
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

            static void addBranch()
            {
                
                        Console.WriteLine("ADD A NEW STORE BRANCH\n");

                        Branch newBranch = new Branch();

                        Console.WriteLine("Enter Desired Store Branch Name: ");
                        newBranch.BranchName = Console.ReadLine();

                        Console.WriteLine("Enter Branch Location: ");
                        newBranch.BranchLocation = Console.ReadLine();

                        branchService.AddBranch(newBranch);

                        Console.WriteLine("Branch added successfully!");
                        return;

                    
                
            }

            static void ViewBranch()
            {
                Console.WriteLine("\nVIEW BRANCH INFORMATION\n");

                var branches = branchService.GetBranches();

                for (int i = 0; i < branches.Count; i++)
                {
                    
                        Console.WriteLine($"Branch No: {i}");
                        Console.WriteLine($"Branch Name: {branches[i].BranchName}");
                        Console.WriteLine($"Branch Location: {branches[i].BranchLocation}");

                    
                }
            }


            static void UpdateBranch()
            {
                Console.WriteLine("\nUPDATE A BRANCH\n");

                var branches = branchService.GetBranches();

                for (int i = 0; i < branches.Count; i++)
                {
                    Console.WriteLine($"[{i}] {branches[i].BranchName} - {branches[i].BranchLocation}");
                }

                Console.WriteLine("Enter Branch No.: ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index >= 0 && index < branches.Count)
                {
                    var updated = branches[index];
                    

                    Console.WriteLine("Enter New Branch Name: ");
                    updated.BranchName = Console.ReadLine();

                    Console.WriteLine("Enter New Branch Location: ");
                    updated.BranchLocation = Console.ReadLine();

                    branchService.UpdateBranch(updated);

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

                var branches = branchService.GetBranches();

                for (int i = 0; i < branches.Count; i++)
                {
                    Console.WriteLine($"[{i}] {branches[i].BranchName} - {branches[i].BranchLocation}");
                }

                Console.WriteLine("Enter Branch Number to Remove: ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index >= 0 && index < branches.Count)
                {
                    var removed = branches[index];

                    branchService.RemoveBranch(removed.BranchId);
                    
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