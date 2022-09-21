using RegistrationUsingMVC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationUsingMVC.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationDB"].ConnectionString);


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string User_Name, string User_Email, string User_Contact)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SP_EmailV", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@UserEmail", User_Email);
            int count = Convert.ToInt32(cmd1.ExecuteScalar());
            if (count > 0)
            {
                ViewBag.Message = "Invalid Email ID..!";

            }
            else
            {
                SqlCommand cmd = new SqlCommand("SP_Register", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", User_Name);
                cmd.Parameters.AddWithValue("@UserEmail", User_Email);
                cmd.Parameters.AddWithValue("@UserContact", User_Contact);
                cmd.ExecuteNonQuery();
               
                ViewBag.Message = "Registration Form Has Been Saved Successfully";
                ModelState.Clear();
            }
            con.Close();
            return View();
        }
    }
}