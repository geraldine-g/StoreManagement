using System;
using System.Collections.Generic;
using System.Text;
using StoreManagementModels;
using System.Text.Json;

namespace StoreManagementDataService
{
    public class BranchJsonData : IBranchDataService
    {
        private List<Branch> branches = new List<Branch>();
        private string filePath;

        public BranchJsonData()
        {
            filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/branches.json";

            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "[]");

            Load();
        }
        
        private void Load()
        {
            string json = File.ReadAllText(filePath);
            branches = JsonSerializer.Deserialize<List<Branch>>(json) ?? new List<Branch>();
        }

        private void Save()
        {
            string json = JsonSerializer.Serialize(branches, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public void Add(Branch branch)
        {
            Load();
            branches.Add(branch);
            Save();
        }

        public List<Branch> GetBranches()
        {
            Load();
            return branches;
        }

        public void Update(Branch branch)
        {
            Load();
            var existing = branches.FirstOrDefault(b => b.BranchId == branch.BranchId);

            if (existing != null)
            {
             existing.BranchName = branch.BranchName;
             existing.BranchLocation = branch.BranchLocation;
            }

            Save();
        }

        public void Remove(Guid id)
        {
            Load();
            var branch = branches.FirstOrDefault(b => b.BranchId == id);

            if (branch != null)
            {
                branches.Remove(branch);
                Save();
            }

        }



            public Branch GetById(Guid id)
        {
            Load();
            

            return branches.FirstOrDefault(b => b.BranchId == id);
        }
    }
    }
