using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public TestController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }




        [HttpGet("{id}")]
        public JsonResult GetOrderProd(int id)
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

        /*[HttpPut]
        public JsonResult ChangeValue(ArrayList arrayList)

        {
            int tmp;
            string qur1 = @"
                    select Value from dbo.Product 
                    where ProductId = "+ arrayList[0] +@"
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WheelsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(qur1, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;
                    
                    myReader.Close();
                    myCon.Close();
                }
            }
            tmp = int.Parse(qur1);

            int sum = tmp - Int32.Parse(arrayList[1].ToString()); 

            string query = @"
                    update dbo.Product set 
                    Value = '" +  arrayList[1] + @"'  
                    where Id = " + arrayList[0] + @"
                    ";
             table = new DataTable();
            string sqlDataSource1 = _configuration.GetConnectionString("WheelsAppCon");
            SqlDataReader myReader1;
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
        }*/

    }
}
