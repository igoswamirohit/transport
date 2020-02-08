using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.BLL
{
    class InsuranceBLL
    {
        public int id { get; set; }
        public String truck_model { get; set; }
        public String truck_no { get; set; }
        public String company_name { get; set; }
        public int amount { get; set; }
        public DateTime expiry_date { get; set; }
    }
}
