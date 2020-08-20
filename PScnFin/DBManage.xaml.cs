using PScnFin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PScnFin
{
    /// <summary>
    /// Logika interakcji dla klasy DBManage.xaml
    /// </summary>
    public partial class DBManage : Window
    {
        public DBManage()
        {
            InitializeComponent();
        }

        List<UsersModel> um = new List<UsersModel>();
        List<DataModel> dm = new List<DataModel>();
        List<SingleListModel> lm = new List<SingleListModel>();
        List<ProcessesModel> pm = new List<ProcessesModel>();
        List<ScansModel> sm = new List<ScansModel>();
        string current_table = "";

        void fill_cb_data()
        {
            sortcb.Items.Clear();
            sortcb.Items.Add("data_id");
            sortcb.Items.Add("positive_scan");
            sortcb.Items.Add("negative_scan");
            sortcb.Items.Add("ip");
            sortcb.Items.Add("pc_name");
            sortcb.Items.Add("scan_id");
            sortcb.Items.Add("process_name");
            sortcb.Items.Add("scan_time");
            sortcb.Items.Add("usage");
            sortcb2.Items.Clear();
            sortcb2.Items.Add("data_id");
            sortcb2.Items.Add("positive_scan");
            sortcb2.Items.Add("negative_scan");
            sortcb.Items.Add("ip");
            sortcb2.Items.Add("pc_name");
            sortcb2.Items.Add("scan_id");
            sortcb2.Items.Add("process_name");
            sortcb2.Items.Add("scan_time");
            sortcb2.Items.Add("usage");
        }
        void fill_cb_lists()
        {
            sortcb.Items.Clear();
            sortcb.Items.Add("list_name");
            sortcb.Items.Add("proc1");
            sortcb.Items.Add("proc2");
            sortcb.Items.Add("proc3");
            sortcb.Items.Add("proc4");
            sortcb.Items.Add("proc5");
            sortcb2.Items.Clear();
            sortcb2.Items.Add("list_name");
            sortcb2.Items.Add("proc1");
            sortcb2.Items.Add("proc2");
            sortcb2.Items.Add("proc3");
            sortcb2.Items.Add("proc4");
            sortcb2.Items.Add("proc5");
        }
        void fill_cb_users()
        {
            sortcb.Items.Clear();
            sortcb.Items.Add("pc_name");
            sortcb.Items.Add("ip");
            sortcb2.Items.Clear();
            sortcb2.Items.Add("pc_name");
            sortcb2.Items.Add("ip");
        }
        void fill_cb_proc()
        {
            sortcb.Items.Clear();
            sortcb.Items.Add("process_name");
            sortcb2.Items.Clear();
            sortcb2.Items.Add("process_name");
        }
        void fill_cb_scans()
        {
            sortcb.Items.Clear();
            sortcb.Items.Add("scan_id");
            sortcb.Items.Add("time");
            sortcb.Items.Add("date");
            sortcb2.Items.Clear();
            sortcb2.Items.Add("scan_id");
            sortcb2.Items.Add("time");
            sortcb2.Items.Add("date");
        }

        private void datab_Click(object sender, RoutedEventArgs e)
        {
            current_table = "data";
            dm = SqliteDataAccess.LoadData();
            dg.ItemsSource = dm;
            fill_cb_data();
        }

        private void listb_Click(object sender, RoutedEventArgs e)
        {
            lm = new List<SingleListModel>();
            current_table = "list";
            List<ListsModel> temp = SqliteDataAccess.LoadListname();
            foreach (var x in temp)
            {
                SingleListModel xx = new SingleListModel();
                xx.list_name = x.list_name;
                xx.proc1 = SqliteDataAccess.LoadList(x.list_name).Last().proc1;
                xx.proc2 = SqliteDataAccess.LoadList(x.list_name).Last().proc2;
                xx.proc3 = SqliteDataAccess.LoadList(x.list_name).Last().proc3;
                xx.proc4 = SqliteDataAccess.LoadList(x.list_name).Last().proc4;
                xx.proc5 = SqliteDataAccess.LoadList(x.list_name).Last().proc5;
                lm.Add(xx);
            }
            dg.ItemsSource = lm;
            fill_cb_lists();
        }

        private void usersb_Click(object sender, RoutedEventArgs e)
        {
            current_table = "user";
            um = SqliteDataAccess.LoadUsers();
            dg.ItemsSource = um;
            fill_cb_users();
        }

        private void processesb_Click(object sender, RoutedEventArgs e)
        {
            current_table = "process";
            pm = SqliteDataAccess.LoadProcs();
            dg.ItemsSource = pm;
            fill_cb_proc();
        }

        private void scanb_Click(object sender, RoutedEventArgs e)
        {
            current_table = "scan";
            sm = SqliteDataAccess.LoadScans();
            dg.ItemsSource = sm;
            fill_cb_scans();
        }

        private void sortcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void sorttb_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter(sorttb.Text, sorttb2.Text);
        }

        private void exitBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void minBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception)
            {

            }
        }

        void filter(string filter, string filter2)
        {
            List<UsersModel> umtemp = new List<UsersModel>();
            List<UsersModel> umtemp2 = new List<UsersModel>();
            List<DataModel> dmtemp = new List<DataModel>();
            List<DataModel> dmtemp2 = new List<DataModel>();
            List<SingleListModel> lmtemp = new List<SingleListModel>();
            List<SingleListModel> lmtemp2 = new List<SingleListModel>();
            List<ProcessesModel> pmtemp = new List<ProcessesModel>();
            List<ScansModel> smtemp = new List<ScansModel>();
            List<ScansModel> smtemp2 = new List<ScansModel>();

            if (current_table == "user")
            {
                if (sortcb.Text == "pc_name")
                {

                    foreach (var x in um)
                    {
                        if (x.pc_name.Contains(filter))
                            umtemp.Add(x);
                    }
                    dg.ItemsSource = umtemp;
                }
                else if (sortcb.Text == "ip")
                {
                    foreach (var x in um)
                    {
                        if (x.ip.Contains(filter))
                            umtemp.Add(x);
                    }
                    dg.ItemsSource = umtemp;
                }
                //filter2
                if (sortcb2.Text == "pc_name")
                {

                    foreach (var x in umtemp)
                    {
                        if (x.pc_name.Contains(filter2))
                            umtemp2.Add(x);
                    }
                    dg.ItemsSource = umtemp2;
                }
                else if (sortcb2.Text == "ip")
                {
                    foreach (var x in umtemp)
                    {
                        if (x.ip.Contains(filter2))
                            umtemp2.Add(x);
                    }
                    dg.ItemsSource = umtemp2;
                }
            }
            else if (current_table == "data")
            {
                if (sortcb.Text == "data_id")
                {
                    foreach (var x in dm)
                    {
                        if (x.data_id.ToString().Contains(filter))
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb.Text == "positive_scan")
                {
                    foreach (var x in dm)
                    {
                        if (x.positive_scan.ToString().Contains(filter))
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb.Text == "negative_scan")
                {
                    foreach (var x in dm)
                    {
                        if (x.negative_scan.ToString().Contains(filter))
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb.Text == "ip")
                {
                    foreach (var x in dm)
                    {
                        if (x.ip.Contains(filter))
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb.Text == "pc_name")
                {
                    foreach (var x in dm)
                    {
                        if (x.pc_name.Contains(filter))
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb.Text == "scan_id")
                {
                    foreach (var x in dm)
                    {
                        if (x.scan_id.ToString() == filter)
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb.Text == "process_name")
                {
                    foreach (var x in dm)
                    {
                        if (x.process_name.Contains(filter))
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb.Text == "scan_time")
                {
                    foreach (var x in dm)
                    {
                        if (x.scan_time.ToString().Contains(filter))
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb.Text == "usage")
                {
                    int test;
                    if (int.TryParse(filter, out test) == true)
                    {
                        foreach (var x in dm)
                        {
                            if (x.usage_percentage >= double.Parse(filter))
                                dmtemp.Add(x);
                        }
                        dg.ItemsSource = dmtemp;
                    }
                }
                //second filter
                if (sortcb2.Text == "data_id")
                {
                    foreach (var x in dmtemp)
                    {
                        if (x.data_id.ToString().Contains(filter2))
                            dmtemp2.Add(x);
                    }
                    dg.ItemsSource = dmtemp2;
                }
                else if (sortcb2.Text == "positive_scan")
                {
                    foreach (var x in dmtemp)
                    {
                        if (x.positive_scan.ToString().Contains(filter2))
                            dmtemp2.Add(x);
                    }
                    dg.ItemsSource = dmtemp2;
                }
                else if (sortcb2.Text == "negative_scan")
                {
                    foreach (var x in dmtemp)
                    {
                        if (x.negative_scan.ToString().Contains(filter2))
                            dmtemp2.Add(x);
                    }
                    dg.ItemsSource = dmtemp2;
                }
                else if (sortcb2.Text == "ip")
                {
                    foreach (var x in dm)
                    {
                        if (x.ip.Contains(filter))
                            dmtemp.Add(x);
                    }
                    dg.ItemsSource = dmtemp;
                }
                else if (sortcb2.Text == "pc_name")
                {
                    foreach (var x in dmtemp)
                    {
                        if (x.pc_name.Contains(filter2))
                            dmtemp2.Add(x);
                    }
                    dg.ItemsSource = dmtemp2;
                }
                else if (sortcb2.Text == "scan_id")
                {
                    foreach (var x in dmtemp)
                    {
                        if (x.scan_id.ToString() == filter2)
                            dmtemp2.Add(x);
                    }
                    dg.ItemsSource = dmtemp2;
                }
                else if (sortcb2.Text == "process_name")
                {
                    foreach (var x in dmtemp)
                    {
                        if (x.process_name.Contains(filter2))
                            dmtemp2.Add(x);
                    }
                    dg.ItemsSource = dmtemp2;
                }
                else if (sortcb2.Text == "scan_time")
                {
                    foreach (var x in dmtemp)
                    {
                        if (x.scan_time.ToString().Contains(filter2))
                            dmtemp2.Add(x);
                    }
                    dg.ItemsSource = dmtemp2;
                }
                else if (sortcb2.Text == "usage")
                {
                    int test;
                    if (int.TryParse(filter, out test) == true)
                    {
                        foreach (var x in dmtemp)
                        {
                            if (x.usage_percentage >= double.Parse(filter2))
                                dmtemp2.Add(x);
                        }
                        dg.ItemsSource = dmtemp2;
                    }
                }
            }
            else if (current_table == "process")
            {
                if (sortcb.Text == "process_name")
                {
                    foreach (var x in pm)
                    {
                        if (x.process_name.Contains(filter))
                            pmtemp.Add(x);
                    }
                    dg.ItemsSource = pmtemp;
                }
            }
            else if (current_table == "list")
            {
                if (sortcb.Text == "list_name")
                {
                    foreach (var x in lm)
                    {
                        if (x.list_name.Contains(filter))
                            lmtemp.Add(x);
                    }
                    dg.ItemsSource = lmtemp;
                }
                else if (sortcb.Text == "proc1")
                {
                    foreach (var x in lm)
                    {
                        if (x.proc1.Contains(filter))
                            lmtemp.Add(x);
                    }
                    dg.ItemsSource = lmtemp;
                }
                else if (sortcb.Text == "proc2")
                {
                    foreach (var x in lm)
                    {
                        if (x.proc2.Contains(filter))
                            lmtemp.Add(x);
                    }
                    dg.ItemsSource = lmtemp;
                }
                else if (sortcb.Text == "proc3")
                {
                    foreach (var x in lm)
                    {
                        if (x.proc3.Contains(filter))
                            lmtemp.Add(x);
                    }
                    dg.ItemsSource = lmtemp;
                }
                else if (sortcb.Text == "proc4")
                {
                    foreach (var x in lm)
                    {
                        if (x.proc4.Contains(filter))
                            lmtemp.Add(x);
                    }
                    dg.ItemsSource = lmtemp;
                }
                else if (sortcb.Text == "proc5")
                {
                    foreach (var x in lm)
                    {
                        if (x.proc5.Contains(filter))
                            lmtemp.Add(x);
                    }
                    dg.ItemsSource = lmtemp;
                }
                //sort2
                if (sortcb2.Text == "list_name")
                {
                    foreach (var x in lmtemp)
                    {
                        if (x.list_name.Contains(filter2))
                            lmtemp2.Add(x);
                    }
                    dg.ItemsSource = lmtemp2;
                }
                else if (sortcb2.Text == "proc1")
                {
                    foreach (var x in lmtemp)
                    {
                        if (x.proc1.Contains(filter2))
                            lmtemp2.Add(x);
                    }
                    dg.ItemsSource = lmtemp2;
                }
                else if (sortcb2.Text == "proc2")
                {
                    foreach (var x in lmtemp)
                    {
                        if (x.proc2.Contains(filter2))
                            lmtemp2.Add(x);
                    }
                    dg.ItemsSource = lmtemp2;
                }
                else if (sortcb2.Text == "proc3")
                {
                    foreach (var x in lmtemp)
                    {
                        if (x.proc3.Contains(filter2))
                            lmtemp2.Add(x);
                    }
                    dg.ItemsSource = lmtemp2;
                }
                else if (sortcb2.Text == "proc4")
                {
                    foreach (var x in lmtemp)
                    {
                        if (x.proc4.Contains(filter2))
                            lmtemp2.Add(x);
                    }
                    dg.ItemsSource = lmtemp2;
                }
                else if (sortcb2.Text == "proc5")
                {
                    foreach (var x in lmtemp)
                    {
                        if (x.proc5.Contains(filter2))
                            lmtemp2.Add(x);
                    }
                    dg.ItemsSource = lmtemp2;
                }


            }
            else if (current_table == "scan")
            {
                if (sortcb.Text == "scan_id")
                {
                    foreach (var x in sm)
                    {
                        if (x.scan_id.ToString().Contains(filter))
                            smtemp.Add(x);
                    }
                    dg.ItemsSource = smtemp;
                }
                else if (sortcb.Text == "time")
                {
                    foreach (var x in sm)
                    {
                        if (x.time.ToString().Contains(filter))
                            smtemp.Add(x);
                    }
                    dg.ItemsSource = smtemp;
                }
                else if (sortcb.Text == "date")
                {
                    foreach (var x in sm)
                    {
                        if (x.date.Contains(filter))
                            smtemp.Add(x);
                    }
                    dg.ItemsSource = smtemp;
                }
                //sort2
                if (sortcb2.Text == "scan_id")
                {
                    foreach (var x in smtemp)
                    {
                        if (x.scan_id.ToString().Contains(filter2))
                            smtemp2.Add(x);
                    }
                    dg.ItemsSource = smtemp2;
                }
                else if (sortcb2.Text == "time")
                {
                    foreach (var x in smtemp)
                    {
                        if (x.time.ToString().Contains(filter2))
                            smtemp2.Add(x);
                    }
                    dg.ItemsSource = smtemp2;
                }
                else if (sortcb2.Text == "date")
                {
                    foreach (var x in smtemp)
                    {
                        if (x.date.Contains(filter2))
                            smtemp2.Add(x);
                    }
                    dg.ItemsSource = smtemp2;
                }
            }
        }
    }
}

