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

        public List<CandidateDbModel> GetCandidateData()
        {
            List<CandidateDbModel> candidateDbModels = new List<CandidateDbModel>();

            SqlConnection con=new SqlConnection(myCon);
            SqlCommand cmd=new SqlCommand("ReadCadidateData", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader sdr=cmd.ExecuteReader();
            while (sdr.Read())
            {
                CandidateDbModel dbModel = new CandidateDbModel();
                dbModel.Id=Convert.ToInt32(sdr["ID"]);  
                dbModel.Name = sdr["Name"].ToString();
                dbModel.Email = sdr["Email"].ToString();
                dbModel.Address = sdr["Address"].ToString();
                candidateDbModels.Add(dbModel);
            }
            return candidateDbModels;
         }
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

        public void UpdateData(CandidateDbModel candidateDbModel,int id)
        {
            
            SqlConnection con = new SqlConnection(myCon);
            SqlCommand cmd = new SqlCommand("UpdateCandidateData", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", candidateDbModel.Name);
            cmd.Parameters.AddWithValue("@Email", candidateDbModel.Email);
            cmd.Parameters.AddWithValue("@Address", candidateDbModel.Address);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteData(int id)
        {
            SqlConnection con = new SqlConnection(myCon);
            SqlCommand cmd = new SqlCommand("DeleteCandidateData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}