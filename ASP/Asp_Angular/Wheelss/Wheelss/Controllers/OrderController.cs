using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Wheelss.Models;
using Newtonsoft.Json;

namespace Wheelss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public OrderController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpPost("{id}")]
        public JsonResult Post(Order order, string id)//per Guid to string
        {
            string query = @"
                       insert into dbo.Orderr 
                        (Id, Name, Adress, City,  Zip, Phone, Shipped)
                        values
                        (
                            '" + id + @"'
                            ,'" + order.Name + @"'
                            ,'" + order.Address + @"'
                            ,'" + order.City + @"'
                            ,'" + order.Zip + @"'
                            ,'" + order.Phone + @"'
                            ,'" + order.Shipped + @"'
                        )
                        ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WheelsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }                
            return new JsonResult("Added Succesfully");
        }

        [HttpPost("{second}/{id}")]
        public JsonResult AddOrderP(ArrayList arrayList, string id)//bylo Guid
        {
                string query2 = @"
                        insert into dbo.OrderDetail 
                            (OrderId, ProductId, price)
                            values
                            (
                                '" + id +@"'
                                ,'" + arrayList[0] + @"'  
                                ,'" + arrayList[1] + @"'
                            )
                            ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("WheelsAppCon");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query2, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader); ;

                        myReader.Close();
                        myCon.Close();
                    }
                }

            return new JsonResult("Added Succesfully");


        }

        [HttpPut]
        public JsonResult Put(Order order)
        {
            string query = @"
                    update dbo.Orderr set 
                    Shipped = '"+ true + @"'  
                    where Id = '" + order.Id + @"'
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WheelsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from dbo.Orderr
                        where Id = " + id + @"
                        ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WheelsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Delete Succesfully");
        }
         
        [HttpGet]
        public JsonResult GetShipped(bool shpd)
        {
            string query = @"
                       select * 
                       from dbo.Orderr
                       WHERE Shipped = '" + shpd + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WheelsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult GetDetails(string id)
        {
            string query = @"
                       select ProductId, price from dbo.OrderDetail
                       WHERE OrderId = '" + id + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WheelsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }     

        [HttpGet("{GetOrderProd}/{categoryIds}")]
        public JsonResult GetOrderProd(object id)
         {
            DataTable table = new DataTable();
                string query = @"
                       select * from dbo.Product
                       WHERE ProductId = " + id + @"";
                
                string sqlDataSource = _configuration.GetConnectionString("WheelsAppCon");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader); ;

                        myReader.Close();
                        myCon.Close();
                    }
                }
            return new JsonResult(table);
        }

    }

 }

