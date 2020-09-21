using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PScnFin.Models
{
    public class DataViewModel
    {
        public int data_id { get; set; }
        public int positive_scan { get; set; }
        public int negative_scan { get; set; }
        public string ip { get; set; }
        public string pc_name { get; set; }
        public string process_name { get; set; }
        public string scan_id { get; set; }
        public float time { get; set; }
        public float usage_percentage
        {
            get
            {
                return this.positive_scan * 100 / (negative_scan + positive_scan);
            }
        }
    }
}
