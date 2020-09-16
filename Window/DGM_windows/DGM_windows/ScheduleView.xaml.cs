using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace DGM_windows
{
    /// <summary>
    /// ScheduleView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ScheduleView : Window
    {
        public ScheduleView()
        {
            InitializeComponent();
            SelectDate.SelectedDate = DateTime.Now;

            SetSchedule(MainWindow.Today);
        }
        private void SetSchedule(string SelectDay)
        {
            ScheduleViewContent.Children.Clear();
            List<getScheduleInfo.ScheduleInfo> FixValue = GetSchoolScheduleContent.getFixScheduleContent(SelectDay);
            List<getScheduleInfo.ScheduleInfo> DynamicValue = GetSchoolScheduleContent.getDynamicScheduleContent(SelectDay);
            if ((FixValue.Count + DynamicValue.Count) == 0)
            {
                ScheduleViewContent.Children.Add(MakeTextBox("1", "일정이 없습니다.", true));
            }
            else
            {
                foreach (getScheduleInfo.ScheduleInfo value in FixValue)
                {
                    ScheduleViewContent.Children.Add(MakeTextBox(value.id, value.description, true));
                }
                foreach (getScheduleInfo.ScheduleInfo value in DynamicValue)
                {
                    ScheduleViewContent.Children.Add(MakeTextBox(value.id, value.description, false));
                }
            }
        }

        private Grid MakeTextBox(string id, string description, bool isFix)
        {
            Grid grid = new Grid();

            Rectangle rectangle = new Rectangle();
            rectangle.Fill = Brushes.White;
            rectangle.Stroke = Brushes.Black;
            rectangle.RadiusX = 5;
            rectangle.RadiusY = 5;
            rectangle.HorizontalAlignment = HorizontalAlignment.Center;
            rectangle.VerticalAlignment = VerticalAlignment.Center;
            rectangle.Height = 50;
            rectangle.Width = 380;

            Label testText = new Label();
            testText.Background = Brushes.Transparent;
            testText.Height = 50;
            testText.Width = 380;
            testText.FontSize = 20;
            testText.Content = description;
            testText.BorderBrush = Brushes.Transparent;
            testText.VerticalContentAlignment = VerticalAlignment.Center;
            testText.HorizontalContentAlignment = HorizontalAlignment.Center;
            testText.VerticalAlignment = VerticalAlignment.Center;
            testText.HorizontalAlignment = HorizontalAlignment.Center;

            grid.Name = "id" + id;
            grid.Margin = new Thickness(0, 0, 0, 5);
            grid.Children.Add(rectangle);
            grid.Children.Add(testText);
            if(isFix == false)
            {
                grid.MouseDown += TextView_MouseDown;
            }
            else
            {
                rectangle.Fill = Brushes.LightGray;
            }

            return grid;
        }

        private void Schedule_Closed(object sender, EventArgs e)
        {
            MainWindow.IsClose = 1;
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void TextView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selectingName = sender as DependencyObject;
            string name = selectingName.GetValue(Grid.NameProperty) as string;
            string description;

            Memo memo = new Memo();
            memo.SaveButtonText.Content = "수정";
            memo.id.Content = name;
            SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\DrawingBoard\\2020-DGSW-Hackathon\\Window\\DGM_windows\\DGM_windows\\Schedule.mdf;Integrated Security=True");

            connect.Open();
            using (SqlCommand command = new SqlCommand(string.Format("SELECT description FROM Schedule where id = '{0}'", name.Replace("id","")), connect))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                description = reader.GetString(0);
            }
            connect.Close();

            memo.SaveDate.SelectedDate = SelectDate.SelectedDate;

            memo.SaveDescription.Text = description;
            memo.Closed += Memo_Closed;
            memo.ShowDialog();
        }

        private void Memo_Closed(object sender, EventArgs e)
        {
            SetSchedule(SelectDate.SelectedDate.Value.ToString().Replace("-", "").Split(' ')[0]);
        }

        private void SelectDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetSchedule(SelectDate.SelectedDate.Value.ToString().Replace("-", "").Split(' ')[0]);
        }
    }
}
