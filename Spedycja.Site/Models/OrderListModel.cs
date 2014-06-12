using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spedycja.Site.Models
{
    public class OrderListModel
    {
        public int id { get; set; }
        public string OrderName { get; set; }
        public string Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
    }
}