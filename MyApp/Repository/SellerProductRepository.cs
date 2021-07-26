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
    public class SellerProductRepository
    {
        //private SqlConnection con;
        ////To Handle connection related activities    
        //private void connection()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["gettconsdbContext"].ToString();
        //    con = new SqlConnection(constr);

        //}

        public List<ViewModel> SellersProduct(int SellerId, String ConStr)
        {
            SqlConnection Con = new SqlConnection(ConStr);
            List<ViewModel> SellersProduct = new List<ViewModel>();


            SqlCommand com = new SqlCommand("SellProduct", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", SellerId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            Con.Open();
            da.Fill(dt);
            Con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                SellersProduct.Add(

                    new ViewModel
                    {
                        SellerProductId = Convert.ToInt32(dr["SellerProductId"]),
                        SellerId = Convert.ToInt32(dr["SellerId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToInt32(dr["Price"]),
                        
                        Rating = Convert.ToInt32(dr["Rating"])

                    }
                    );
            }

            return SellersProduct;
        }

        public bool DeleteSellerProduct(int SellerProductId, String ConStr)
        {

            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand com = new SqlCommand("DelProductFromSeller", Con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerProductId", SellerProductId);

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

        public bool AddSellersproduct(SellerProduct obj, String ConStr)
        {

            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand com = new SqlCommand("AddSellerPro", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", obj.SellerId);
            com.Parameters.AddWithValue("@ProductId", obj.ProductId);


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
    }
}
