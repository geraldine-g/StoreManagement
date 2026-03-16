using System;
using System.Collections.Generic;
using System.Text;
using StoreManagementModels;

namespace StoreManagementDataService
{
    public interface IBranchDataService
    {
        void Add(Branch branch);
        List<Branch> GetBranches();
        Branch GetById(int id);
        void Update(Branch branch);
        void Remove(int id);
    }
}