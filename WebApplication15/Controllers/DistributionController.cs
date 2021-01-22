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
    public class DistributionController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"select Distribution.distributionId,Distribution.name,Categories.name,City.name,Distribution.distributorName,Distribution.distributorEmail,Distribution.distributorCnic,Distribution.distributorPhone from Distribution
            INNER JOIN Categories ON Distribution.categoryId = Categories.categoryId
            INNER JOIN City ON Distribution.cityId = City.cityId";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var Comand = new SqlCommand(query, con))
            using (var dataAdapter = new SqlDataAdapter(Comand))
            {
                Comand.CommandType = CommandType.Text;
                dataAdapter.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string Post(Distributions d)
        {
            try
            {
                DataTable dataTable = new DataTable();

                string query = @"INSERT INTO dbo.Distribution VALUES('" + d.name + "','" + d.categoryId + "','" + d.distributorName + "','" + d.distributorEmail + "','" + d.distributorCnic + "','" + d.distributorPhone + "','" + d.cityId + "')";

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

        public string Put(Distributions d)
        {
            
            try
            {
                DataTable dataTable = new DataTable();
                string query = @"update Distribution set name='" + d.name+ "',categoryId='" + d.categoryId + "',cityId='" + d.cityId + "',distributorName='" + d.distributorName + "',distributorEmail='" + d.distributorEmail + "',distributorCnic='" + d.distributorCnic + "',distributorPhone='" + d.distributorPhone + "' where distributionId='" + d.distributionId + "' ";

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
                string query = @"delete from Distribution where distributionId='" + id + "' ";

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
