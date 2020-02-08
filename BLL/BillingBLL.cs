using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.BLL
{
    class BillingBLL
    {
        public int bill_no { get; set; }
        public int buyer_reg_no { get; set; }
        public String buyer_name { get; set; }
        public String buyer_contact { get; set; }
        public String buyer_address { get; set; }
        public int seller_reg_no { get; set; }
        public String seller_name { get; set; }
        public String seller_contact { get; set; }
        public String seller_address { get; set; }
        public String goods_details { get; set; }
        public int weight { get; set; }
        public int cost { get; set; }
    }
}
