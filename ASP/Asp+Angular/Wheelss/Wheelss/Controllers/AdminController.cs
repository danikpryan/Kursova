using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheelss.Models;

namespace Wheelss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public AdminController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                       select * from dbo.Product";
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

        [HttpPost]
        public JsonResult Post(Product prod)
        {
            string query = @"
                       insert into dbo.Product 
                        (Name, Descrit, Price, Size, Color, Value, categoryId, img, img2, isFavorite)
                        values
                        (
                            '" + prod.Name + @"'
                            ,'" + prod.Descrit + @"'
                            ,'" + prod.Price + @"'
                            ,'" + prod.Size + @"'
                            ,'" + prod.Color + @"'
                            ,'" + prod.Value + @"'
                            ,'" + prod.categoryId + @"'
                            ,'" + prod.img + @"'
                            ,'" + prod.img2 + @"'
                            ,'" + prod.isFavorite + @"'                        )
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

        [HttpPut]
        public JsonResult Put(Product prod)
        {
            string query = @"
                    update dbo.Product set 
                    Name = '"+ prod.Name + @"'
                    ,Descrit = '" + prod.Descrit + @"'
                    ,Price = " + prod.Price + @"
                    ,Size = '" + prod.Size + @"'
                    ,Color = '" + prod.Color + @"'
                    ,img = '" + prod.img + @"'
                    ,img2 = '" + prod.img2 + @"'
                    ,categoryId = " + prod.categoryId + @"
                    ,Value = " + prod.Value + @"
                    ,isFavorite = '" + prod.isFavorite + @"'  
                    where ProductId = " + prod.ProductId + @"
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

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from dbo.Product
                        where ProductId = " + id + @"
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

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllCategories")]
        public JsonResult GetAllCategories()
        {
            string query = @"
                    select CategoryId, CategoryName from dbo.Category
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

            return new JsonResult(table);
        }

        [HttpGet("{categoryId}")]
        public JsonResult GetByCategory(int categoryId)
        {
            string query = @"
                       select * FROM dbo.Product
                        where categoryId = '" + categoryId + @"'
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

