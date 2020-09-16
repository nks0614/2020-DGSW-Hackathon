using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DGM_windows
{
    class GetSchoolSchedule
    {
        public static string getSchedule()
        {
            SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\DrawingBoard\\2020-DGSW-Hackathon\\Window\\DGM_windows\\DGM_windows\\Schedule.mdf;Integrated Security=True");
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;
            string url = string.Format("http://kyungwon-server.kro.kr:8080/schedule?school_id=7240393&office_code=D10&date={0}", MainWindow.Today);

            int count = 0;

            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(string.Format("SELECT count(*) FROM Schedule where time = '{0}'", MainWindow.Today), connect))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }

                connect.Close();

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<scheduleInfo.Root>(json);

                scheduleInfo.Root outPut = result;

                count += outPut.data.schedules.Count;

                return string.Format("{0} +외 {1}개", outPut.data.schedules[0].name, count - 1);
            }
            catch
            {
                if(count == 0)
                {
                    return "오늘의 일정이 없습니다.";
                }
                else
                {
                    string data;

                    connect.Open();
                    using (SqlCommand command = new SqlCommand(string.Format("SELECT description FROM Schedule where time = '{0}'", MainWindow.Today), connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        data = reader.GetString(0);
                    }

                    connect.Close();
                    if(count == 1)
                    {
                        return data;
                    }
                    else
                    {
                        return data + string.Format(" +외 {0}개", count - 1);
                    }
                }
            }
        }
    }
}
