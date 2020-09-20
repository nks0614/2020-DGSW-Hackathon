﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace DGM_windows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        //SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\DrawingBoard\\2020-DGSW-Hackathon\\Window\\DGM_windows\\DGM_windows\\Schedule.mdf;Integrated Security=True");

        public bool IsMouseDown = false;
        static public int IsClose = 0;
        System.Windows.Point currentLocation = new System.Windows.Point(0, 0);
        System.Windows.Point MoveStartLocation;

        public DateTime MealsSelectDate = DateTime.Now;

        public static string Today = DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString("00") + DateTime.Now.Date.Day.ToString("00");

        public MainWindow()
        {
            InitializeComponent();

            TodayDate.Content = DateTime.Now.Date.Year.ToString() + "년 " + DateTime.Now.Date.Month.ToString("00") + "월 " + DateTime.Now.Date.Day.ToString("00") + "일";

            Set_Weather();

            Set_Meals(Today);

            Set_Schedule();
        }
        public void Set_Weather()
        {
            string[] getSchoolWeather = GetSchoolWeather.getWeather();

            WeatherTemp.Content = getSchoolWeather[0];
            WeatherContent.Content = getSchoolWeather[1];

            string uriSource = string.Format("pack://application:,,,/DGM_windows;component/Image/{0}.png", getSchoolWeather[2]);
            WeatherImage.Source = new ImageSourceConverter().ConvertFromString(uriSource) as ImageSource;
        }
        public void Set_Meals(string SelectDate)
        {
            string[] getSchoolMeals = GetSchoolMeals.schoolMeals(SelectDate);

            MealBreakfast.Text = getSchoolMeals[0];
            MealLunch.Text = getSchoolMeals[1];
            MealDinner.Text = getSchoolMeals[2];
        }

        public void Set_Schedule()
        {
            string getSchoolSchedule = GetSchoolSchedule.getSchedule();

            ScheduleContent.Text = getSchoolSchedule;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = true;
            if (IsClose == 1)
            {
                IsClose = 2;
                Set_Schedule();
            }
            else if (IsClose == 2) IsClose = 0;
            MoveStartLocation = GetMousePosition();
        }
        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(IsMouseDown == true && IsClose == 0)
            {
                System.Windows.Point Location = GetMousePosition();
                this.Left = currentLocation.X += (Location.X - MoveStartLocation.X);
                this.Top = currentLocation.Y += (Location.Y - MoveStartLocation.Y);
            }

        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = false;
        }

        public System.Windows.Point GetMousePosition()
        {
            return Mouse.GetPosition(MainWindows);
        }

        public System.Windows.Forms.NotifyIcon notify;
        private void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();
                // 아이콘 설정부분
                notify = new System.Windows.Forms.NotifyIcon();
                //notify.Icon = new System.Drawing.Icon(@"manager.png");  // 외부아이콘 사용 시

                notify.Icon = Properties.Resources.ManagerIcon;   // Resources 아이콘 사용 시
                notify.Visible = true;
                notify.ContextMenu = menu;
                notify.Text = "DGSW_Manger";

                // 아이콘 더블클릭 이벤트 설정
                notify.DoubleClick += Notify_DoubleClick;

                System.Windows.Forms.MenuItem exitProgram = new System.Windows.Forms.MenuItem();
                menu.MenuItems.Add(exitProgram);
                exitProgram.Index = 0;
                exitProgram.Text = "프로그램 종료";
                exitProgram.Click += delegate (object click, EventArgs eClick)
                {
                    System.Windows.Application.Current.Shutdown();
                    notify.Dispose();
                };

                System.Windows.Forms.MenuItem ShowProgram = new System.Windows.Forms.MenuItem();
                menu.MenuItems.Add(ShowProgram);
                ShowProgram.Index = 0;
                ShowProgram.Text = "프로그램 숨기기";
                ShowProgram.Click += delegate (object click, EventArgs eClick)
                {
                    if (this.Visibility == Visibility.Visible)
                    {
                        ShowProgram.Text = "프로그램 보이기";
                        this.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        ShowProgram.Text = "프로그램 숨기기";
                        this.Visibility = Visibility.Visible;
                    }
                };
            }
            catch (Exception ee)
            {
                System.Windows.MessageBox.Show(ee + " : code 7");
            }
        }

        private void Notify_DoubleClick(object sender, EventArgs e)
        {
            if(this.Visibility == Visibility.Visible)
            {
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                this.Visibility = Visibility.Visible;
            }
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Memo memo = new Memo();
            memo.ShowDialog();
        }

        private void MainWindows_Closed(object sender, EventArgs e)
        {
            notify.Dispose();
        }

        private void Schedule_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScheduleView scheduleView = new ScheduleView();
            scheduleView.ShowDialog();
        }

        private void LeftButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MealsSelectDate = MealsSelectDate.AddDays(-1);
            Set_Meals(MealsSelectDate.Date.Year.ToString() + MealsSelectDate.Date.Month.ToString("00") + MealsSelectDate.Date.Day.ToString("00"));
        }

        private void RightButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MealsSelectDate = MealsSelectDate.AddDays(1);
            Set_Meals(MealsSelectDate.Date.Year.ToString() + MealsSelectDate.Date.Month.ToString("00") + MealsSelectDate.Date.Day.ToString("00"));
        }
    }
}
