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
    public class ShopController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT Shop.shopId, Shop.name,Shop.shopCnic,Shop.shopPhone , City.name, Area.name
             FROM Shop
             INNER JOIN City ON Shop.cityId=City.cityId
             INNER JOIN Area ON Shop.areaId=Area.areaId;";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var Comand = new SqlCommand(query, con))
            using (var dataAdapter = new SqlDataAdapter(Comand))
            {
                Comand.CommandType = CommandType.Text;
                dataAdapter.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }
        public string Post(shop s)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = "insert into Shop values('" + s.name + "','" + s.shopCnic + "','" + s.shopPhone + "','" + s.cityId + "','" + s.areaId + "')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var Comand = new SqlCommand(query, con))
                using (var dataAdapter = new SqlDataAdapter(Comand))
                {
                    Comand.CommandType = CommandType.Text;
                    dataAdapter.Fill(dataTable);
                }
                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Some error occured";
            }
        }

        public string Put(shop s)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = @"update Shop set name='" + s.name + "',shopCnic='" + s.shopCnic + "',shopPhone='" + s.shopPhone + "',cityId='" + s.cityId + "',areaId='" + s.areaId + "' where shopId='" + s.shopId + "' ";

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
                string query = @"delete from Shop where shopId='" + id + "' ";

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
