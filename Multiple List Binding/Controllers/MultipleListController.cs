using Multiple_List_Binding.DAL;
using Multiple_List_Binding.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static Multiple_List_Binding.Models.MultipleList;

namespace Multiple_List_Binding.Controllers
{
    public class MultipleListController : Controller
    {
        #region
        // GET: MultipleList
        public ActionResult Default()
        {
            return View();
        }
        #endregion
        public ActionResult CompleteDetailsView()
        {
            return View();
        }
        public ActionResult BookDetails()
        {
            DataLayer obj = new DataLayer();
            var list = obj.GetAllBookDetails();
            
           // return View(list);

             return Json(list, JsonRequestBehavior.AllowGet);
        }
        #region MultipleList access
        public ActionResult CompleteDetails()
        {
            DataLayer obj = new DataLayer();
            var list = obj.GetAllBookDetails();
            //return View(list);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CompleteDetailsArticle(int id)
        {
            DataLayer obj = new DataLayer();
            var list = obj.GetAllBookDetails();
            var ArticleList = list.Where(d => d.id == id).ToList();
            return Json(ArticleList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CompleteDetailsBook(int id)
        {
            DataLayer obj = new DataLayer();
           var list = obj.GetAllBookDetails();
           var article= list.Select(x => x.Article.Select(y => y.Article_id == id));
           return Json(article, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region default view page
        public JsonResult Book()
        {
            DataAccessLayer data = new DataAccessLayer();
            var list = data.GetAllBook();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Article(int id)
        {
            DataAccessLayer data = new DataAccessLayer();
            var list = data.GetAllArticle(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Employee(int Article_id)
        {
            DataAccessLayer data = new DataAccessLayer();
            var list = data.GetAllEmployee(Article_id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
# endregion 


        #region Jtree property
        //public ActionResult Tree()
        //{
        //    DataAccessLayer obj = new DataAccessLayer();
        //    var list = obj.GetAllBook();
        //    var list1 = obj.GetAllArticle(id);
        //    var list2 = obj.GetAllEmployee();
        //    List<TreeViewNode> nodes = new List<TreeViewNode>();

        //    //Loop and add the Parent Nodes.
        //    foreach (Book type in list)
        //    {
        //        nodes.Add(new TreeViewNode { id = type.id.ToString(), parent = "#", text = type.BookName });
        //    }

        //    //Loop and add the Child Nodes.
        //    foreach (Models.ArticleName subType in list1)
        //    {
        //        nodes.Add(new TreeViewNode { id = subType.id.ToString() + "-" + subType.Article_id.ToString(), parent = subType.id.ToString(), text = subType.ArticleName1 });
        //    }

        //    //Loop and add the Child Nodes.
        //    foreach (Models.Employee subType in list2)
        //    {
        //        nodes.Add(new TreeViewNode { id = subType.Article_id.ToString() + "-" + subType.Empid.ToString(), parent = subType.id.ToString(), text = subType.Name });
        //    }

        //    //Serialize to JSON string.
        //    ViewBag.Json = (new JavaScriptSerializer()).Serialize(nodes);
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index(string selectedItems)
        //{
        //    List<TreeViewNode> items = (new JavaScriptSerializer()).Deserialize<List<TreeViewNode>>(selectedItems);
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public ActionResult JsTreeDemo()
        //{
        //    return View();
        //}
        #endregion
    }
}