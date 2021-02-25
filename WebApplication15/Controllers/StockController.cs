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

namespace WebApplication15.Controllers
{
    public class StockController : ApiController
    {
        private int productPrice = 0;

        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT Stock.stockId, Products.name, Stock.productQuantity, Warehouse.name,Stock.stockPrice
            FROM Stock
            INNER JOIN Products ON Stock.productId=Products.productId
            INNER JOIN Warehouse ON Stock.warehouseId=Warehouse.warehouseId;";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var Comand = new SqlCommand(query, con))
            using (var dataAdapter = new SqlDataAdapter(Comand))
            {
                Comand.CommandType = CommandType.Text;
                dataAdapter.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }
        public HttpResponseMessage Get(int id)
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT Stock.stockId, Products.name, Stock.productQuantity, Warehouse.name,Stock.stockPrice
            FROM Stock
            INNER JOIN Products ON Stock.productId=Products.productId
            INNER JOIN Warehouse ON Stock.warehouseId=Warehouse.warehouseId
             where stockId='"+ id +"'";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var Comand = new SqlCommand(query, con))
            using (var dataAdapter = new SqlDataAdapter(Comand))
            {
                Comand.CommandType = CommandType.Text;
                dataAdapter.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string Post(Stock st)
        {
            try
            {
                DataTable dataTable = new DataTable();
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                con1.Open();
                SqlCommand myCommand = new SqlCommand("SELECT productPrice FROM Products WHERE (productId='" + st.productId + "')", con1);

                SqlDataReader rdr = myCommand.ExecuteReader();

                while (rdr.Read())
                {
                    productPrice = Convert.ToInt32(rdr["productPrice"]);
                }
             
                con1.Close();
                string query = "insert into Stock values('" + st.productId + "','" + st.productQuantity + "','" + st.warehouseId + "','" + st.productQuantity*productPrice+ "')";

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

        public string Put(Stock st)
        {
            try
            {
                productPrice = 0;
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                con1.Open();
                SqlCommand myCommand = new SqlCommand("SELECT productPrice FROM Products WHERE (productId='" + st.productId + "')", con1);

                SqlDataReader rdr = myCommand.ExecuteReader();

                while (rdr.Read())
                {
                    productPrice = Convert.ToInt32(rdr["product_Price"]);
                }

                con1.Close();
                DataTable dataTable = new DataTable();
                string query = @"update Stock set productId='" + st.productId + "',productQuantity='" + st.productQuantity + "',warehouseId='" + st.warehouseId + "',stockPrice='" + st.productQuantity * productPrice + "' where stockId='" + st.stockId + "' ";

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
                string query = @"delete from Stock where stockId='" + id + "' ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var Comand = new SqlCommand(query, con))
                using (var dataAdapter = new SqlDataAdapter(Comand))
                {
                    Comand.CommandType = CommandType.Text;
                    dataAdapter.Fill(dataTable);
                }
                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Some Error Occured";
            }
        }


    }
}
