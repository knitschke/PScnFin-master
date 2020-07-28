using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PScnFin.Models;
namespace PScnFin
{
    public class DataModel
    {
        public int data_id { get; set; }
        public int positive_scan { get; set; }
        public int negative_scan { get; set; }
        public string ip { get; set; }
        public string pc_name
        {
            get
            {
                List<UsersModel> um;
                um = SqliteDataAccess.LoadUserName(ip);
                if (um.Count > 0)
                    return um.Last().pc_name;
                else return "";
            }
        }
        public string process_name { get; set; }
        public int scan_id { get; set; }
        public float scan_time
        {
            get
            {
                List<ScansModel> sm;//= new List<ScansModel>();
                sm = SqliteDataAccess.LoadScan(scan_id);
                if (sm.Count > 0)
                    return sm[0].time;
                else return -1;

            }
        
        }
        public double usage_percentage
        {
            get 
            {
                if (negative_scan + positive_scan == 0)
                    return -1;
                else return (positive_scan * 100 / (negative_scan + positive_scan));
            }
        }

    }
}
