using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using StoreManagementModels;

namespace StoreManagementDataService
{
    public class BranchDBData : IBranchDataService
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS; Initial Catalog=StoreManagementINTEG; Integrated Security=True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public BranchDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();
        }

        private void AddSeeds()
        {
            var existing = GetBranches();

            if (existing.Count == 0)
            {
                Add(new Branch { BranchId = Guid.NewGuid(), BranchName = "Main Branch", BranchLocation = "Manila" });
                Add(new Branch { BranchId = Guid.NewGuid(), BranchName = "North Branch", BranchLocation = "Quezon City" });
                Add(new Branch { BranchId = Guid.NewGuid(), BranchName = "South Branch", BranchLocation = "Makati" });
            }
        }

        public void Add(Branch branch)
        {
            var insertStatement = "INSERT INTO Branches VALUES (@BranchId, @BranchName, @BranchLocation)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@BranchId", branch.BranchId);
            insertCommand.Parameters.AddWithValue("@BranchName", branch.BranchName);
            insertCommand.Parameters.AddWithValue("@BranchLocation", branch.BranchLocation);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Branch> GetBranches()
        {
            var selectStatement = "SELECT BranchId, BranchName, BranchLocation FROM Branches";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var branches = new List<Branch>();

            while (reader.Read())
            {
                Branch branch = new Branch();
                branch.BranchId = Guid.Parse(reader["BranchId"].ToString());
                branch.BranchName = reader["BranchName"].ToString();
                branch.BranchLocation = reader["BranchLocation"].ToString();
                branches.Add(branch);
            }

            sqlConnection.Close();
            return branches;
        }

        public Branch GetById(Guid id)
        {
            var selectStatement = "SELECT BranchId, BranchName, BranchLocation FROM Branches WHERE BranchId = @BranchId";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@BranchId", id.ToString());

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var branch = new Branch();

            while (reader.Read())
            {
                branch.BranchId = Guid.Parse(reader["BranchId"].ToString());
                branch.BranchName = reader["BranchName"].ToString();
                branch.BranchLocation = reader["BranchLocation"].ToString();
            }

            sqlConnection.Close();
            return branch;
        }

        public void Update(Branch branch)
        {
            var updateStatement = "UPDATE Branches SET BranchName = @BranchName, BranchLocation = @BranchLocation WHERE BranchId = @BranchId";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@BranchName", branch.BranchName);
            updateCommand.Parameters.AddWithValue("@BranchLocation", branch.BranchLocation);
            updateCommand.Parameters.AddWithValue("@BranchId", branch.BranchId);

            sqlConnection.Open();
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Remove(Guid id)
        {
            var deleteStatement = "DELETE FROM Branches WHERE BranchId = @BranchId";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@BranchId", id.ToString());

            sqlConnection.Open();
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}