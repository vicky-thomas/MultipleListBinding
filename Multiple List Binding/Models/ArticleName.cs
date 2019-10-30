using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiple_List_Binding.Models
{
    public class ArticleName
    {
        public int Article_id { get; set; }
        public Nullable<int> id { get; set; }
        public string ArticleName1 { get; set; }

        public List<Book> books { get; set; }
    }
}