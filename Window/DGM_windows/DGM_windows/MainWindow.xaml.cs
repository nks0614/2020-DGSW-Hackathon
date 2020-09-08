using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;

namespace DGM_windows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        const string APPID = "";
        string citiName = "Colombo";
        public MainWindow()
        {
            InitializeComponent();
            getWeather();
        }

        void getWeather()
        {
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?lat=35.663053&lon=128.413726&APPID=09c8dfc52b7541d33c528d09a55e2c18&units=metric");

            var json = web.DownloadString(url);

            var result = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

            WeatherInfo.Root outPut = result;

            api_test.Text = string.Format("{0}", outPut.name);
                api_test_Copy.Text = string.Format("{0}", outPut.sys.country);
            api_test_Copy1.Text = string.Format("{0} \u00B0" + "C", outPut.main.temp);
            api_test_Copy2.Text = string.Format("{0}", outPut.weather[0].main);

            url = string.Format("http://kyungwon-server.kro.kr:8080/meals?school_id=7240393&office_code=D10&date=20200908");

            json = web.DownloadString(url);

            url = string.Format("http://kyungwon-server.kro.kr:8080/search?school_name=대구소프트");

            json = web.DownloadString(url);
        }
    }
}
