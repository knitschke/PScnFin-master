using PScnFin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
        List<ProcessesModel> PM = new List<ProcessesModel>();
        List<ScansModel> SM = new List<ScansModel>();
        int counter_scn = 0;
        string timebox, namebox, namebox2;
        Stopwatch sw = new Stopwatch();
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
            CB.Text = CB.Items.GetItemAt(0).ToString();
            CB2.Text = CB2.Items.GetItemAt(1).ToString();
            CB3.Text = CB3.Items.GetItemAt(2).ToString();
            CB4.Text = CB4.Items.GetItemAt(3).ToString();
            CB5.Text = CB5.Items.GetItemAt(4).ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Statystyki st = new Statystyki();
            st.Owner = this;
            st.Show();

        }


        public async void RunPingSweep_Async(string nameboxx, int sliders)
        {
            nFound = 0;
            var tasks = new List<Task>();

            if (sliders == 1)
            {
                lmod = SqliteDataAccess.LoadList(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod)
                {
                    Ping p = new Ping();
                    var task = PingAndUpdateAsync(p, x.ip, 1);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
            else if (sliders == 2)
            {
                lmod2 = SqliteDataAccess.LoadList(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod2)
                {
                    Ping p = new Ping();
                    var task = PingAndUpdateAsync(p, x.ip, 2);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
            else if (sliders == 3)
            {
                lmod3 = SqliteDataAccess.LoadList(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod3)
                {
                    Ping p = new Ping();
                    var task = PingAndUpdateAsync(p, x.ip, 3);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
            else if (sliders == 4)
            {
                lmod4 = SqliteDataAccess.LoadList(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod4)
                {
                    Ping p = new Ping();
                    var task = PingAndUpdateAsync(p, x.ip, 4);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
            else if (sliders == 5)
            {
                lmod5 = SqliteDataAccess.LoadList(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod5)
                {
                    Ping p = new Ping();
                    var task = PingAndUpdateAsync(p, x.ip, 5);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }
            else if (sliders == 6)
            {
                lmod6 = SqliteDataAccess.LoadList(nameboxx);//listname.Text
                stopWatch.Start();

                foreach (ListsModel x in lmod6)
                {
                    Ping p = new Ping();
                    var task = PingAndUpdateAsync(p, x.ip, 6);
                    tasks.Add(task);
                    wait.SpinOnce();
                    p.Dispose();
                }
            }

            await Task.WhenAll(tasks).ContinueWith(t =>
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                Console.WriteLine(nFound.ToString() + " devices found in: " + ts.ToString());
            });
        }

        List<string> dates;

        private void get_dates()
        {
            foreach (var x in cal.SelectedDates)
            {
                dates.Add(x.Day.ToString() + "." + x.Month.ToString());
            }
        }
        private async Task PingAndUpdateAsync(Ping ping, string ip, int ver)
        {
            var reply = await ping.SendPingAsync(ip, timeout);
            if (reply.Status == IPStatus.Success)
            {
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
                        SqliteDataAccess.AddUser((x.pc_name).Split('.')[0], x.ip);
                    }
                    catch (System.Data.SQLite.SQLiteException)
                    {
                        SqliteDataAccess.UpdateUserIp((x.pc_name).Split('.')[0], x.ip);
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
        public static void check_dns_names_kd(string nm = "")
        {
            for (int i = 1; i < 1200; i++)
            {
                try
                {
                    nm = "KD" + i.ToString();
                    if (GetMachineNameFromIPAddress(nm).Length > 1)
                        SqliteDataAccess.AddUser(nm, GetMachineNameFromIPAddress(nm));
                }
                catch (Exception e)
                {
                    if (GetMachineNameFromIPAddress(nm).Length > 1)
                        SqliteDataAccess.UpdateUserName(nm, GetMachineNameFromIPAddress(nm));
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static string GetMachineNameFromIPAddress(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);
                if (ipAdress.Contains("10.3"))
                    machineName = hostEntry.HostName;
                else
                    machineName = hostEntry.AddressList[0].ToString();
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

        private void scan(object slid)
        {
            if ((int)slid == 1)
            {
                UM = new List<UsersModel>();
                RunPingSweep_Async(namebox, (int)slid);
                procscananddatabase(UM, proc, 1);
            }
            else if ((int)slid == 2)
            {
                UM2 = new List<UsersModel>();
                RunPingSweep_Async(namebox2, (int)slid);
                procscananddatabase(UM2, proc2, 2);
            }
            else if ((int)slid == 3)
            {
                UM3 = new List<UsersModel>();
                RunPingSweep_Async(namebox3, (int)slid);
                procscananddatabase(UM3, proc3, 3);
            }
            else if ((int)slid == 4)
            {
                UM4 = new List<UsersModel>();
                RunPingSweep_Async(namebox4, (int)slid);
                procscananddatabase(UM4, proc4, 4);
            }
            else if ((int)slid == 5)
            {
                UM5 = new List<UsersModel>();
                RunPingSweep_Async(namebox5, (int)slid);
                procscananddatabase(UM5, proc5, 5);
            }
            else if ((int)slid == 6)
            {
                UM6 = new List<UsersModel>();
                RunPingSweep_Async(namebox6, (int)slid);
                procscananddatabase(UM6, proc6, 6);
            }
        }

        private int workerccl(int ver)
        {
            if (ver == 0 && timeelsapsedworker.CancellationPending == true)
            {
                return -1;
            }
            else if (ver == 1 && worker.CancellationPending == true)
            {
                return -1;
            }
            else if (ver == 2 && worker2.CancellationPending == true)
            {
                return -1;
            }
            else if (ver == 3 && worker3.CancellationPending == true)
            {
                return -1;
            }
            else if (ver == 4 && worker4.CancellationPending == true)
            {
                return -1;
            }
            else if (ver == 5 && worker5.CancellationPending == true)
            {
                return -1;
            }
            else if (ver == 6 && worker6.CancellationPending == true)
            {
                return -1;
            }
            else return 0;
        }

        private void procscananddatabase(List<UsersModel> um, string[] prc, int sv)
        {
            Thread.Sleep(100000);//100000
            if (workerccl(sv) == -1)
            {
                return;
            }
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
            try
            {
                foreach (UsersModel u in um)
                {
                    if (u.pc_name == null)
                    {
                        u.pc_name = u.ip;
                    }
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
            }
            catch (Exception)
            {
                MessageBox.Show("blad1");
            }

            int checkprocnmbrs = 0;
            foreach (string x in prc)
            {
                if (x.Length > 2)
                    checkprocnmbrs++;
            }

            Stopwatch pause = new Stopwatch();
            sw.Restart();
            while (sw.ElapsedMilliseconds <= (Convert.ToInt64(timebox) * 3600000))
            {

                pause.Restart();
                foreach (UsersModel u in um)
                {
                    Console.WriteLine(u.full);
                    if (workerccl(sv) == -1)
                    {
                        return;
                    }
                    if (PingHost(u.ip) == true)
                        try
                        {
                            Process[] procByName = Process.GetProcessesByName(prc[0], u.ip);//
                            if (procByName.Length > 0)
                            {
                                for (int i = 0; i < v; i++)
                                    if (vec[i, 0] == u.pc_name)
                                    {
                                        vec[i, 1] = (int.Parse(vec[i, 1]) + 1).ToString();
                                    }
                            }
                            else
                            {
                                for (int i = 0; i < v; i++)
                                    if (vec[i, 0] == u.pc_name)
                                    {
                                        vec[i, 2] = (int.Parse(vec[i, 2]) + 1).ToString();
                                    }
                            }
                            if (checkprocnmbrs > 1)
                            {
                                procByName = Process.GetProcessesByName(prc[1], u.ip);
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
                                procByName = Process.GetProcessesByName(prc[2], u.ip);
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
                                procByName = Process.GetProcessesByName(prc[3], u.ip);
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
                                procByName = Process.GetProcessesByName(prc[4], u.ip);
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
                            if (sw.ElapsedMilliseconds >= (Convert.ToInt64(timebox) * 3600000)) break;
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.ToString() + ":  " + prc[0] + u.pc_name);
                        }
                }
                if (pause.Elapsed.TotalMilliseconds < 300000)//300000
                    Thread.Sleep((int)(300000 - pause.Elapsed.TotalMilliseconds));//
            }

            foreach (UsersModel u in um)
            {
                if (workerccl(sv) == -1)
                {
                    return;
                }
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

                if (p + n > 0)
                {
                    if (u.pc_name == u.ip)
                        if (GetMachineNameFromIPAddress(u.ip) != string.Empty)
                            u.pc_name = GetMachineNameFromIPAddress(u.ip);

                    //zeskanowac i podac nazwe
                    SqliteDataAccess.AddData(p, n, u.ip, prc[0], counter_scn);
                    if (checkprocnmbrs > 1)
                        SqliteDataAccess.AddData(p2, n2, u.ip, prc[1], counter_scn);
                    if (checkprocnmbrs > 2)
                        SqliteDataAccess.AddData(p3, n3, u.ip, prc[2], counter_scn);
                    if (checkprocnmbrs > 3)
                        SqliteDataAccess.AddData(p4, n4, u.ip, prc[3], counter_scn);
                    if (checkprocnmbrs > 4)
                        SqliteDataAccess.AddData(p5, n5, u.ip, prc[4], counter_scn);
                }
            }
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
                PingReply reply = pinger.Send(nameOrAddress, 1000);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {

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

        BackgroundWorker worker;
        BackgroundWorker worker2;
        BackgroundWorker worker3;
        BackgroundWorker worker4;
        BackgroundWorker worker5;
        BackgroundWorker worker6;
        BackgroundWorker timeelsapsedworker;

        private void Button_Click_2(object sender, RoutedEventArgs e)//
        {
            counter_scn = 0;
            daysleft.Content = $"Pozostało dni: {cal.SelectedDates.Count}";
            enabledisable(false);
            scanbt.Background = Brushes.Red;
            progressbar.Value = 0;
            is_finished = 0;
            namebox = listname.Text.ToString();
            worker = new BackgroundWorker();
            worker2 = new BackgroundWorker();
            worker3 = new BackgroundWorker();
            worker4 = new BackgroundWorker();
            worker5 = new BackgroundWorker();
            worker6 = new BackgroundWorker();
            timeelsapsedworker = new BackgroundWorker();
            timeelsapsedworker.WorkerReportsProgress = true;
            timeelsapsedworker.ProgressChanged += timeelsapsedworker_ProgressChanged;
            timeelsapsedworker.RunWorkerCompleted += timeelsapsedworker_RunWorkerCompleted;
            addingprocesses();
            timeelsapsedworker.DoWork += timeelsapsedworker_DoWork;
            worker.DoWork += worker_DoWork;
            worker2.DoWork += worker2_DoWork;
            worker3.DoWork += worker3_DoWork;
            worker4.DoWork += worker4_DoWork;
            worker5.DoWork += worker5_DoWork;
            worker6.DoWork += worker6_DoWork;
            worker.WorkerSupportsCancellation = true;
            worker2.WorkerSupportsCancellation = true;
            worker3.WorkerSupportsCancellation = true;
            worker4.WorkerSupportsCancellation = true;
            worker5.WorkerSupportsCancellation = true;
            worker6.WorkerSupportsCancellation = true;
            timeelsapsedworker.WorkerSupportsCancellation = true;
            pr_false();
            slidervalue = slider.Value;
            sw.Reset();
            dates = new List<string>();
            timebox = TTB.Text.ToString();
            DateTime now = DateTime.Now;

            SM = SqliteDataAccess.LoadScans();
            foreach (ScansModel s in SM)
            {
                counter_scn++;
            }
            get_dates();

            if (cal.SelectedDates.Count > 0)
                try
                {
                    timeelsapsedworker.RunWorkerAsync();
                    proc_listing(namebox, ref proc);

                    enabledisable(false);
                    Thread.Sleep(500);
                    worker.RunWorkerAsync(1);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Wybierz conajmniej jedną datę i jedną listę do skanowania.");
                }
            else MessageBox.Show("Wybierz daty.");
        }

        private void timeelsapsedworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 0 && is_finished == (int)slidervalue && dates.Count < 1)
            {
                scanbt.Background = Brushes.LightGreen;
                enabledisable(true);
            }
            else if (e.ProgressPercentage == 0)
            {
                enabledisable(false);
            }
            else if (e.ProgressPercentage == -1)
            {
                scanbt.Background = Brushes.LightGreen;
                enabledisable(true);
                progressbar.Value = 0;
            }
            else if (e.ProgressPercentage == 100)
            {
                daysleft.Content = $"Pozostało dni: {dates.Count / slidervalue}";
            }
            else
            {
                scanbt.Background = Brushes.Red;
                enabledisable(false);
            }
        }

        private void pr_false()
        {
            pr2 = false;
            pr3 = false;
            pr4 = false;
            pr5 = false;
            pr6 = false;
        }

        private void doubledatearray()
        {
            List<string> dates_temp = new List<string>();
            foreach (var x in dates)
            {
                dates_temp.Add(x);
            }
            foreach (var x in dates_temp)
            {
                dates.Add(x);
            }
        }

        private void enabledisable(bool isenabled)
        {
            listbutton.IsEnabled = isenabled;
            cal.IsEnabled = isenabled;
            scanbt.IsHitTestVisible = isenabled;
            scanbt.Focusable = isenabled;
        }

        void progbarchange(object sender)
        {
            int progressPercentage = 0;
            sw2.Start();
            while (true)
            {
                if (timeelsapsedworker.CancellationPending == true)
                {
                    (sender as BackgroundWorker).ReportProgress(-1);
                    //Console.WriteLine("cancelbt wsedl");
                    sw2.Reset();
                    return;
                }
                else if (progressPercentage == 100)
                {
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                    while (is_finished != slidervalue)//----------------------------------------------------------------------------------------------------------
                    {
                        Thread.Sleep(15000);
                    }
                    (sender as BackgroundWorker).ReportProgress(0);
                    Thread.Sleep(10000);
                    is_finished = 0;
                    sw2.Reset();
                    break;
                }
                else
                {
                    progressPercentage = (int)((double)(((sw2.ElapsedMilliseconds / 60000) * 100) / ((int.Parse(timebox)*60))));//
                    if (progressPercentage >= 100)
                    {
                        (sender as BackgroundWorker).ReportProgress(100);
                        progressPercentage = 100;
                    }
                    else
                        (sender as BackgroundWorker).ReportProgress(progressPercentage);
                    Thread.Sleep(5000);
                    Console.WriteLine((sw2.ElapsedMilliseconds / 60000).ToString());
                }
            }
        }

        private void timeelsapsedworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            sw2.Reset();
        }

        private void timeelsapsedworker_DoWork(object sender, DoWorkEventArgs e)
        {

            while (dates.Count > 0)
            {
                try
                {
                    if (slidervalue != slidervaluetemp && is_finished == 0)
                        slidervalue = slidervaluetemp;
                    if (pr2 == false && slidervalue > 1)
                    {
                        proc_listing(namebox2, ref proc2);
                        doubledatearray();
                        worker2.RunWorkerAsync(2);
                        pr2 = true;
                        Thread.Sleep(500);
                    }
                    if (pr3 == false && slidervalue > 2)
                    {
                        proc_listing(namebox3, ref proc3);
                        doubledatearray();
                        worker3.RunWorkerAsync(3);
                        pr3 = true;
                        Thread.Sleep(500);
                    }
                    if (pr4 == false && slidervalue > 3)
                    {
                        proc_listing(namebox4, ref proc4);
                        doubledatearray();
                        worker4.RunWorkerAsync(4);
                        pr4 = true;
                        Thread.Sleep(500);
                    }
                    if (pr5 == false && slidervalue > 4)
                    {
                        proc_listing(namebox5, ref proc5);
                        doubledatearray();
                        worker5.RunWorkerAsync(5);
                        pr5 = true;
                        Thread.Sleep(500);
                    }
                    if (pr6 == false && slidervalue > 5)
                    {
                        proc_listing(namebox6, ref proc6);
                        doubledatearray();
                        worker6.RunWorkerAsync(6);
                        pr6 = true;
                        Thread.Sleep(500);
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                }

                DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);
                DateTime now = DateTime.Now;
                Thread.Sleep(500);
                if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
                {
                    try
                    {
                        SqliteDataAccess.AddScan(timebox, now.ToString());
                        counter_scn++;
                        SM = SqliteDataAccess.LoadScans();
                    }
                    catch (Exception xxx) { MessageBox.Show(xxx.ToString()); }
                    progbarchange(sender);
                }
                if (workerccl(0) == -1)
                {
                    return;
                }
                Thread.Sleep(150000);//150000
            }
        }
        double slidervaluetemp = 0;
        int is_finished = 0;
        private string namebox3;
        private string namebox4;
        private string namebox5;
        private string namebox6;

        void scan_starter(object x)
        {
            DateTime starthr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);
            DateTime now = DateTime.Now;
            if (dates.Contains(now.Day.ToString() + "." + now.Month.ToString()) && now > starthr)
            {
                scan(x);
            }
        }
        bool dnscan;
        bool pr2 = false;
        bool pr3 = false;
        bool pr4 = false;
        bool pr5 = false;
        bool pr6 = false;

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            dnscan = false;
            while (dates.Count > 0)
            {
                if (workerccl(1) == -1)
                {
                    return;
                }
                Thread.Sleep(1000);
                scan_starter(e.Argument);
                if (workerccl(1) == -1)
                {
                    return;
                }
                Thread.Sleep(50000);//50000
                if (dnscan == false)
                {
                    check_dns_names_kd();
                    dnscan = true;
                }
                Thread.Sleep(100000);//100000----
            }
        }
        private void worker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (dates.Count > 0)
            {
                scan_starter(e.Argument);
                if (workerccl(2) == -1)
                {
                    return;
                }
                Thread.Sleep(150000);//----------------0
            }
        }
        private void worker3_DoWork(object sender, DoWorkEventArgs e)
        {
            while (dates.Count > 0)
            {
                scan_starter(e.Argument);
                if (workerccl(3) == -1)
                {
                    return;
                }
                Thread.Sleep(150000);//--------------------0
            }
        }
        private void worker4_DoWork(object sender, DoWorkEventArgs e)
        {
            while (dates.Count > 0)
            {
                scan_starter(e.Argument);
                if (workerccl(4) == -1)
                {
                    return;
                }
                Thread.Sleep(150000);//---------------------0
            }
        }
        private void worker5_DoWork(object sender, DoWorkEventArgs e)
        {
            while (dates.Count > 0)
            {
                scan_starter(e.Argument);
                if (workerccl(5) == -1)
                {
                    return;
                }
                Thread.Sleep(150000);
            }
        }
        private void worker6_DoWork(object sender, DoWorkEventArgs e)
        {
            while (dates.Count > 0)
            {
                scan_starter(e.Argument);
                if (workerccl(6) == -1)
                {
                    return;
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
            visibility2();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            visibility1();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slidervaluetemp = slider.Value;
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
            else if (slider.Value == 3)
            {
                listname6.Visibility = Visibility.Hidden;
                listname5.Visibility = Visibility.Hidden;
                listname4.Visibility = Visibility.Hidden;
                listname3.Visibility = Visibility.Visible;
                listname2.Visibility = Visibility.Visible;
            }
            else if (slider.Value == 2)
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
            visibility3();
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            visibility4();
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            visibility5();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListSettings ls = new ListSettings();
            ls.Show();
            this.Close();
        }

        private void listname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod = SqliteDataAccess.LoadList(listname.SelectedItem.ToString());
            text_changer(lmod);
            namebox = listname.SelectedItem.ToString();
        }

        private void listname2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod2 = SqliteDataAccess.LoadList(listname2.SelectedItem.ToString());
            text_changer(lmod2);
            namebox2 = listname2.SelectedItem.ToString();
        }

        private void listname3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod3 = SqliteDataAccess.LoadList(listname3.SelectedItem.ToString());
            text_changer(lmod3);
            namebox3 = listname3.SelectedItem.ToString();
        }

        private void listname4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod4 = SqliteDataAccess.LoadList(listname4.SelectedItem.ToString());
            text_changer(lmod4);
            namebox4 = listname4.SelectedItem.ToString();
        }

        private void listname5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod5 = SqliteDataAccess.LoadList(listname5.SelectedItem.ToString());
            text_changer(lmod5);
            namebox5 = listname5.SelectedItem.ToString();
        }

        private void cancelbt_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
            timeelsapsedworker.CancelAsync();
            if (slider.Value > 1)
            {
                worker2.CancelAsync();
            }
            if (slider.Value > 2)
            {
                worker3.CancelAsync();
            }
            if (slider.Value > 3)
            {
                worker4.CancelAsync();
            }
            if (slider.Value > 4)
            {
                worker5.CancelAsync();
            }
            if (slider.Value > 5)
            {
                worker6.CancelAsync();
            }
        }

        private void dbwindow_Click(object sender, RoutedEventArgs e)
        {
            DBManage ls = new DBManage();
            ls.Owner = this;
            ls.Show();
        }

        /// <summary>
        /// mover - funkcja wyswietlajaca dane listy na mouseover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mover(object sender, MouseEventArgs e)
        {
            if (listname.SelectedItem != null)
            {
                lmod = SqliteDataAccess.LoadList(listname.SelectedItem.ToString());
                text_changer(lmod);
            }
        }

        private void mover2(object sender, MouseEventArgs e)
        {
            if (listname2.SelectedItem != null)
            {
                lmod2 = SqliteDataAccess.LoadList(listname2.SelectedItem.ToString());
                text_changer(lmod2);
            }
        }

        private void mover3(object sender, MouseEventArgs e)
        {
            if (listname3.SelectedItem != null)
            {
                lmod3 = SqliteDataAccess.LoadList(listname3.SelectedItem.ToString());
                text_changer(lmod3);
            }
        }

        private void mover4(object sender, MouseEventArgs e)
        {
            if (listname4.SelectedItem != null)
            {
                lmod4 = SqliteDataAccess.LoadList(listname4.SelectedItem.ToString());
                text_changer(lmod4);
            }
        }

        private void mover5(object sender, MouseEventArgs e)
        {
            if (listname5.SelectedItem != null)
            {
                lmod5 = SqliteDataAccess.LoadList(listname5.SelectedItem.ToString());
                text_changer(lmod5);
            }
        }

        private void mover6(object sender, MouseEventArgs e)
        {
            if (listname6.SelectedItem != null)
            {
                lmod6 = SqliteDataAccess.LoadList(listname6.SelectedItem.ToString());
                text_changer(lmod6);
            }
        }

        private void cal_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            cbcalendar.Text = "";
            daysleft.Content = $"Pozostało dni: {cal.SelectedDates.Count}";
        }

        private void cbcalendar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbcalendar.Text = "";
        }

        private void cbcalendar_DropDownClosed(object sender, EventArgs e)
        {
            cbcalendar.Text = "";
        }

        private void listname6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lmod6 = SqliteDataAccess.LoadList(listname6.SelectedItem.ToString());
            text_changer(lmod6);
            namebox6 = listname6.SelectedItem.ToString();
        }

        void text_changer(List<ListsModel> lm)
        {
            if (lm[lm.Count - 1].proc5 != "")
            {
                visibility5();
                CB.Text = lm[lm.Count - 1].proc1;
                CB2.Text = lm[lm.Count - 1].proc2;
                CB3.Text = lm[lm.Count - 1].proc3;
                CB4.Text = lm[lm.Count - 1].proc4;
                CB5.Text = lm[lm.Count - 1].proc5;
                RB5.IsChecked = true;
            }
            else if (lm[lm.Count - 1].proc4 != "")
            {
                visibility4();
                CB.Text = lm[lm.Count - 1].proc1;
                CB2.Text = lm[lm.Count - 1].proc2;
                CB3.Text = lm[lm.Count - 1].proc3;
                CB4.Text = lm[lm.Count - 1].proc4;
                RB4.IsChecked = true;
            }
            else if (lm[lm.Count - 1].proc3 != "")
            {
                visibility3();
                CB.Text = lm[lm.Count - 1].proc1;
                CB2.Text = lm[lm.Count - 1].proc2;
                CB3.Text = lm[lm.Count - 1].proc3;
                RB3.IsChecked = true;
            }
            else if (lm[lm.Count - 1].proc2 != "")
            {
                visibility2();
                CB.Text = lm[lm.Count - 1].proc1;
                CB2.Text = lm[lm.Count - 1].proc2;
                RB2.IsChecked = true;
            }
            else
            {
                visibility1();
                CB.Text = lm[lm.Count - 1].proc1;
                RB1.IsChecked = true;
            }
        }

        void visibility1()
        {
            CB2.Visibility = Visibility.Hidden;
            CB3.Visibility = Visibility.Hidden;
            CB4.Visibility = Visibility.Hidden;
            CB5.Visibility = Visibility.Hidden;
            LabProc.Content = "Nazwa procesu:";
        }

        void visibility2()
        {
            CB2.Visibility = Visibility.Visible;
            CB3.Visibility = Visibility.Hidden;
            CB4.Visibility = Visibility.Hidden;
            CB5.Visibility = Visibility.Hidden;
            LabProc.Content = "Nazwy procesów:";
        }
        void visibility3()
        {
            CB2.Visibility = Visibility.Visible;
            CB3.Visibility = Visibility.Visible;
            CB4.Visibility = Visibility.Hidden;
            CB5.Visibility = Visibility.Hidden;
            LabProc.Content = "Nazwy procesów:";
        }
        void visibility4()
        {
            CB2.Visibility = Visibility.Visible;
            CB3.Visibility = Visibility.Visible;
            CB4.Visibility = Visibility.Visible;
            CB5.Visibility = Visibility.Hidden;
            LabProc.Content = "Nazwy procesów:";
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

        void visibility5()
        {
            CB2.Visibility = Visibility.Visible;
            CB3.Visibility = Visibility.Visible;
            CB4.Visibility = Visibility.Visible;
            CB5.Visibility = Visibility.Visible;
            LabProc.Content = "Nazwy procesów:";
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
