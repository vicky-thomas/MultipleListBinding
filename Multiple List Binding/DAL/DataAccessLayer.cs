using Multiple_List_Binding.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Multiple_List_Binding.DAL
{
    public class DataAccessLayer
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["getconn"].ToString());
        public List<Book> GetAllBook()
        {
            
             List<Book> List = new List<Book>();


            SqlCommand com = new SqlCommand("select * from Book", con);
            //com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                List.Add(

                    new Book
                    {

                        id = Convert.ToInt32(dr["id"]),
                        BookName = Convert.ToString(dr["BookName"]),
                    });


            }

            return List;


        }
        public List<ArticleName> GetAllArticle(int id)
        {

            List<ArticleName> List1 = new List<ArticleName>();


            SqlCommand com = new SqlCommand("select * from ArticleName where id ="+id, con);
            //com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                List1.Add(

                    new ArticleName
                    {

                        id = Convert.ToInt32(dr["id"]),
                        ArticleName1 = Convert.ToString(dr["ArticleName"]),
                        Article_id= Convert.ToInt32(dr["Article_id"])
                    });


            }

            return List1;


        }
        public List<Employee> GetAllEmployee(int Article_id)
        {

            List<Employee> List2 = new List<Employee>();


            SqlCommand com = new SqlCommand("select * from EmpModel where Article_id ="+ Article_id, con);
            //com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                List2.Add(

                    new Employee
                    {

                        Article_id = Convert.ToInt32(dr["Article_id"]),
                        Empid = Convert.ToInt32(dr["Empid"]),
                        Name = Convert.ToString(dr["Name"]),
                    });


            }

            return List2;


        }

    }
}