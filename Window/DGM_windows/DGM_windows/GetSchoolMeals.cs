using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DGM_windows
{
    class GetSchoolMeals
    {
        
        static string targetURL = string.Format("http://kyungwon-server.kro.kr:8080/meals?school_id=7240393&office_code=D10&date={0}", MainWindow.Today);

        public static string[] schoolMeals(string SelectDate)
        {
            targetURL = string.Format("http://kyungwon-server.kro.kr:8080/meals?school_id=7240393&office_code=D10&date={0}", SelectDate);

            //1.WebClient 클래스 활용
            string webClientResult = callWebClient();

            if(webClientResult.Equals("404") == true)
            {
                return new string[] { "급식정보가 존재하지 않습니다.", "급식정보가 존재하지 않습니다.", "급식정보가 존재하지 않습니다." };
            }

            var r = JObject.Parse(webClientResult);

            var list = r["data"];

            //Console.WriteLine(r + Environment.NewLine + list);
            string[][] returnResult = new string[][] { list["meals"][0].ToString().Replace("<br/>", "$").Split('$'), list["meals"][1].ToString().Replace("<br/>", "$").Split('$'), list["meals"][2].ToString().Replace("<br/>", "$").Split('$') };   //0은 아침, 1은 점심, 2는 저녁, br태그 삭제 후 줄바꿈

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < returnResult[i].Length; j++)
                {
                    returnResult[i][j] = returnResult[i][j].Split(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' })[0];
                }
            }

            string[] meals = { "", "", "" };

            for (int i = 0; i < 3; i++)
            {
                meals[i] = "";
                for (int j = 0; j < returnResult[i].Length; j++)
                {
                    meals[i] += returnResult[i][j];
                    meals[i] += Environment.NewLine;
                }
                if (meals[i].Equals(Environment.NewLine)) meals[i] = "급식정보가 존재하지 않습니다.";
            }

            return meals;
        }
        public static string callWebClient()
        {
            string result = string.Empty;
            try
            {
                WebClient client = new WebClient();

                //특정 요청 헤더값을 추가해준다. 
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                using (Stream data = client.OpenRead(targetURL))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string s = reader.ReadToEnd();
                        result = s;

                        reader.Close();
                        data.Close();
                    }
                }

            }
            catch (Exception e)
            {
                //통신 실패시 처리로직
                Console.WriteLine(e.ToString());
                return "404";
            }
            return result;
        }
        public static string callWebRequest()
        {
            string responseFromServer = string.Empty;

            try
            {

                WebRequest request = WebRequest.Create(targetURL);
                request.Method = "GET";
                request.ContentType = "application/json";

                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    responseFromServer = reader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return responseFromServer;
        }
    }
}
