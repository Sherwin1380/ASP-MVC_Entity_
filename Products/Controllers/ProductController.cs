using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Products.Models;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(ConnecttoDB.ConnectDb()))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert into Product (name, price,supplier) values (@name,@price,@supplier);", con))
                    {
                        if (con.State != System.Data.ConnectionState.Open)
                            con.Open();

                        cmd.Parameters.AddWithValue("@name", product.name);
                        cmd.Parameters.AddWithValue("@price", product.price);
                        cmd.Parameters.AddWithValue("@supplier", product.supplier);
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("GetAll");
            }
                return View("Create",product);
            }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<Product> prod = new List<Product>();

            using (SqlConnection con = new SqlConnection(ConnecttoDB.ConnectDb()))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(sdr);

                    foreach (DataRow row in dt.Rows)
                    {
                        prod.Add(
                            new Product
                            {
                                id = Convert.ToInt32(row["id"]),
                                name = Convert.ToString(row["name"]),
                                price = Convert.ToDecimal(row["price"]),
                                supplier = Convert.ToString(row["supplier"])
                            });
                    }

                }
            }
            return View(prod);
        }

        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnecttoDB.ConnectDb()))
            {
                using (SqlCommand cmd = new SqlCommand("delete from product where id = @id", con))
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                }
            }
            return RedirectToAction("GetAll", "Product");
        }

        public ActionResult Search(string search)
        {
            List<Product> prod = new List<Product>();
            using (SqlConnection con = new SqlConnection(ConnecttoDB.ConnectDb()))
            {
                using (SqlCommand cmd = new SqlCommand("select * from product where name = @name", con))
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.Parameters.AddWithValue("@name", search);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(sdr);

                    foreach (DataRow row in dt.Rows)
                    {
                        prod.Add(
                             new Product
                             {
                                 id = Convert.ToInt32(row["id"]),
                                 name = Convert.ToString(row["name"]),
                                 price = Convert.ToDecimal(row["price"]),
                                 supplier = Convert.ToString(row["supplier"])
                             });
                    }

                   
                }
            }
            return View("GetAll",prod);
        }
    }
}