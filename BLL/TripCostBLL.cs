using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.BLL
{
    class TripCostBLL
    {
        public int trip_id { get; set; }
        public int diesel_cost { get; set; }
        public int toll_cost { get; set; }
        public int other_cost { get; set; }
        public int total_cost { get; set; }
    }
}
