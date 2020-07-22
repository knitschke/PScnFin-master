using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PScnFin.Models;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace PScnFin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<UsersModel> UM = new List<UsersModel>();
        List<UsersModel> UM2 = new List<UsersModel>();
        List<UsersModel> UM3 = new List<UsersModel>();
        List<UsersModel> UM4 = new List<UsersModel>();
        List<UsersModel> UM5 = new List<UsersModel>();
        List<UsersModel> UM6 = new List<UsersModel>();
        //List<UsersModel> UM = new List<UsersModel>();
        List<ProcessesModel> PM = new List<ProcessesModel>();
        List<ScansModel> SM = new List<ScansModel>();
        int counter_scn = 0;
        string timebox,namebox,namebox2;
        //long timeelapsed=0;
        public MainWindow()
        {
            InitializeComponent();
            RB1.IsChecked = true;
            LoadProcsList();
            lm = SqliteDataAccess.LoadListname();
            foreach (ListsModel x in lm)
            {
                listname.Items.Add(x.list_name);
                listname2.Items.Add(x.list_name);
                listname3.Items.Add(x.list_name);
                listname4.Items.Add(x.list_name);
                listname5.Items.Add(x.list_name);
                listname6.Items.Add(x.list_name);
            }
        }
        private void LoadProcsList()
        {
            PM = SqliteDataAccess.LoadProcs();
            foreach (ProcessesModel o in PM)
            {
                CB.Items.Add(o.process_name);
                CB2.Items.Add(o.process_name);
                CB3.Items.Add(o.process_name);
                CB4.Items.Add(o.process_name);
                CB5.Items.Add(o.process_name);
            }
            CB.Text = CB.Items.GetItemAt(0).ToString() ;
            CB2.Text = CB2.Items.GetItemAt(1).ToString();
            CB3.Text = CB3.Items.GetItemAt(2).ToString();
            CB4.Text = CB4.Items.GetItemAt(3).ToString();
            CB5.Text = CB5.Items.GetItemAt(4).ToString();
            /*
            CB.ItemsSource = null;
            CB.ItemsSource = PM;
            
            CB.DisplayMemberPath = "process_name";
            */
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Statystyki st = new Statystyki();
            st.Owner = this;
            st.Show();
            //this.Close();
        }
        Stopwatch sw = new Stopwatch();/*
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Rozpoczęto szukanie aktywnych adresów");
            try { 
            SqliteDataAccess.AddProcess(CB.Text.ToString());
            CB.Items.Add(CB.Text.ToString());
            PM = SqliteDataAccess.LoadProcs();
            }
            catch (Exception ex)
            {
            }
            // 
            UM = new List<UsersModel>();
            RunPingSweep_Async();
            

            MessageBox.Show("Zakończono szykanie adresów");
        }*/

        private int timeout = 100;
        public int nFound = 0;
        private SpinWait wait = new SpinWait();
        static object lockObj = new object();
        Stopwatch stopWatch = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        private TimeSpan ts;
        List<ListsModel> lm = new List<ListsModel>();
        List<ListsModel> lmod = new List<ListsModel>();
        List<ListsModel> lmod2 = new List<ListsModel>();
        List<ListsModel> lmod3 = new List<ListsModel>();
        List<ListsModel> lmod4 = new List<ListsModel>();
        List<ListsModel> lmod5 = new List<ListsModel>();
        List<ListsModel> lmod6 = new List<ListsModel>();

        public async void RunPingSweep_Async(string nameboxx, int sliders)
        {
            nFound = 0;
            var tasks = new List<Task>();

            //
            //this.BeginInvoke((Action)(() => { lmod = SqliteDataAccess.LoadListPCname(listname.Text)}));

            if (sliders == 1)
            {
                lmod = SqliteDataAccess.LoadListPCname(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod)
                {
                    Ping p = new Ping();

                    var task = PingAndUpdateAsync(p, x.pc_name,1);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
                
            else if (sliders==2)
            {
                lmod2 = SqliteDataAccess.LoadListPCname(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod2)
                {
                    Ping p = new Ping();

                    var task = PingAndUpdateAsync(p, x.pc_name,2);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }

            else if (sliders == 3)
            {
                lmod3 = SqliteDataAccess.LoadListPCname(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod3)
                {
                    Ping p = new Ping();

                    var task = PingAndUpdateAsync(p, x.pc_name,3);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
            else if (sliders == 4)
            {
                lmod4 = SqliteDataAccess.LoadListPCname(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod4)
                {
                    Ping p = new Ping();

                    var task = PingAndUpdateAsync(p, x.pc_name,4);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
            else if (sliders == 5)
            {
                lmod5 = SqliteDataAccess.LoadListPCname(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod5)
                {
                    Ping p = new Ping();

                    var task = PingAndUpdateAsync(p, x.pc_name,5);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
            else if (sliders == 6)
            {
                lmod6 = SqliteDataAccess.LoadListPCname(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod6)
                {
                    Ping p = new Ping();

                    var task = PingAndUpdateAsync(p, x.pc_name,6);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }

            await Task.WhenAll(tasks).ContinueWith(t =>
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                Console.WriteLine(nFound.ToString() + " devices found! Elapsed time: " + ts.ToString());
                //if(sliders==1) procscananddatabase(UM, proc, 1);


            });
        }

        List<string> dates;

        private void get_dates()
        {
            
            foreach(var x in cal.SelectedDates)
            {
                dates.Add(x.Day.ToString() + "." + x.Month.ToString()) ;
            }
        }
        private async Task PingAndUpdateAsync(Ping ping, string ip, int ver)
        {

            var reply = await ping.SendPingAsync(ip, timeout);

            if (reply.Status == IPStatus.Success)
            {
                //Console.WriteLine(reply.Address+" "+ GetMachineNameFromIPAddress(reply.Address.ToString()));
                if (GetMachineNameFromIPAddress(reply.Address.ToString()).Length > 1)
                {
                    UsersModel x = new UsersModel();
                    x.pc_name = GetMachineNameFromIPAddress(reply.Address.ToString());
                    x.ip = reply.Address.ToString();
                    if (ver == 1)
                        UM.Add(x);
                    else if (ver == 2)
                        UM2.Add(x);
                    else if (ver == 3)
                        UM3.Add(x);
                    else if (ver == 4)
                        UM4.Add(x);
                    else if (ver == 5)
                        UM5.Add(x);
                    else if (ver == 6)
                        UM6.Add(x);
                    Console.WriteLine(x.ip + " " + x.pc_name);
                    try
                    {
                        SqliteDataAccess.AddUser(x.pc_name, x.ip);
                    }
                    catch (System.Data.SQLite.SQLiteException)
                    {
                        SqliteDataAccess.UpdateUser(x.pc_name, x.ip);
                    }
                }
                    
                lock (lockObj)
                {
                    nFound++;
                    ping.Dispose();
                }
                ping.Dispose();
            }
            if (reply.Status != IPStatus.Success)
            {
                UsersModel x = new UsersModel();
                x.ip = ip;
                x.pc_name = ip;
                if (ver == 1)
                    UM.Add(x);
                else if (ver == 2)
                    UM2.Add(x);
                else if (ver == 3)
                    UM3.Add(x);
                else if (ver == 4)
                    UM4.Add(x);
                else if (ver == 5)
                    UM5.Add(x);
                else if (ver == 6)
                    UM6.Add(x);
                ping.Dispose();
            }


        }

        private static string GetMachineNameFromIPAddress(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);

                machineName = hostEntry.HostName;
            }
            catch (Exception)
            {
                // Machine not found...
            }
            return machineName;
        }

        private void addingprocesses()
        {
            try
            {
                SqliteDataAccess.AddProcess(CB.Text.ToString());
                CB.Items.Add(CB.Text.ToString());
                PM = SqliteDataAccess.LoadProcs();
            }
            catch (Exception)
            {
            }
        }

        private void scan(object slid)//object slid
        {
            //Thread.Sleep(TimeSpan.FromSeconds(1));
            //this.Dispatcher.BeginInvoke(new Action(() =>
            if ((int)slid == 1)
            {
                UM = new List<UsersModel>();
            }  
            else if((int)slid ==2)
                UM2 = new List<UsersModel>();
            else if ((int)slid == 3)
                UM3 = new List<UsersModel>();
            else if ((int)slid == 4)
                UM4 = new List<UsersModel>();
            else if ((int)slid == 5)
                UM5 = new List<UsersModel>();
            else if ((int)slid == 6)
                UM6 = new List<UsersModel>();

            //if(slider.Value==2)
            if ((int)slid == 1)
                RunPingSweep_Async(namebox, (int)slid);//)
            if ((int)slid == 2)
                RunPingSweep_Async(namebox2, (int)slid);
            if ((int)slid == 3)
                RunPingSweep_Async(namebox3, (int)slid);
            if ((int)slid == 4)
                RunPingSweep_Async(namebox4, (int)slid);
            if ((int)slid == 5)
                RunPingSweep_Async(namebox5, (int)slid);
            if ((int)slid == 6)
                RunPingSweep_Async(namebox6, (int)slid);
            //Thread.Sleep(10000);
            //MessageBox.Show("Zakończono szykanie adresów");

            //->

            //MessageBox.Show(slid.ToString());
            if ((int)slid == 1)
                procscananddatabase(UM, proc, 1);
            if ((int)slid == 2)
                procscananddatabase(UM2, proc2, 2);
            if ((int)slid == 3)
                procscananddatabase(UM3, proc3, 3);
            if ((int)slid == 4)
                procscananddatabase(UM4, proc4, 4);
            if ((int)slid == 5)
                procscananddatabase(UM5, proc5, 5);
            if ((int)slid == 6)
                procscananddatabase(UM6, proc6, 6);
            //Thread.Sleep(30000);

        }








        private void procscananddatabase(List<UsersModel> um, string[] prc, int sv)
        {
            Thread.Sleep(5000);
            if (sv > 1)
                Thread.Sleep(5000);
            if (sv > 2)
                Thread.Sleep(5000);
            if (sv > 3)
                Thread.Sleep(5000);
            if (sv > 4)
                Thread.Sleep(5000);
            if (sv > 5)
                Thread.Sleep(5000);
            DateTime now = DateTime.Now;
            dates.Remove(now.Day.ToString() + "." + now.Month.ToString());
            int countusrs = 0;
            foreach (UsersModel u in um)
            {
                countusrs += 1;
            }
            string[,] vec = new string[countusrs, 3];
            string[,] vec2 = new string[countusrs, 3];
            string[,] vec3 = new string[countusrs, 3];
            string[,] vec4 = new string[countusrs, 3];
            string[,] vec5 = new string[countusrs, 3];
            int v = 0;
            foreach (UsersModel u in um)
            {
                vec[v, 0] = u.pc_name;
                vec[v, 1] = "0";
                vec[v, 2] = "0";
                vec2[v, 0] = u.pc_name;
                vec2[v, 1] = "0";
                vec2[v, 2] = "0";
                vec3[v, 0] = u.pc_name;
                vec3[v, 1] = "0";
                vec3[v, 2] = "0";
                vec4[v, 0] = u.pc_name;
                vec4[v, 1] = "0";
                vec4[v, 2] = "0";
                vec5[v, 0] = u.pc_name;
                vec5[v, 1] = "0";
                vec5[v, 2] = "0";

                v++;
            }

            
            int checkprocnmbrs = 0;
            foreach (string x in prc)
            {
                if (x.Length >2)
                    checkprocnmbrs++;

             }
            //now = DateTime.Now;
            Stopwatch pause = new Stopwatch();
            sw.Restart();
            while (sw.ElapsedMilliseconds <= (Convert.ToInt64(timebox) * 60000))
            {
                pause.Restart();
                //timeelapsed = sw.ElapsedMilliseconds / 60000;
                foreach (UsersModel u in um)
                {


                    //timeelapsed = sw.ElapsedMilliseconds / 60000;
                    //Console.WriteLine(u.full);
                    if (PingHost(u.ip) == true)
                        try
                        {


                            Process[] procByName = Process.GetProcessesByName(prc[0], u.pc_name);
                            if (procByName.Length > 0)
                            {
                                for (int i = 0; i < v; i++)
                                    if (vec[i, 0] == u.pc_name)
                                    {
                                        vec[i, 1] = (int.Parse(vec[i, 1]) + 1).ToString();
                                        Console.WriteLine(u.pc_name + " +" + vec[i, 1] + prc[0]);
                                    }
                            }
                            else
                            {
                                for (int i = 0; i < v; i++)
                                    if (vec[i, 0] == u.pc_name)
                                    {
                                        vec[i, 2] = (int.Parse(vec[i, 2]) + 1).ToString();
                                        Console.WriteLine(u.pc_name + "- " + vec[i, 2] + prc[0]);
                                    }
                            }
                            if (checkprocnmbrs > 1)
                            {
                                procByName = Process.GetProcessesByName(prc[1], u.pc_name);
                                if (procByName.Length > 0)
                                {
                                    for (int i = 0; i < v; i++)
                                        if (vec2[i, 0] == u.pc_name)
                                        {
                                            vec2[i, 1] = (int.Parse(vec2[i, 1]) + 1).ToString();
                                            Console.WriteLine(u.pc_name + "+ " + vec2[i, 1] + prc[1]);
                                        }

                                }
                                else
                                {
                                    for (int i = 0; i < v; i++)
                                        if (vec2[i, 0] == u.pc_name)
                                        {
                                            vec2[i, 2] = (int.Parse(vec2[i, 2]) + 1).ToString();
                                            Console.WriteLine(u.pc_name + "- " + vec2[i, 2] + prc[1]);
                                        }
                                }
                            }
                            if (checkprocnmbrs > 2)
                            {
                                procByName = Process.GetProcessesByName(prc[2], u.pc_name);
                                if (procByName.Length > 0)
                                {
                                    for (int i = 0; i < v; i++)
                                        if (vec3[i, 0] == u.pc_name)
                                            vec3[i, 1] = (int.Parse(vec3[i, 1]) + 1).ToString();
                                }
                                else
                                {
                                    for (int i = 0; i < v; i++)
                                        if (vec3[i, 0] == u.pc_name)
                                            vec3[i, 2] = (int.Parse(vec3[i, 2]) + 1).ToString();
                                }
                            }
                            if (checkprocnmbrs > 3)
                            {
                                procByName = Process.GetProcessesByName(prc[3], u.pc_name);
                                if (procByName.Length > 0)
                                {
                                    for (int i = 0; i < v; i++)
                                        if (vec4[i, 0] == u.pc_name)
                                            vec4[i, 1] = (int.Parse(vec4[i, 1]) + 1).ToString();
                                }
                                else
                                {
                                    for (int i = 0; i < v; i++)
                                        if (vec4[i, 0] == u.pc_name)
                                            vec4[i, 2] = (int.Parse(vec4[i, 2]) + 1).ToString();
                                }
                            }
                            if (checkprocnmbrs > 4)
                            {
                                procByName = Process.GetProcessesByName(prc[4], u.pc_name);
                                if (procByName.Length > 0)
                                {
                                    for (int i = 0; i < v; i++)
                                        if (vec5[i, 0] == u.pc_name)
                                            vec5[i, 1] = (int.Parse(vec5[i, 1]) + 1).ToString();
                                }
                                else
                                {
                                    for (int i = 0; i < v; i++)
                                        if (vec5[i, 0] == u.pc_name)
                                            vec5[i, 2] = (int.Parse(vec5[i, 2]) + 1).ToString();
                                }
                            }
                            if (sw.ElapsedMilliseconds >= (Convert.ToInt64(timebox) * 60000)) break;


                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.ToString() + ":  " + prc[0] + u.pc_name);
                        }


                }
                if (pause.Elapsed.TotalMilliseconds < 300000)
                    Thread.Sleep((int)(300000 - pause.Elapsed.TotalMilliseconds));
            }
            
            foreach (UsersModel u in um)
            {
                int p = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;
                int n = 0, n2 = 0, n3 = 0, n4 = 0, n5 = 0;
                for (int i = 0; i < v; i++)
                {
                    if (vec[i, 0] == u.pc_name)
                    {
                        p = int.Parse(vec[i, 1]);
                        n = int.Parse(vec[i, 2]);
                    }
                    if (vec2[i, 0] == u.pc_name)
                    {
                        p2 = int.Parse(vec2[i, 1]);
                        n2 = int.Parse(vec2[i, 2]);
                    }
                    if (vec3[i, 0] == u.pc_name)
                    {
                        p3 = int.Parse(vec3[i, 1]);
                        n3 = int.Parse(vec3[i, 2]);
                    }
                    if (vec4[i, 0] == u.pc_name)
                    {
                        p4 = int.Parse(vec4[i, 1]);
                        n4 = int.Parse(vec4[i, 2]);
                    }
                    if (vec5[i, 0] == u.pc_name)
                    {
                        p5 = int.Parse(vec5[i, 1]);
                        n5 = int.Parse(vec5[i, 2]);
                    }
                }
                //if (sv == 1)
                //UM = um;
                //if (sv == 2)
                    //UM2 = um;
                if (p+n>0)
                {
                    if (u.pc_name == null)
                    {
                        u.pc_name = u.ip;
                    }

                    if (u.pc_name == u.ip)
                        if(GetMachineNameFromIPAddress(u.ip)!=string.Empty)
                            u.pc_name = GetMachineNameFromIPAddress(u.ip);
                        
                    //zeskanowac i podac nazwe
                    SqliteDataAccess.AddData(p, n, u.pc_name, prc[0], counter_scn);
                    if (checkprocnmbrs > 1)
                        SqliteDataAccess.AddData(p2, n2, u.pc_name, prc[1], counter_scn);
                    if (checkprocnmbrs > 2)
                        SqliteDataAccess.AddData(p3, n3, u.pc_name, prc[2], counter_scn);
                    if (checkprocnmbrs > 3)
                        SqliteDataAccess.AddData(p4, n4, u.pc_name, prc[3], counter_scn);
                    if (checkprocnmbrs > 4)
                        SqliteDataAccess.AddData(p5, n5, u.pc_name, prc[4], counter_scn);
                }
            }
            //sleep

            //MessageBox.Show(now.ToString());

            //dates.Remove(now.Day.ToString() + "." + now.Month.ToString());
            is_finished++;
        }

        string[] proc = new string[5];
        string[] proc2 = new string[5];
        string[] proc3 = new string[5];
        string[] proc4 = new string[5];
        string[] proc5 = new string[5];
        string[] proc6 = new string[5];

        private void proc_listing(string name, ref string[] tab)
        {
            if (SqliteDataAccess.LoadList(name).Last().proc1 != null)
                tab[0] = SqliteDataAccess.LoadList(name).Last().proc1;
            if (SqliteDataAccess.LoadList(name).Last().proc2 != null)
                tab[1] = SqliteDataAccess.LoadList(name).Last().proc2;
            if (SqliteDataAccess.LoadList(name).Last().proc3 != null)
                tab[2] = SqliteDataAccess.LoadList(name).Last().proc3;
            if (SqliteDataAccess.LoadList(name).Last().proc4 != null)
                tab[3] = SqliteDataAccess.LoadList(name).Last().proc4;
            if (SqliteDataAccess.LoadList(name).Last().proc5 != null)
                tab[4] = SqliteDataAccess.LoadList(name).Last().proc5;

        }
        double slidervalue;
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress,1000);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            counter_scn = 0;
            var caldates = cal.SelectedDates;
            foreach (var x in caldates)
            {
                MessageBox.Show(x.Day.ToString()+" "+x.Month);
            }


            progressbar.Value = 0;
            is_finished = 0;
            BackgroundWorker worker = new BackgroundWorker();
            BackgroundWorker worker2 = new BackgroundWorker();
            BackgroundWorker worker3 = new BackgroundWorker();
            BackgroundWorker worker4 = new BackgroundWorker();
            BackgroundWorker worker5 = new BackgroundWorker();
            BackgroundWorker worker6 = new BackgroundWorker();

            BackgroundWorker timeelsapsedworker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            timeelsapsedworker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            timeelsapsedworker.DoWork += timeelsapsedworker_DoWork;
            //worker.ProgressChanged += worker_ProgressChanged;
            timeelsapsedworker.ProgressChanged += timeelsapsedworker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            timeelsapsedworker.RunWorkerCompleted += timeelsapsedworker_RunWorkerCompleted;
            addingprocesses();//copy
            namebox = listname.Text.ToString();
            worker2.WorkerReportsProgress = true;
            worker2.DoWork += worker2_DoWork;
            worker2.RunWorkerCompleted += worker2_RunWorkerCompleted;
            worker3.WorkerReportsProgress = true;
            worker3.DoWork += worker3_DoWork;
            worker3.RunWorkerCompleted += worker3_RunWorkerCompleted;
            worker4.WorkerReportsProgress = true;
            worker4.DoWork += worker4_DoWork;
            worker4.RunWorkerCompleted += worker4_RunWorkerCompleted;
            worker5.WorkerReportsProgress = true;
            worker5.DoWork += worker5_DoWork;
            worker5.RunWorkerCompleted += worker5_RunWorkerCompleted;
            worker6.WorkerReportsProgress = true;
            worker6.DoWork += worker6_DoWork;
            worker6.RunWorkerCompleted += worker6_RunWorkerCompleted;
            slidervalue = slider.Value;
            sw.Reset();
            dates = new List<string>();
            timebox = TTB.Text.ToString();
            cal_button_display();
            DateTime now = DateTime.Now;

            SM = SqliteDataAccess.LoadScans();
            foreach (ScansModel s in SM)
            {
                counter_scn++;
            }
            get_dates();
            if (slider.Value > 1)
            {
                namebox2 = listname2.Text.ToString();
                get_dates();
            }
                
            if (slider.Value > 2)
            {
                namebox3 = listname3.Text.ToString();
                get_dates();
            }
                
            if (slider.Value > 3)
            {
                namebox4 = listname4.Text.ToString();
                get_dates();
            }

            if (slider.Value > 4)
            {
                namebox5 = listname5.Text.ToString();
                get_dates();
            }
            if (slider.Value > 5)
            {
                namebox6 = listname6.Text.ToString();
                get_dates();
            }

            //lmod = SqliteDataAccess.LoadList(namebox);
            //lmod2 = SqliteDataAccess.LoadList(namebox2);
            if (cal.SelectedDates.Count > 0)
                try
                {
                    proc_listing(namebox, ref proc);
                    worker.RunWorkerAsync(1);
                    if (slider.Value > 1)
                    {
                        proc_listing(namebox2, ref proc2);
                        worker2.RunWorkerAsync(2);
                    }
                        
                    if (slider.Value > 2)
                    {
                        proc_listing(namebox3, ref proc3);
                        worker3.RunWorkerAsync(3);
                    }
                        
                    if (slider.Value > 3)
                    {
                        proc_listing(namebox4, ref proc4);
                        worker4.RunWorkerAsync(4);
                    }
                        
                    if (slider.Value > 4)
                    {
                        proc_listing(namebox5, ref proc5);
                        worker5.RunWorkerAsync(5);
                    }
                       
                    if (slider.Value > 5)
                    {
                        proc_listing(namebox6, ref proc6);
                        worker6.RunWorkerAsync(6);
                    }
                    
                    timeelsapsedworker.RunWorkerAsync();
                    enabledisable(false);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Wybierz conajmniej jedną datę i jedną listę do skanowania.");
                }
            else MessageBox.Show("Wybierz daty.");
            //scan();
        }

        private void timeelsapsedworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 0 && is_finished == (int)slidervalue && dates.Count < 1)
            {
                scanbt.Background = Brushes.LightGreen;
                enabledisable(true);
            }
            else if(e.ProgressPercentage==0)
            {
                cal_button_display();
            }
            else
            {
                scanbt.Background = Brushes.Red;
                enabledisable(false);
            }       
        }

        void cal_button_display()
        {
            cbcalendar.Text = "abc";//(dates.Count / (int)slidervalue).ToString()+" dni";
        }

        private void enabledisable(bool isenabled)
        {
            listbutton.IsEnabled = isenabled;
            cal.IsEnabled = isenabled;
            //scanbt.IsEnabled = isenabled;
            scanbt.IsHitTestVisible = isenabled;
            scanbt.Focusable = isenabled;
            slider.IsEnabled = isenabled; 
        }

        void progbarchange(object sender)
        {
            int progressPercentage = 0;
            sw2.Start();
                while (true)
                {
                
                if (progressPercentage == 100)
                    {
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                    while (is_finished != slidervalue)//----------------------------------------------------------------------------------------------------------
                    {
                        Thread.Sleep(15000);
                    }
                    
                    (sender as BackgroundWorker).ReportProgress(0);
                    Thread.Sleep(1000);
                    is_finished = 0;
                    //MessageBox.Show("Zakończono skanowanie");
                    sw2.Reset();
                    break;
                    }
                else
                    {
                    progressPercentage = (int)((double)(((sw2.ElapsedMilliseconds / 60000) * 100) / (int.Parse(timebox)) ));
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                    Thread.Sleep(5000);
                    Console.WriteLine((sw2.ElapsedMilliseconds / 60000).ToString());
                    }
                }
            
            
        }

        private void timeelsapsedworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //sw2.Stop();
        }

        private void timeelsapsedworker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            while (dates.Count > 0)
            {
                DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);//-------------------------------------------
                DateTime now = DateTime.Now;

                if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
                {
                    try
                    {
                        SqliteDataAccess.AddScan(timebox, now.ToString());
                        counter_scn++;//ttb.text.tostring
                        SM = SqliteDataAccess.LoadScans();
                      }
                    catch (Exception xxx) { MessageBox.Show(xxx.ToString()); }
                    progbarchange(sender);
                }
                Thread.Sleep(150000);
            }          
        }

        int is_finished = 0;
        private string namebox3;
        private string namebox4;
        private string namebox5;
        private string namebox6;

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //is_finished++;
            //MessageBox.Show("worker1 finished "+ is_finished);

        }
        private void worker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //is_finished++;
            //MessageBox.Show("worker2 finished -" + is_finished);
        }
        private void worker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //is_finished++;
            //MessageBox.Show("worker3 finished -" + is_finished);
        }
        private void worker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //is_finished++;
            //MessageBox.Show("worker4 finished -" + is_finished);
        }
        private void worker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //is_finished++;
            //MessageBox.Show("worker5 finished -" + is_finished);
        }
        private void worker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //is_finished++;
            //MessageBox.Show("worker6 finished -" + is_finished);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            

            while (dates.Count > 0)
            {
                DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);//od 11;30
                DateTime now = DateTime.Now;
                if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
                {
                    scan(e.Argument);
                }
                Thread.Sleep(150000);
            }
        }
        private void worker2_DoWork(object sender, DoWorkEventArgs e)
        {
            

            while (dates.Count > 0)
            {
                DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);//od 11;30
                DateTime now = DateTime.Now;
                if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
                {
                    scan(e.Argument);
                }
                Thread.Sleep(150000);
            }
        }
        private void worker3_DoWork(object sender, DoWorkEventArgs e)
        {
            

            while (dates.Count > 0)
            {
                DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);//od 11;30
                DateTime now = DateTime.Now;
                if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
                {
                    scan(e.Argument);
                    
                }
                Thread.Sleep(150000);
            }
        }
        private void worker4_DoWork(object sender, DoWorkEventArgs e)
        {
            

            while (dates.Count > 0)
            {
                DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);//od 11;30
                DateTime now = DateTime.Now;
                if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
                {
                    scan(e.Argument);
                    
                }
                Thread.Sleep(150000);
            }
        }
        private void worker5_DoWork(object sender, DoWorkEventArgs e)
        {
            

            while (dates.Count > 0)
            {
                DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);//od 11;30
                DateTime now = DateTime.Now;
                if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
                {
                    scan(e.Argument);
                    
                }
                Thread.Sleep(150000);
            }
        }
        private void worker6_DoWork(object sender, DoWorkEventArgs e)
        {
            

            while (dates.Count > 0)
            {
                DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);//od 11;30
                DateTime now = DateTime.Now;
                if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
                {
                    scan(e.Argument);
                    
                }
                Thread.Sleep(150000);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //BaseIP = IPTB.Text.ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CB2.Visibility = Visibility.Visible;
            CB3.Visibility = Visibility.Hidden;
            CB4.Visibility = Visibility.Hidden;
            CB5.Visibility = Visibility.Hidden;
            LabProc.Content = "Nazwy procesów:";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            CB2.Visibility = Visibility.Hidden;
            CB3.Visibility = Visibility.Hidden;
            CB4.Visibility = Visibility.Hidden;
            CB5.Visibility = Visibility.Hidden;
            LabProc.Content = "Nazwa procesu:";
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slidervalue = slider.Value;
            if (slider.Value == 6)
            {
                listname6.Visibility = Visibility.Visible;
                listname5.Visibility = Visibility.Visible;
                listname4.Visibility = Visibility.Visible;
                listname3.Visibility = Visibility.Visible;
                listname2.Visibility = Visibility.Visible;

            }
            else if (slider.Value == 5)
            {
                listname6.Visibility = Visibility.Hidden;
                listname5.Visibility = Visibility.Visible;
                listname4.Visibility = Visibility.Visible;
                listname3.Visibility = Visibility.Visible;
                listname2.Visibility = Visibility.Visible;
            }
            else if (slider.Value == 4)
            {
                listname6.Visibility = Visibility.Hidden;
                listname5.Visibility = Visibility.Hidden;
                listname4.Visibility = Visibility.Visible;
                listname3.Visibility = Visibility.Visible;
                listname2.Visibility = Visibility.Visible;
            }
            else if(slider.Value == 3)
            {
                listname6.Visibility = Visibility.Hidden;
                listname5.Visibility = Visibility.Hidden;
                listname4.Visibility = Visibility.Hidden;
                listname3.Visibility = Visibility.Visible;
                listname2.Visibility = Visibility.Visible;
            }
            else if(slider.Value==2)
            {
                listname6.Visibility = Visibility.Hidden;
                listname5.Visibility = Visibility.Hidden;
                listname4.Visibility = Visibility.Hidden;
                listname3.Visibility = Visibility.Hidden;
                listname2.Visibility = Visibility.Visible;
            }
            else
            {
                listname6.Visibility = Visibility.Hidden;
                listname5.Visibility = Visibility.Hidden;
                listname4.Visibility = Visibility.Hidden;
                listname3.Visibility = Visibility.Hidden;
                listname2.Visibility = Visibility.Hidden;
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            CB2.Visibility = Visibility.Visible;
            CB3.Visibility = Visibility.Visible;
            CB4.Visibility = Visibility.Hidden;
            CB5.Visibility = Visibility.Hidden;
            LabProc.Content = "Nazwy procesów:";
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            CB2.Visibility = Visibility.Visible;
            CB3.Visibility = Visibility.Visible;
            CB4.Visibility = Visibility.Visible;
            CB5.Visibility = Visibility.Hidden;
            LabProc.Content = "Nazwy procesów:";
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            CB2.Visibility = Visibility.Visible;
            CB3.Visibility = Visibility.Visible;
            CB4.Visibility = Visibility.Visible;
            CB5.Visibility = Visibility.Visible;
            LabProc.Content = "Nazwy procesów:";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListSettings ls = new ListSettings();
            //ls.Owner = this;
            ls.Show();
            this.Close();
            
        }

        private void listname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod = SqliteDataAccess.LoadList(listname.SelectedItem.ToString());
            if (lmod[lmod.Count-1].proc5 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Visible;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod[lmod.Count - 1].proc1;
                CB2.Text = lmod[lmod.Count - 1].proc2;
                CB3.Text = lmod[lmod.Count - 1].proc3;
                CB4.Text = lmod[lmod.Count - 1].proc4;
                CB5.Text = lmod[lmod.Count - 1].proc5;
                RB5.IsChecked = true;
            }
            else if (lmod[lmod.Count - 1].proc4 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod[lmod.Count - 1].proc1;
                CB2.Text = lmod[lmod.Count - 1].proc2;
                CB3.Text = lmod[lmod.Count - 1].proc3;
                CB4.Text = lmod[lmod.Count - 1].proc4;
                RB4.IsChecked = true;
            }
            else if (lmod[lmod.Count - 1].proc3 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod[lmod.Count - 1].proc1;
                CB2.Text = lmod[lmod.Count - 1].proc2;
                CB3.Text = lmod[lmod.Count - 1].proc3;
                RB3.IsChecked = true;
            }
            else if (lmod[lmod.Count - 1].proc2 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod[lmod.Count - 1].proc1;
                CB2.Text = lmod[lmod.Count - 1].proc2;
                RB2.IsChecked = true;
            }
            else
            {
                CB2.Visibility = Visibility.Hidden;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwa procesu:";
                CB.Text = lmod[lmod.Count - 1].proc1;
                RB1.IsChecked = true;
            }



        }


        private void listname2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod2 = SqliteDataAccess.LoadList(listname2.SelectedItem.ToString());
            if (lmod2[lmod2.Count - 1].proc5 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Visible;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod2[lmod2.Count - 1].proc1;
                CB2.Text = lmod2[lmod2.Count - 1].proc2;
                CB3.Text = lmod2[lmod2.Count - 1].proc3;
                CB4.Text = lmod2[lmod2.Count - 1].proc4;
                CB5.Text = lmod2[lmod2.Count - 1].proc5;
                RB5.IsChecked = true;
            }
            else if (lmod2[lmod2.Count - 1].proc4 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod2[lmod2.Count - 1].proc1;
                CB2.Text = lmod2[lmod2.Count - 1].proc2;
                CB3.Text = lmod2[lmod2.Count - 1].proc3;
                CB4.Text = lmod2[lmod2.Count - 1].proc4;
                RB4.IsChecked = true;
            }
            else if (lmod2[lmod2.Count - 1].proc3 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod2[lmod2.Count - 1].proc1;
                CB2.Text = lmod2[lmod2.Count - 1].proc2;
                CB3.Text = lmod2[lmod2.Count - 1].proc3;
                RB3.IsChecked = true;
            }
            else if (lmod2[lmod2.Count - 1].proc2 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod2[lmod2.Count - 1].proc1;
                CB2.Text = lmod2[lmod2.Count - 1].proc2;
                RB2.IsChecked = true;
            }
            else
            {
                CB2.Visibility = Visibility.Hidden;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwa procesu:";
                CB.Text = lmod2[lmod2.Count - 1].proc1;
                RB1.IsChecked = true;
            }



        }

        private void listname3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod3 = SqliteDataAccess.LoadList(listname3.SelectedItem.ToString());
            if (lmod3[lmod3.Count - 1].proc5 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Visible;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod3[lmod3.Count - 1].proc1;
                CB2.Text = lmod3[lmod3.Count - 1].proc2;
                CB3.Text = lmod3[lmod3.Count - 1].proc3;
                CB4.Text = lmod3[lmod3.Count - 1].proc4;
                CB5.Text = lmod3[lmod3.Count - 1].proc5;
                RB5.IsChecked = true;
            }
            else if (lmod3[lmod3.Count - 1].proc4 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod3[lmod3.Count - 1].proc1;
                CB2.Text = lmod3[lmod3.Count - 1].proc2;
                CB3.Text = lmod3[lmod3.Count - 1].proc3;
                CB4.Text = lmod3[lmod3.Count - 1].proc4;
                RB4.IsChecked = true;
            }
            else if (lmod3[lmod3.Count - 1].proc3 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod3[lmod3.Count - 1].proc1;
                CB2.Text = lmod3[lmod3.Count - 1].proc2;
                CB3.Text = lmod3[lmod3.Count - 1].proc3;
                RB3.IsChecked = true;
            }
            else if (lmod3[lmod3.Count - 1].proc2 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod3[lmod3.Count - 1].proc1;
                CB2.Text = lmod3[lmod3.Count - 1].proc2;
                RB2.IsChecked = true;
            }
            else
            {
                CB2.Visibility = Visibility.Hidden;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwa procesu:";
                CB.Text = lmod3[lmod3.Count - 1].proc1;
                RB1.IsChecked = true;
            }



        }

        private void listname4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod4 = SqliteDataAccess.LoadList(listname4.SelectedItem.ToString());
            if (lmod4[lmod4.Count - 1].proc5 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Visible;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod4[lmod4.Count - 1].proc1;
                CB2.Text = lmod4[lmod4.Count - 1].proc2;
                CB3.Text = lmod4[lmod4.Count - 1].proc3;
                CB4.Text = lmod4[lmod4.Count - 1].proc4;
                CB5.Text = lmod4[lmod4.Count - 1].proc5;
                RB5.IsChecked = true;
            }
            else if (lmod4[lmod4.Count - 1].proc4 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod4[lmod4.Count - 1].proc1;
                CB2.Text = lmod4[lmod4.Count - 1].proc2;
                CB3.Text = lmod4[lmod4.Count - 1].proc3;
                CB4.Text = lmod4[lmod4.Count - 1].proc4;
                RB4.IsChecked = true;
            }
            else if (lmod4[lmod4.Count - 1].proc3 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod4[lmod4.Count - 1].proc1;
                CB2.Text = lmod4[lmod4.Count - 1].proc2;
                CB3.Text = lmod4[lmod4.Count - 1].proc3;
                RB3.IsChecked = true;
            }
            else if (lmod4[lmod4.Count - 1].proc2 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod4[lmod4.Count - 1].proc1;
                CB2.Text = lmod4[lmod4.Count - 1].proc2;
                RB2.IsChecked = true;
            }
            else
            {
                CB2.Visibility = Visibility.Hidden;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwa procesu:";
                CB.Text = lmod4[lmod4.Count - 1].proc1;
                RB1.IsChecked = true;
            }



        }

        private void listname5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod5 = SqliteDataAccess.LoadList(listname5.SelectedItem.ToString());
            if (lmod5[lmod5.Count - 1].proc5 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Visible;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod5[lmod5.Count - 1].proc1;
                CB2.Text = lmod5[lmod5.Count - 1].proc2;
                CB3.Text = lmod5[lmod5.Count - 1].proc3;
                CB4.Text = lmod5[lmod5.Count - 1].proc4;
                CB5.Text = lmod5[lmod5.Count - 1].proc5;
                RB5.IsChecked = true;
            }
            else if (lmod5[lmod5.Count - 1].proc4 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod5[lmod5.Count - 1].proc1;
                CB2.Text = lmod5[lmod5.Count - 1].proc2;
                CB3.Text = lmod5[lmod5.Count - 1].proc3;
                CB4.Text = lmod5[lmod5.Count - 1].proc4;
                RB4.IsChecked = true;
            }
            else if (lmod5[lmod5.Count - 1].proc3 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod5[lmod5.Count - 1].proc1;
                CB2.Text = lmod5[lmod5.Count - 1].proc2;
                CB3.Text = lmod5[lmod5.Count - 1].proc3;
                RB3.IsChecked = true;
            }
            else if (lmod5[lmod5.Count - 1].proc2 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod5[lmod5.Count - 1].proc1;
                CB2.Text = lmod5[lmod5.Count - 1].proc2;
                RB2.IsChecked = true;
            }
            else
            {
                CB2.Visibility = Visibility.Hidden;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwa procesu:";
                CB.Text = lmod5[lmod5.Count - 1].proc1;
                RB1.IsChecked = true;
            }



        }

        private void dbwindow_Click(object sender, RoutedEventArgs e)
        {
            DBManage ls = new DBManage();
            ls.Owner = this;
            ls.Show();
            //this.Close();
        }

        /// <summary>
        /// mover - funkcja wyswietlajaca dane listy na mouseover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mover(object sender, MouseEventArgs e)
        {
            if (listname.SelectedItem!=null)
            {
                lmod = SqliteDataAccess.LoadList(listname.SelectedItem.ToString());
                if (lmod[lmod.Count - 1].proc5 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Visible;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod[lmod.Count - 1].proc1;
                    CB2.Text = lmod[lmod.Count - 1].proc2;
                    CB3.Text = lmod[lmod.Count - 1].proc3;
                    CB4.Text = lmod[lmod.Count - 1].proc4;
                    CB5.Text = lmod[lmod.Count - 1].proc5;
                    RB5.IsChecked = true;
                }
                else if (lmod[lmod.Count - 1].proc4 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod[lmod.Count - 1].proc1;
                    CB2.Text = lmod[lmod.Count - 1].proc2;
                    CB3.Text = lmod[lmod.Count - 1].proc3;
                    CB4.Text = lmod[lmod.Count - 1].proc4;
                    RB4.IsChecked = true;
                }
                else if (lmod[lmod.Count - 1].proc3 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod[lmod.Count - 1].proc1;
                    CB2.Text = lmod[lmod.Count - 1].proc2;
                    CB3.Text = lmod[lmod.Count - 1].proc3;
                    RB3.IsChecked = true;
                }
                else if (lmod[lmod.Count - 1].proc2 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod[lmod.Count - 1].proc1;
                    CB2.Text = lmod[lmod.Count - 1].proc2;
                    RB2.IsChecked = true;
                }
                else
                {
                    CB2.Visibility = Visibility.Hidden;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwa procesu:";
                    CB.Text = lmod[lmod.Count - 1].proc1;
                    RB1.IsChecked = true;
                }
            }
        }

        private void mover2(object sender, MouseEventArgs e)
        {
            if (listname2.SelectedItem != null)
            {
                lmod2 = SqliteDataAccess.LoadList(listname2.SelectedItem.ToString());
                if (lmod2[lmod2.Count - 1].proc5 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Visible;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod2[lmod2.Count - 1].proc1;
                    CB2.Text = lmod2[lmod2.Count - 1].proc2;
                    CB3.Text = lmod2[lmod2.Count - 1].proc3;
                    CB4.Text = lmod2[lmod2.Count - 1].proc4;
                    CB5.Text = lmod2[lmod2.Count - 1].proc5;
                    RB5.IsChecked = true;
                }
                else if (lmod2[lmod2.Count - 1].proc4 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod2[lmod2.Count - 1].proc1;
                    CB2.Text = lmod2[lmod2.Count - 1].proc2;
                    CB3.Text = lmod2[lmod2.Count - 1].proc3;
                    CB4.Text = lmod2[lmod2.Count - 1].proc4;
                    RB4.IsChecked = true;
                }
                else if (lmod2[lmod2.Count - 1].proc3 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod2[lmod2.Count - 1].proc1;
                    CB2.Text = lmod2[lmod2.Count - 1].proc2;
                    CB3.Text = lmod2[lmod2.Count - 1].proc3;
                    RB3.IsChecked = true;
                }
                else if (lmod2[lmod2.Count - 1].proc2 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod2[lmod2.Count - 1].proc1;
                    CB2.Text = lmod2[lmod2.Count - 1].proc2;
                    RB2.IsChecked = true;
                }
                else
                {
                    CB2.Visibility = Visibility.Hidden;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwa procesu:";
                    CB.Text = lmod2[lmod2.Count - 1].proc1;
                    RB1.IsChecked = true;
                }
            }

        }

        private void mover3(object sender, MouseEventArgs e)
        {
            if (listname3.SelectedItem != null)
            {
                lmod3 = SqliteDataAccess.LoadList(listname3.SelectedItem.ToString());
                if (lmod3[lmod3.Count - 1].proc5 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Visible;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod3[lmod3.Count - 1].proc1;
                    CB2.Text = lmod3[lmod3.Count - 1].proc2;
                    CB3.Text = lmod3[lmod3.Count - 1].proc3;
                    CB4.Text = lmod3[lmod3.Count - 1].proc4;
                    CB5.Text = lmod3[lmod3.Count - 1].proc5;
                    RB5.IsChecked = true;
                }
                else if (lmod3[lmod3.Count - 1].proc4 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod3[lmod3.Count - 1].proc1;
                    CB2.Text = lmod3[lmod3.Count - 1].proc2;
                    CB3.Text = lmod3[lmod3.Count - 1].proc3;
                    CB4.Text = lmod3[lmod3.Count - 1].proc4;
                    RB4.IsChecked = true;
                }
                else if (lmod3[lmod3.Count - 1].proc3 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod3[lmod3.Count - 1].proc1;
                    CB2.Text = lmod3[lmod3.Count - 1].proc2;
                    CB3.Text = lmod3[lmod3.Count - 1].proc3;
                    RB3.IsChecked = true;
                }
                else if (lmod3[lmod3.Count - 1].proc2 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod3[lmod3.Count - 1].proc1;
                    CB2.Text = lmod3[lmod3.Count - 1].proc2;
                    RB2.IsChecked = true;
                }
                else
                {
                    CB2.Visibility = Visibility.Hidden;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwa procesu:";
                    CB.Text = lmod3[lmod3.Count - 1].proc1;
                    RB1.IsChecked = true;
                }
            }
        }

        private void mover4(object sender, MouseEventArgs e)
        {
            if (listname4.SelectedItem != null)
            {
                lmod4 = SqliteDataAccess.LoadList(listname4.SelectedItem.ToString());
                if (lmod4[lmod4.Count - 1].proc5 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Visible;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod4[lmod4.Count - 1].proc1;
                    CB2.Text = lmod4[lmod4.Count - 1].proc2;
                    CB3.Text = lmod4[lmod4.Count - 1].proc3;
                    CB4.Text = lmod4[lmod4.Count - 1].proc4;
                    CB5.Text = lmod4[lmod4.Count - 1].proc5;
                    RB5.IsChecked = true;
                }
                else if (lmod4[lmod4.Count - 1].proc4 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod4[lmod4.Count - 1].proc1;
                    CB2.Text = lmod4[lmod4.Count - 1].proc2;
                    CB3.Text = lmod4[lmod4.Count - 1].proc3;
                    CB4.Text = lmod4[lmod4.Count - 1].proc4;
                    RB4.IsChecked = true;
                }
                else if (lmod4[lmod4.Count - 1].proc3 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod4[lmod4.Count - 1].proc1;
                    CB2.Text = lmod4[lmod4.Count - 1].proc2;
                    CB3.Text = lmod4[lmod4.Count - 1].proc3;
                    RB3.IsChecked = true;
                }
                else if (lmod4[lmod4.Count - 1].proc2 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod4[lmod4.Count - 1].proc1;
                    CB2.Text = lmod4[lmod4.Count - 1].proc2;
                    RB2.IsChecked = true;
                }
                else
                {
                    CB2.Visibility = Visibility.Hidden;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwa procesu:";
                    CB.Text = lmod4[lmod4.Count - 1].proc1;
                    RB1.IsChecked = true;
                }
            }
        }

        private void mover5(object sender, MouseEventArgs e)
        {
            if (listname5.SelectedItem != null)
            {
                lmod5 = SqliteDataAccess.LoadList(listname5.SelectedItem.ToString());
                if (lmod5[lmod5.Count - 1].proc5 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Visible;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod5[lmod5.Count - 1].proc1;
                    CB2.Text = lmod5[lmod5.Count - 1].proc2;
                    CB3.Text = lmod5[lmod5.Count - 1].proc3;
                    CB4.Text = lmod5[lmod5.Count - 1].proc4;
                    CB5.Text = lmod5[lmod5.Count - 1].proc5;
                    RB5.IsChecked = true;
                }
                else if (lmod5[lmod5.Count - 1].proc4 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod5[lmod5.Count - 1].proc1;
                    CB2.Text = lmod5[lmod5.Count - 1].proc2;
                    CB3.Text = lmod5[lmod5.Count - 1].proc3;
                    CB4.Text = lmod5[lmod5.Count - 1].proc4;
                    RB4.IsChecked = true;
                }
                else if (lmod5[lmod5.Count - 1].proc3 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod5[lmod5.Count - 1].proc1;
                    CB2.Text = lmod5[lmod5.Count - 1].proc2;
                    CB3.Text = lmod5[lmod5.Count - 1].proc3;
                    RB3.IsChecked = true;
                }
                else if (lmod5[lmod5.Count - 1].proc2 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod5[lmod5.Count - 1].proc1;
                    CB2.Text = lmod5[lmod5.Count - 1].proc2;
                    RB2.IsChecked = true;
                }
                else
                {
                    CB2.Visibility = Visibility.Hidden;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwa procesu:";
                    CB.Text = lmod5[lmod5.Count - 1].proc1;
                    RB1.IsChecked = true;
                }
            }
        }

        private void mover6(object sender, MouseEventArgs e)
        {
            if (listname6.SelectedItem != null)
            {
                lmod6 = SqliteDataAccess.LoadList(listname6.SelectedItem.ToString());
                if (lmod6[lmod6.Count - 1].proc5 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Visible;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod6[lmod6.Count - 1].proc1;
                    CB2.Text = lmod6[lmod6.Count - 1].proc2;
                    CB3.Text = lmod6[lmod6.Count - 1].proc3;
                    CB4.Text = lmod6[lmod6.Count - 1].proc4;
                    CB5.Text = lmod6[lmod6.Count - 1].proc5;
                    RB5.IsChecked = true;
                }
                else if (lmod6[lmod6.Count - 1].proc4 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Visible;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod6[lmod6.Count - 1].proc1;
                    CB2.Text = lmod6[lmod6.Count - 1].proc2;
                    CB3.Text = lmod6[lmod6.Count - 1].proc3;
                    CB4.Text = lmod6[lmod6.Count - 1].proc4;
                    RB4.IsChecked = true;
                }
                else if (lmod6[lmod6.Count - 1].proc3 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Visible;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod6[lmod6.Count - 1].proc1;
                    CB2.Text = lmod6[lmod6.Count - 1].proc2;
                    CB3.Text = lmod6[lmod6.Count - 1].proc3;
                    RB3.IsChecked = true;
                }
                else if (lmod6[lmod6.Count - 1].proc2 != "")
                {
                    CB2.Visibility = Visibility.Visible;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwy procesów:";
                    CB.Text = lmod6[lmod6.Count - 1].proc1;
                    CB2.Text = lmod6[lmod6.Count - 1].proc2;
                    RB2.IsChecked = true;
                }
                else
                {
                    CB2.Visibility = Visibility.Hidden;
                    CB3.Visibility = Visibility.Hidden;
                    CB4.Visibility = Visibility.Hidden;
                    CB5.Visibility = Visibility.Hidden;
                    LabProc.Content = "Nazwa procesu:";
                    CB.Text = lmod6[lmod6.Count - 1].proc1;
                    RB1.IsChecked = true;
                }
            }
        }

        private void cal_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            cbcalendar.Text = "qwe";// cal.SelectedDates.Count.ToString() + " dni";
        }

        private void cbcalendar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbcalendar.Text = "nbv";// cal.SelectedDates.Count.ToString() + " dni";
        }

        private void cbcalendar_DropDownClosed(object sender, EventArgs e)
        {
            cbcalendar.Text = "xxx";//cal.SelectedDates.Count.ToString()+" dni";
        }

        private void listname6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod6 = SqliteDataAccess.LoadList(listname6.SelectedItem.ToString());
            if (lmod6[lmod6.Count - 1].proc5 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Visible;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod6[lmod6.Count - 1].proc1;
                CB2.Text = lmod6[lmod6.Count - 1].proc2;
                CB3.Text = lmod6[lmod6.Count - 1].proc3;
                CB4.Text = lmod6[lmod6.Count - 1].proc4;
                CB5.Text = lmod6[lmod6.Count - 1].proc5;
                RB5.IsChecked = true;
            }
            else if (lmod6[lmod6.Count - 1].proc4 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Visible;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod6[lmod6.Count - 1].proc1;
                CB2.Text = lmod6[lmod6.Count - 1].proc2;
                CB3.Text = lmod6[lmod6.Count - 1].proc3;
                CB4.Text = lmod6[lmod6.Count - 1].proc4;
                RB4.IsChecked = true;
            }
            else if (lmod6[lmod6.Count - 1].proc3 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Visible;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod6[lmod6.Count - 1].proc1;
                CB2.Text = lmod6[lmod6.Count - 1].proc2;
                CB3.Text = lmod6[lmod6.Count - 1].proc3;
                RB3.IsChecked = true;
            }
            else if (lmod6[lmod6.Count - 1].proc2 != "")
            {
                CB2.Visibility = Visibility.Visible;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;
                LabProc.Content = "Nazwy procesów:";
                CB.Text = lmod6[lmod6.Count - 1].proc1;
                CB2.Text = lmod6[lmod6.Count - 1].proc2;
                RB2.IsChecked = true;
            }
            else
            {
                CB2.Visibility = Visibility.Hidden;
                CB3.Visibility = Visibility.Hidden;
                CB4.Visibility = Visibility.Hidden;
                CB5.Visibility = Visibility.Hidden;  
                LabProc.Content = "Nazwa procesu:";
                CB.Text = lmod6[lmod6.Count - 1].proc1;
                RB1.IsChecked = true;
            }



        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
