using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiple_List_Binding.Models
{
    public class Employee
    {
        public int Empid { get; set; }
        public int id { get; set; }
        public int Article_id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }


        public List<Book> Book { get; set; }
    }
}