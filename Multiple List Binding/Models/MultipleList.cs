using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiple_List_Binding.Models
{
    public class MultipleList
    {
        public int id { get; set; }
        public string BookName { get; set; }
        public List<ArticleName> Article { get; set; }

       
        public class ArticleName
        {
            public int Article_id { get; set; }
            public Nullable<int> id { get; set; }
            public string ArticleName1 { get; set; }
            public List<EmpModel> Employee { get; set; }

           
        }
         public class EmpModel
            {

                public int Empid { get; set; }
                public int Article_id { get; set;}
                public string Name { get; set; }     
                public string City { get; set; }
                public string Address { get; set; }
            }
        }
    }