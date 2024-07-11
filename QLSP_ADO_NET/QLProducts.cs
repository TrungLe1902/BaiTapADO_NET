using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_ADO_NET
{
    public class QLProducts
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string CPU { get; set; }
        public string ScreenSize { get; set; }
        public string RAM { get; set; }
        public int Price { get; set; }
    }

    public class QLCategory
    {
        public string CategoryName { get; set; }
    }
}
