using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MyApp.Models;
using Microsoft.Extensions.Configuration;

namespace MyApp.Repository
{
    public class ProductRepository
    {
        //private SqlConnection con;
        ////To Handle connection related activities    
        //private void connection()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //    con = new SqlConnection(constr);

        //}

        public bool AddProduct(Product obj, string ConStr)
        {
            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand com = new SqlCommand("AddPro1", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Price", obj.Price);
            com.Parameters.AddWithValue("@Pkgd", obj.Pkgd);
            com.Parameters.AddWithValue("@Exp", obj.Exp);
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
        //private Product GPage (int currentpage,string ConStr)
        //{
        //    int maxRows = 5;
        //    Product product = new Product();
        //    product.Products = GetAllProducts()
        //        .OrderBy(x => x.ProductId)
        //        .Skip((currentPage - 1) * maxRows)
        //        .Take(maxRows).ToList();

        //    double pageCount = (double)((decimal)GetAllProducts().Count() / Convert.ToDecimal(maxRows));
        //    product.PageCount = (int)Math.Ceiling(pageCount);
        //    product.CurrentPageIndex = currentPage;

        //    return product;

        //}
        public List<Product> GetAllProducts(String ConStr)
        {
            SqlConnection Con = new SqlConnection(ConStr);
            List<Product> ProList = new List<Product>();


            SqlCommand com = new SqlCommand("GetPro1", Con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            Con.Open();
            da.Fill(dt);
            Con.Close();
            //Bind Promodel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                ProList.Add(

                    new Product
                    {

                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToInt32(dr["Price"]),
                        Pkgd = Convert.ToDateTime(dr["Pkgd"]),
                        Exp = Convert.ToDateTime(dr["Exp"]),
                        Rating = Convert.ToInt32(dr["Rating"])
                    }
                    );
            }

            return ProList;
        }


        public Product GetData(int? id, string ConStr)
        {
            Product Product = new Product();
            SqlConnection Con = new SqlConnection(ConStr);
            //connection();
            {

                SqlCommand cmd = new SqlCommand("GetById1", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);
                Con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Product.ProductId = Convert.ToInt32(sdr["ProductId"]);
                    Product.Name = Convert.ToString(sdr["Name"]);
                    Product.Price = Convert.ToInt32(sdr["Price"]);
                    Product.Pkgd = Convert.ToDateTime(sdr["Pkgd"]);
                    Product.Exp = Convert.ToDateTime(sdr["Exp"]);
                    Product.Rating = Convert.ToInt32(sdr["Rating"]);


                }
            }
            return Product;
        }

        //Update   
        public bool UpdateProduct(Product obj, string ConStr)
        {

            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand com = new SqlCommand("UpdatePro1", Con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", obj.ProductId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Price", obj.Price);
            com.Parameters.AddWithValue("@Pkgd", obj.Pkgd);
            com.Parameters.AddWithValue("@Exp", obj.Exp);
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
        public bool DeleteProduct(int Id, String ConStr)
        {

            SqlConnection Con = new SqlConnection(ConStr);

            SqlCommand com = new SqlCommand("DeletePro1", Con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", Id);

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
