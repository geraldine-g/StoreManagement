using System;
using System.Collections.Generic;
using System.Text;
using StoreManagementModels;

namespace StoreManagementDataService
{
    public class BranchInMemoryData : IBranchDataService
    {
        private List<Branch> branches = new List<Branch>();

        public BranchInMemoryData()
        {
            
        }

        public void Add(Branch branch)
        {
            branches.Add(branch);
        }

        public List<Branch> GetBranches()
        {
            return branches;
        }

        public Branch? GetById(Guid id)
        {
            return branches.FirstOrDefault(b => b.BranchId == id);
        }

        public void Update(Branch branch)
        {
            var existing = branches.FirstOrDefault(b => b.BranchId == branch.BranchId);

            if (existing != null)
            {
                existing.BranchName = branch.BranchName;
                existing.BranchLocation = branch.BranchLocation;
            }
        }

        public void Remove(Guid id)
        {
            var branch = branches.FirstOrDefault(b => b.BranchId == id);

            if (branch != null)
            {
                branches.Remove(branch);
            }
        }
    }
}

