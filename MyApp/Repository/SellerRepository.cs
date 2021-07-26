using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class SellerRepository
    {
        //private SqlConnection con;
        ////To Handle connection related activities    
        //private void connection()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["gettconsdbContext"].ToString();
        //    con = new SqlConnection(constr);

        //}

        public bool AddSeller(Seller obj, String ConStr)
        {

            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand com = new SqlCommand("AddSel1", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@MobileNumber", obj.MobileNumber);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@Rating", obj.Rating);

            Con.Open();
            int i = com.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        public List<Seller> GetAllSellers(String ConStr)
        {
            SqlConnection Con = new SqlConnection(ConStr);
            List<Seller> SelList = new List<Seller>();


            SqlCommand com = new SqlCommand("GetSeller1", Con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            Con.Open();
            da.Fill(dt);
            Con.Close();
            //Bind Promodel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                SelList.Add(

                    new Seller
                    {

                        SellerId = Convert.ToInt32(dr["SellerId"]),
                        Name = Convert.ToString(dr["Name"]),
                        MobileNumber = Convert.ToString(dr["MobileNumber"]),
                        Address = Convert.ToString(dr["Address"]),
                        Rating = Convert.ToInt32(dr["Rating"])






                    }
                    );
            }

            return SelList;
        }


        public Seller GetData(int? id, string ConStr)
        {
            Seller Seller = new Seller();

            SqlConnection Con = new SqlConnection(ConStr);
            {

                SqlCommand cmd = new SqlCommand("GetById11", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SellerId", id);
                Con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Seller.SellerId = Convert.ToInt32(sdr["SellerId"]);
                    Seller.Name = Convert.ToString(sdr["Name"]);
                    Seller.MobileNumber = Convert.ToString(sdr["MobileNumber"]);
                    Seller.Address = Convert.ToString(sdr["Address"]);
                    Seller.Rating = Convert.ToInt32(sdr["Rating"]);


                }
            }
            return Seller;
        }

        //Update   
        public bool UpdateSeller(Seller obj, string ConStr)
        {

            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand com = new SqlCommand("UpdateSel1", Con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", obj.SellerId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@MobileNumber", obj.MobileNumber);
            com.Parameters.AddWithValue("@Address", obj.Address);

            com.Parameters.AddWithValue("@Rating", obj.Rating);
            Con.Open();
            int i = com.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete    
        public bool DeleteSeller(int Id, String ConStr)
        {

            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand com = new SqlCommand("DeleteSel1", Con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", Id);

            Con.Open();
            int i = com.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public List<ViewModel> Map(int? id, String ConStr)
        {
            SqlConnection Con = new SqlConnection(ConStr);
            List<ViewModel> Map = new List<ViewModel>();


            SqlCommand com = new SqlCommand("GetProductsSeller", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            Con.Open();
            da.Fill(dt);
            Con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                Map.Add(

                    new ViewModel
                    {

                        SellerProductId = Convert.ToInt32(dr["SellerProductId"]),

                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToInt32(dr["Price"]),
                        Pkgd = Convert.ToDateTime(dr["Pkgd"]),
                        Exp = Convert.ToDateTime(dr["Exp"]),
                        Rating = Convert.ToInt32(dr["Rating"])

                    }
                    );
            }

            return Map;
        }
    }
}
