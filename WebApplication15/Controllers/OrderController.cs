using Newtonsoft.Json.Linq;
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
    public class OrderController : ApiController
    { 
        [HttpPost]
        public string Post(Order or)
        {
            try
            {
              DataTable dataTable = new DataTable();
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                con1.Open();
                SqlCommand myCommand = new SqlCommand("insert into Orders output inserted.orderId values('" + or.shopId + "','" + or.agentId + "')", con1);
                myCommand.CommandType = CommandType.Text;
                int orderId = Convert.ToInt32(myCommand.ExecuteScalar());
                con1.Close();

               

              
            
                foreach (Products product in or.orderedProducts )
                {
                    Products pr = new Products();
                    pr.productId = product.productId;
                    pr.productPrice = product.productPrice;
                    pr.quantity = product.quantity;

                    string query = "insert into OrderedProduct values('" + pr.productId + "','" + orderId + "','" + pr.quantity + "','" + pr.productPrice + "')";

                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    using (var Comand = new SqlCommand(query, con))
                    using (var dataAdapter = new SqlDataAdapter(Comand))
                    {
                        Comand.CommandType = CommandType.Text;
                        dataAdapter.Fill(dataTable);
                    }
                }
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
