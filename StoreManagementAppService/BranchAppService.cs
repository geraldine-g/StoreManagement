using StoreManagementDataService;
using StoreManagementModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StoreManagementAppService
{
    public class BranchAppService
    {
       private BranchDataService service;

        public BranchAppService(IBranchDataService dataSource)
        {
            service = new BranchDataService(dataSource);
        }

    

        public void AddBranch(Branch branch)
        {
            branch.BranchId = Guid.NewGuid();

            service.Add(branch);
        }

        public List<Branch> GetBranches()
        {
            return service.GetBranches();
        }

        public void UpdateBranch(Branch branch)
        {
            service.Update(branch);
        }

        public void RemoveBranch(Guid id)
        {
            service.Remove(id);
        }

      
    }
}