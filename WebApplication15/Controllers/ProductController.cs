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
    public class ProductController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT Products.productId, Products.name ,Products.productCode, Products.productPrice, Products.expireable , ProductBrand.name,Categories.name
            FROM Products
            INNER JOIN ProductBrand ON Products.brandId=ProductBrand.brandId
            INNER JOIN Categories ON Products.categoryId=Categories.categoryId;";

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
        public string Post(Products p)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = "insert into Products values('" + p.name + "','" + p.productCode + "','" + p.productPrice + "','" + p.expireable + "','" + p.brandId + "','" + p.categoryId + "')";

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
        public string Put(Products p)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = @"update Products set name='" + p.name + "',productCode='" + p.productCode+ "',productPrice='" + p.productPrice + "',expireable='" + p.expireable + "',brandId='" + p.brandId + "',categoryId='" + p.categoryId + "' where Product_ID='" + p.productId + "' ";

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
                string query = @"delete from Products where productId='" + id + "' ";

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
