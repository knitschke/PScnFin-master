using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace PScnFin.Models
{
    public class SqliteDataAccess
    {

        public static List<String> LoadNameFromIP(string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))//testit+scantime add
            {
                var output = cnn.Query<String>($"select pc_name from Users where ip = '{ip}'", new DynamicParameters());
                return output.ToList();
            }
        }
        //
        public static void CreateViewData()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute("CREATE view DataView as SELECT d.data_id, d.positive_scan, d.negative_scan, d.ip, u.pc_name, " +
                                        "d.process_name, d.scan_id, s.time, ((d.positive_scan * 100) / " +
                                        "(d.positive_scan + d.negative_scan)) as usagepercentage from Data d, Users u, Scans s" +
                                        " where (d.scan_id = s.scan_id and d.ip = u.ip)");
                }
                catch (SQLiteException)
                {

                }
                
            }
        }
        //
        public static void DropView()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DROP view DataView");
            }
        }

        public static List<DataViewModel> LoadView()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))//testit+scantime add
            {
                var output = cnn.Query<DataViewModel>("select * from DataView;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<String> ScanTime(string idscan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))//testit+scantime add
            {
                var output = cnn.Query<String>($"select time from Scans where scan_id = {idscan}", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<UsersModel> LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UsersModel>("select * from Users", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void AddUser(string nm, string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into users (pc_name, ip) values('{nm}', '{ ip}');");
            }
        }

        public static void UpdateUserIp(string nm, string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update users set ip='{ip}' where pc_name='{nm}';");
            }
        }
        public static void UpdateUserName(string nm, string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update users set pc_name='{nm}' where ip='{ip}';");
            }
        }

        public static List<ProcessesModel> LoadProcs()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProcessesModel>("select * from Processes;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<UsersModel> LoadUserName(string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UsersModel>($"select * from Users where ip='{ip}';", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<UsersModel> LoadUserIp(string nm)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UsersModel>($"select * from Users where pc_name='{nm}';", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void AddProcess(string p)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into processes (process_name) values('{p}');");
            }
        }

        public static List<DataModel> LoadData()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DataModel>("select * from Data", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<DataModel> LoadDataExact(string proc_name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DataModel>($"select * from Data where process_name='{proc_name}';", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddData(int p, int n, string pc, string proc, int scn)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into data (positive_scan, negative_scan, ip, scan_id, process_name) values('{p}','{n}','{pc}','{scn}','{proc}');");
            }
        }
        public static void AddScan(string time, string date)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into scans (time, date) values('{time}', '{date}');");
            }
        }
        public static List<DataModel> LoadDataTime(String proc)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DataModel>($"select * from Data where process_name='{proc}';", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<DataModel> LoadDataByProcAndIp(String proc, String Ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DataModel>($"select * from Data where process_name='{proc}' and ip='{Ip}';", new DynamicParameters());
                return output.ToList();
            }
        }


        public static List<ScansModel> LoadScans()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ScansModel>("select * from Scans", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ScansModel> LoadScan(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ScansModel>($"select * from Scans where scan_id = {id};", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ListsModel> LoadList(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ListsModel>($"select * from Lists where list_name = '{name}';", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ListsModel> LoadListname()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ListsModel>("select distinct list_name from Lists;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ListsModel> LoadListPCname(string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ListsModel>($"select distinct ip from Lists where ip='{ip}';", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddList(string ip, string listname, string proc1 = "", string proc2 = "", string proc3 = "", string proc4 = "", string proc5 = "")
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into lists (ip, list_name, proc1, proc2, proc3, proc4, proc5) values('{ip}', '{listname}', '{proc1}', '{proc2}', '{proc3}', '{proc4}', '{proc5}');");
            }
        }

        public static void DeletefromList(string listname, string ip = "")
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"delete from Lists where ip='{ip}' and list_name='{listname}';");
            }
        }

        public static List<UsersModel> StatsLoad(string proc)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UsersModel>($"SELECT DISTINCT pc_name, ip from (select * from Users join Data on (Data.ip = Users.ip AND process_name = '{proc}'))", new DynamicParameters());
                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
