using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.BLL
{
    class TripEntryBLL
    {
        public int id { get; set; }
        public String driver_id { get; set; }
        public String truck_no { get; set; }
        public DateTime starting_date { get; set; }
        public String starting_place { get; set; }
        public DateTime ending_date { get; set; }
        public String ending_place { get; set; }
        public String goods_details { get; set; }
        public int weight { get; set; }
        public String status { get; set; }
        public int cost { get; set; }
    }
}
