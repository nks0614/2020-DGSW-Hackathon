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
    class GetSchoolScheduleContent
    {
        public static List<getScheduleInfo.ScheduleInfo> getFixScheduleContent(string SelectDate)
        {
            List<getScheduleInfo.ScheduleInfo> returnResult = new List<getScheduleInfo.ScheduleInfo>();
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;
            string url = string.Format("http://kyungwon-server.kro.kr:8080/schedule?school_id=7240393&office_code=D10&date={0}", SelectDate);

            try
            {
                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<scheduleInfo.Root>(json);

                scheduleInfo.Root outPut = result;

                foreach(scheduleInfo.schedules getValue in outPut.data.schedules)
                {
                    getScheduleInfo.ScheduleInfo value = new getScheduleInfo.ScheduleInfo();
                    value.id = -1;
                    value.description = getValue.name;
                    returnResult.Add(value);
                }

                return returnResult;
            }
            catch
            {
                return returnResult;
            }
        }
        public static List<getScheduleInfo.ScheduleInfo> getDynamicScheduleContent(string SelectDate)
        {
            List<getScheduleInfo.ScheduleInfo> returnResult = new List<getScheduleInfo.ScheduleInfo>();
            SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\DrawingBoard\\2020-DGSW-Hackathon\\Window\\DGM_windows\\DGM_windows\\Schedule.mdf;Integrated Security=True");
            
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(string.Format("SELECT Id,description FROM Schedule where time = '{0}'", SelectDate), connect))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        getScheduleInfo.ScheduleInfo value = new getScheduleInfo.ScheduleInfo();
                        value.id = Int32.Parse(reader["Id"].ToString());
                        value.description = reader["description"].ToString();
                        returnResult.Add(value);
                    }
                }

                connect.Close();

                return returnResult;
            }
            catch
            {
                return returnResult;
            }
        }
    }
}
