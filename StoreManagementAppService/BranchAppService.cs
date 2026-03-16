using System;
using System.Collections.Generic;
using System.Text;
using StoreManagementModels;
using StoreManagementDataService;

namespace StoreManagementAppService
{
    public class BranchAppService
    {
        BranchDataService branchDataService =
            new BranchDataService(new BranchDBData());

        public void AddBranch(Branch branch)
        {
            branchDataService.Add(branch);
        }

        public List<Branch> GetBranches()
        {
            return branchDataService.GetBranches();
        }

        public void UpdateBranch(Branch branch)
        {
            branchDataService.Update(branch);
        }

        public void RemoveBranch(int id)
        {
            branchDataService.Remove(id);
        }

        public Branch GetBranch(int id)
        {
            return branchDataService.GetById(id);
        }
    }
}