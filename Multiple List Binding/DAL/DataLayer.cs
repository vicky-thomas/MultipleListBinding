using Multiple_List_Binding.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static Multiple_List_Binding.Models.MultipleList;
using ArticleName = Multiple_List_Binding.Models.MultipleList.ArticleName;

namespace Multiple_List_Binding.DAL
{
    public class DataLayer
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["getconn"].ToString());


        public List<MultipleList> GetAllBookDetails()
        {
            #region Joins
            List<MultipleList> M_List = new List<MultipleList>();
            SqlCommand com = new SqlCommand("SELECT B.id,E.Name,b.BookName, A.ArticleName, A.Article_id, E.Address FROM Book B INNER JOIN ArticleName A on A.id=B.id INNER JOIN EmpModel E on E.Article_id = A.Article_id", con);
            //com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt2 = new DataTable();

            con.Open();
            da.Fill(dt2);
            con.Close();
            foreach (DataRow dr in dt2.Rows)
            {
                List<EmpModel> E_list = new List<EmpModel>();
                E_list.Add(
                    new EmpModel
                    {
                        Name = Convert.ToString(dr["Name"]),
                        Address = Convert.ToString(dr["Address"]),
                    });
                List<ArticleName> A_list = new List<ArticleName>
                {
                    new ArticleName
                    {
                        ArticleName1 = Convert.ToString(dr["ArticleName"]),
                         Article_id = Convert.ToInt32(dr["Article_id"]),
                        Employee = E_list
                    }
                };
                M_List.Add(
                    new MultipleList
                    {
                        BookName = Convert.ToString(dr["BookName"]),
                        id = Convert.ToInt32(dr["id"]),
                        Article = A_list
                    });
            }
            return M_List;
            #endregion



               #region All Details
            //    List<EmpModel> Emplist = new List<EmpModel>();
            //    SqlCommand com2 = new SqlCommand("select E.id,E.Name,E.city,E.Article_id from EmpModel E inner join  ArticleName A on A.Article_id=E.Article_id", con);
            //    //com.CommandType = CommandType.StoredProcedure;
            //    SqlDataAdapter da2 = new SqlDataAdapter(com2);
            //    DataTable dt2 = new DataTable();

            //    con.Open();
            //    da2.Fill(dt2);
            //    con.Close();
            //    foreach (DataRow dr in dt2.Rows)
            //    {
            //        Emplist.Add(

            //            new EmpModel

            //            {

            //                Empid = Convert.ToInt32(dr["id"]),
            //                Name = Convert.ToString(dr["Name"]),
            //                City = Convert.ToString(dr["city"]),
            //                Article_id = Convert.ToInt32(dr["Article_id"])
            //            });
            //    }

            //    List<ArticleName> Artlist = new List<ArticleName>();
            //    SqlCommand com1 = new SqlCommand("select A.Article_id,A.ArticleName from ArticleName A inner join EmpModel E on A.Article_id=E.Article_id ", con);
            //    //com.CommandType = CommandType.StoredProcedure;
            //    SqlDataAdapter da1 = new SqlDataAdapter(com1);
            //    DataTable dt1 = new DataTable();

            //    con.Open();
            //    da1.Fill(dt1);
            //    con.Close();
            //    foreach (DataRow dr in dt1.Rows)
            //    {
            //        Artlist.Add(
            //            new ArticleName
            //            {

            //                Article_id = Convert.ToInt32(dr["Article_id"]),
            //                ArticleName1 = Convert.ToString(dr["ArticleName"]),

            //                Employee = Emplist
            //            });
            //    }
            //    List<MultipleList> list = new List<MultipleList>();
            //    SqlCommand com = new SqlCommand("select B.id,B.BookName from Book B inner join ArticleName A on A.id=B.id", con);
            //    SqlDataAdapter da = new SqlDataAdapter(com);
            //    DataTable dt = new DataTable();

            //    con.Open();
            //    da.Fill(dt);
            //    con.Close();
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        list.Add(
            //            new MultipleList
            //            {

            //                id = Convert.ToInt32(dr["id"]),
            //                BookName = Convert.ToString(dr["BookName"]),
            //                Article = Artlist
            //            });

            //    }
            //    return list;
            //}
            #endregion


        }
    }
}