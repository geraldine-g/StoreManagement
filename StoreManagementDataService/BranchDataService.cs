using StoreManagementModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace StoreManagementDataService
{
    public class BranchDataService
    {
        private IBranchDataService _dataSource;

        
        public BranchDataService(IBranchDataService dataSource)
        {
            _dataSource = dataSource;
        }

        public void Add(Branch branch)
        {
            _dataSource.Add(branch);
        }

        public List<Branch> GetBranches()
        {
            return _dataSource.GetBranches();
        }

        public Branch GetById(Guid id)
        {
            return _dataSource.GetById(id);
        }

        public void Update(Branch branch)
        {
            _dataSource.Update(branch);
        }

        public void Remove(Guid id)
        {
            _dataSource.Remove(id);
        }
    }
}