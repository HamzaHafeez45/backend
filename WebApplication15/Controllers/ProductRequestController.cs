using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication15.Models;


namespace WebApplication15.Models
{
    public class ProductRequestController : ApiController
    {
        private int productPrice;

        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT ProductRequest.productRequestId, Products.name ,Products.productCode, ProductBrand.name,Categories.name,ProductRequest.requestedQuantity,ProductRequest.requestedPrice
            FROM ProductRequest
            INNER JOIN Products ON ProductRequest.productId=Products.productId
            INNER JOIN ProductBrand ON ProductRequest.brandId=ProductBrand.brandId
            INNER JOIN Categories ON ProductRequest.categoryId=Categories.categoryId;";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var Comand = new SqlCommand(query, con))
            using (var dataAdapter = new SqlDataAdapter(Comand))
            {
                Comand.CommandType = CommandType.Text;
                dataAdapter.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string Post(ProductRequest pr)
        {
            try
            {
                productPrice = 0;
                DataTable dataTable = new DataTable();
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                con1.Open();
                SqlCommand myCommand = new SqlCommand("SELECT productPrice FROM Products WHERE (productId='" + pr.productId + "')", con1);

                SqlDataReader rdr = myCommand.ExecuteReader();

                while (rdr.Read())
                {
                    productPrice = Convert.ToInt32(rdr["productPrice"]);
                }

                con1.Close();
                string query = "insert into ProductRequest values('" + pr.productId + "','" + pr.brandId + "','" + pr.categoryId + "','"+pr.requestedQuantity+"','" + pr.requestedQuantity * productPrice + "')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var Comand = new SqlCommand(query, con))
                using (var dataAdapter = new SqlDataAdapter(Comand))
                {
                    Comand.CommandType = CommandType.Text;
                    dataAdapter.Fill(dataTable);
                }
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Put(ProductRequest pr)
        {
            try
            {
                productPrice = 0;
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                con1.Open();
                SqlCommand myCommand = new SqlCommand("SELECT productPrice FROM Products WHERE (productId='" + pr.productId + "')", con1);

                SqlDataReader rdr = myCommand.ExecuteReader();

                while (rdr.Read())
                {
                    productPrice = Convert.ToInt32(rdr["productPrice"]);
                }

                con1.Close();
                DataTable dataTable = new DataTable();
                string query = @"update ProductRequest set productId='" + pr.productId + "',brandId='" + pr.brandId + "',categoryId='" + pr.categoryId + "',requestedQuantity='" + pr.requestedQuantity + "',requestedPrice='"+ pr.requestedQuantity*productPrice + "' where productRequestId='" + pr.productRequestId + "' ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var Comand = new SqlCommand(query, con))
                using (var dataAdapter = new SqlDataAdapter(Comand))
                {
                    Comand.CommandType = CommandType.Text;
                    dataAdapter.Fill(dataTable);
                }
                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Delete(int id)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = @"delete from ProductRequest where productRequestId='" + id + "' ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var Comand = new SqlCommand(query, con))
                using (var dataAdapter = new SqlDataAdapter(Comand))
                {
                    Comand.CommandType = CommandType.Text;
                    dataAdapter.Fill(dataTable);
                }
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
