using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiple_List_Binding.Models
{
    public class XTreeView
    {
        public int id { get; set; }
        public int parentId { get; set; }
        public string text { get; set; }
        public string Value { get; set; }
    }
}