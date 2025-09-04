using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudProjectOne.Models
{
    public class CandidateDbContext
    {
       static string myCon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public void AddCandidate(CandidateDbModel model)
        {
            SqlConnection con=new SqlConnection(myCon);
            SqlCommand cmd = new SqlCommand("InsertDataInCandidate",con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name",model.Name);
            cmd.Parameters.AddWithValue("@Email",model.Email);
            cmd.Parameters.AddWithValue("@Address",model.Address);
            con.Open();
            cmd.ExecuteNonQuery();
          
        }

    }
}