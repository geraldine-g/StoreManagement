using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementModels
{
    public class Branch
    {
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }
    }
}