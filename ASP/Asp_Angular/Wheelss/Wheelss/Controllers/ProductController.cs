using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Wheelss.Models;

namespace Wheelss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProductController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                       select * FROM dbo.Product
                        WHERE Size = 'M'
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
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpGet("{name}")]
        public JsonResult GetProd(string name)
        {
            string query = @"
                       select * FROM dbo.Product
                        where Name = '" + name + @"'
                        AND Size = 'M'
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
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [Route("GetIsFavorite")]
        public JsonResult GetIsFavorite()
        {
            string query = @"
                       select * FROM dbo.Product
                        WHERE Size = 'M'
                        AND isFavorite = 'True'
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
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }


        [HttpGet("{GetSize}/{name}/{color}")]
        public JsonResult GetSize(string name, string color)
        {
            string query = @"
                       select DISTINCT * FROM dbo.Product
                        WHERE Name = '" + name + @"'
                        AND Color = '" + color + @"'
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
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

    }
}
