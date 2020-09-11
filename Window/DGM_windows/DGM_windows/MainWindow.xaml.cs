using System;
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
        System.Windows.Point currentLocation = new System.Windows.Point(0, 0);
        System.Windows.Point MoveStartLocation;

        public static string Today = DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString("00") + DateTime.Now.Date.Day.ToString("00");

        public MainWindow()
        {
            InitializeComponent();


            //connect.Open();

            /*SqlCommand cmd = new SqlCommand(@"INSERT INTO Schedule (id, time, description)
            VALUES (3,'20030901','3')", connect);

            cmd.ExecuteNonQuery();*/


            /*using (SqlCommand command = new SqlCommand("SELECT description FROM Schedule", connect))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MealLunch.Content = string.Format("{0}", reader.GetString(0));
                }
            }*/

            /*SqlCommand cmd = new SqlCommand("Delete From Schedule Where id = 1", connect);

            cmd.ExecuteNonQuery();*/
            

            //connect.Close();

            TodayDate.Content = DateTime.Now.Date.Year.ToString() + "년 " + DateTime.Now.Date.Month.ToString("00") + "월 " + DateTime.Now.Date.Day.ToString("00") + "일";

            string[] getSchoolWeather = GetSchoolWeather.getWeather();

            WeatherTemp.Content = getSchoolWeather[0];
            WeatherContent.Content = getSchoolWeather[1];


            string uriSource = string.Format("pack://application:,,,/DGM_windows;component/Image/{0}.png",getSchoolWeather[2]);
            WeatherImage.Source = new ImageSourceConverter().ConvertFromString(uriSource) as ImageSource;

            string[] getSchoolMeals = GetSchoolMeals.schoolMeals();

            

            MealBreakfast.Text = getSchoolMeals[0];
            MealLunch.Text = getSchoolMeals[1];
            MealDinner.Text = getSchoolMeals[2];

            string[] getSchoolSchedule = GetSchoolSchedule.getSchedule();

            ScheduleContent.Text = getSchoolSchedule[0];
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = true;
            MealBreakfast.Text = "버튼눌림";
            MoveStartLocation = GetMousePosition();
        }
        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(IsMouseDown == true)
            {

                MealBreakfast.Text = "이동중";
                System.Windows.Point Location = GetMousePosition();
                this.Left = currentLocation.X += (Location.X - MoveStartLocation.X);
                this.Top = currentLocation.Y += (Location.Y - MoveStartLocation.Y);
            }

        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = false;

            MealBreakfast.Text = "버튼 올라감";
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
        public void memo_close(object sender, EventArgs e)
        {
            IsMouseDown = false;
            MealLunch.Text = "ㅎㅎㅎ";
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MealDinner.Text = "버튼 눌렸또";
            Memo memo = new Memo();
            memo.ShowDialog();
            memo.Closing += memo_close;
            System.Windows.Shapes.Rectangle back = new System.Windows.Shapes.Rectangle();
            back.Fill = System.Windows.Media.Brushes.Red;
            back.Stroke = System.Windows.Media.Brushes.Black;
            back.StrokeThickness = 1;
            back.Width = 100;
            back.Height = 200;
            back.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            back.VerticalAlignment = VerticalAlignment.Top;
            back.Visibility = Visibility.Visible;
            
            System.Windows.Controls.TextBox textbox1 = new System.Windows.Controls.TextBox();
            textbox1.Text = "날짜를 입력하세요 (20200909)";
            textbox1.Visibility = Visibility.Visible;
        }
    }
}
