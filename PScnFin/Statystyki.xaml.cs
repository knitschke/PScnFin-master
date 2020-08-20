using PScnFin.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PScnFin
{
    /// <summary>
    /// Interaction logic for Statystyki.xaml
    /// </summary>
    public partial class Statystyki : Window
    {
        List<UsersModel> UM = new List<UsersModel>();
        List<ProcessesModel> PM = new List<ProcessesModel>();
        List<ScansModel> SM = new List<ScansModel>();
        List<DataModel> DM = new List<DataModel>();
        List<DataModel> DMtime = new List<DataModel>();
        float time = 0;
        string slcted = "";
        string slctedproc = "";
        public Statystyki()
        {
            InitializeComponent();
            LoadProcsList();
            LoadScanList();
            LoadUsersList();
        }
        private void LoadScanList()
        {
            SM = SqliteDataAccess.LoadScans();
        }
        private void LoadProcsList()
        {
            PM = SqliteDataAccess.LoadProcs();
            foreach (ProcessesModel o in PM)
            {
                CB.Items.Add(o.process_name);
            }
            CB.SelectedIndex = 0;
        }
        private void LoadUsersList()
        {
            UM = SqliteDataAccess.StatsLoad(CB.SelectedItem.ToString());
            foreach (UsersModel o in UM)
            {
                LB.Items.Add(o.full);
            }
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

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            slctedproc = CB.SelectedItem.ToString();
            int countp = 0;
            int countpall = 0;
            int countn = 0;
            int countnall = 0;
            time = 0;
            DM = SqliteDataAccess.LoadDataExact(CB.SelectedItem.ToString()); ;
            SM = SqliteDataAccess.LoadScans();
            if (LB.SelectedItem != null)
                slcted = LB.SelectedItem.ToString();
            string[] xx;
            xx = slcted.Split(' ');

            foreach (DataModel o in DM)
            {
                if (o.ip == xx[1])
                {
                    countp += o.positive_scan;
                    countn += o.negative_scan;
                    foreach (ScansModel oo in SM)
                    {
                        if (oo.scan_id == o.scan_id)
                            time += oo.time;
                    }
                }
            }
            float x = 0;
            if (countp + countn > 0)
                x = (countp * 100) / (countp + countn);
            T1.Text = x.ToString() + "%";
            T2.Text = time.ToString();

            DMtime = SqliteDataAccess.LoadDataTime(slctedproc);
            foreach (DataModel t in DMtime)
            {
                countpall += t.positive_scan;
                countnall += t.negative_scan;
            }
            if ((countnall + countpall) == 0)
                T3.Text = "0";
            else
                T3.Text = ((countpall * 100) / (countpall + countnall)).ToString() + "%";

        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LB.Items.Clear();
            LoadUsersList();
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            UM = SqliteDataAccess.StatsLoad(CB.SelectedItem.ToString());
            LB.Items.Clear();

            foreach (var x in UM)
            {
                if (x.full.Contains(filter.Text))
                    LB.Items.Add(x.full);
            }
        }
    }
}
