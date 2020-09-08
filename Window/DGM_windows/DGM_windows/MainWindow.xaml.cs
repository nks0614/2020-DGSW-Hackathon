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


namespace DGM_windows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public static string Today = DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString("00") + DateTime.Now.Date.Day.ToString("00");
        public MainWindow()
        {
            InitializeComponent();

            string[] getSchoolWeather = GetSchoolWeather.getWeather();

            api_test.Content = getSchoolWeather[0];
            api_test_Copy.Content = getSchoolWeather[1];
            api_test_Copy1.Content = getSchoolWeather[2];
            api_test_Copy2.Content = getSchoolWeather[3];

            string[] getSchoolMeals = GetSchoolMeals.schoolMeals();

            meal1.Content = getSchoolMeals[0];
            meal2.Content = getSchoolMeals[1];
            meal3.Content = getSchoolMeals[2];

            string[] getSchoolSchedule = GetSchoolSchedule.getSchedule();

            sche.Content = getSchoolSchedule[0];



            //string url = string.Format("http://api.openweathermap.org/data/2.5/weather?lat=35.663053&lon=128.413726&APPID=09c8dfc52b7541d33c528d09a55e2c18&units=metric");

            //var json = web.DownloadString(url);


            //string url = string.Format("http://kyungwon-server.kro.kr:8080/meals?school_id=7240393&office_code=d10&date=20200908");

            //var json = web.downloadstring(url);



            //string url = string.format("http://kyungwon-server.kro.kr:8080/schedule?school_id=7240393&office_code=d10&date=20200912");

            //var json = web.downloadstring(url);
        }




    }
}
