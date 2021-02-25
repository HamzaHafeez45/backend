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
        [HttpGet]
        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT orderId, Shop.name as Shop,Agent.name as Agent,totalAmount,totalProfit
             FROM Orders
             INNER JOIN Shop ON Orders.shopId=Shop.shopId
             INNER JOIN Agent ON Orders.agentId=Agent.agentId;";
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
            string query = @"SELECT Order.orderId, shop.name, Agent.name,totalAmount,totalProfit
            FROM Orders
            INNER JOIN shop ON Order.shopId=shop.shopId
            INNER JOIN Agent ON Order.agentId=Agent.agentId;
            where orderId='"+ id +"'";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var Comand = new SqlCommand(query, con))
            using (var dataAdapter = new SqlDataAdapter(Comand))
            {
                Comand.CommandType = CommandType.Text;
                dataAdapter.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }
        [HttpPost]
        public string Post(Order or)
        {
            try
            {
              DataTable dataTable = new DataTable();
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                con1.Open();
                SqlCommand myCommand = new SqlCommand("insert into Orders output inserted.orderId values('" + or.shopId + "','" + or.agentId + "','" + or.totalAmount + "','" + or.totalProfit + "')", con1);
                myCommand.CommandType = CommandType.Text;
                int orderId = Convert.ToInt32(myCommand.ExecuteScalar());
                con1.Close();

            
                foreach (Products product in or.orderedProducts )
                {
                    string query = "insert into OrderedProduct values('" + product.productId + "','" + orderId + "','" + product.quantity + "','" + product.productPrice + "')";

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
            catch (Exception)
            {
                return "Some Error Occured";
            }
        }
    }
}
