using System;
using System.Collections.Generic;
using System.Text;
using StoreManagementModels;

namespace StoreManagementDataService
{
    public class BranchDataService : IBranchDataService
    {
        private BranchDBData db;

        public BranchDataService(BranchDBData dbData)
        {
            db = dbData;
        }

        public void Add(Branch branch)
        {
            db.branches.Add(branch);
        }

        public List<Branch> GetBranches()
        {
            return db.branches;
        }

        public Branch GetById(int id)
        {
            return db.branches.FirstOrDefault(b => b.BranchId == id);
        }

        public void Update(Branch branch)
        {
            var existing = GetById(branch.BranchId);

            if (existing != null)
            {
                existing.BranchName = branch.BranchName;
                existing.BranchLocation = branch.BranchLocation;
            }
        }

        public void Remove(int id)
        {
            var branch = GetById(id);

            if (branch != null)
                db.branches.Remove(branch);
        }
    }
}