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
    public class AgentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"select agentId,name,agentType,agentCnic,agentSalary,agentPhone,DOJ from dbo.Agent";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var Comand = new SqlCommand(query, con))
            using (var dataAdapter = new SqlDataAdapter(Comand))
            {
                Comand.CommandType = CommandType.Text;
                dataAdapter.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string Post(Agents a)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = "insert into dbo.Agent values('" + a.name + "','" + a.agentType + "','" + a.agentCnic + "','" + a.agentAddress + "','" + a.agentSalary + "','" + a.agentPhone + "','" + a.DOJ + "')";

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

        public string Put(Agents a)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = @"update Agent set name='" + a.name + "',agentType='" + a.agentType + "',agentCnic='" + a.agentCnic + "',agentAddress='" + a.agentAddress + "',agentSalary='" + a.agentSalary + "',agentPhone='" + a.agentPhone + "',DOJ='" + a.DOJ + "' where Agent_ID='" + a.agentId + "' ";

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
                string query = @"delete from Agent where agentId='" + id + "' ";

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
