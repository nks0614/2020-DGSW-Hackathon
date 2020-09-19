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
    /// Memo.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Memo : Window
    {
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\DrawingBoard\\2020-DGSW-Hackathon\\Window\\DGM_windows\\DGM_windows\\Schedule.mdf;Integrated Security=True");

        int count;

        public Memo()
        {
            InitializeComponent();
            SaveDate.SelectedDate = DateTime.Now;
        }

        private void SaveButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SaveButtonText.Content.ToString().Equals("저장"))
            {
                int id = 0;
                try
                {
                    connect.Open();
                    using (SqlCommand command = new SqlCommand("SELECT id FROM Schedule", connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                    }
                    id = count + 1;
                    connect.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee + " : code 3");
                }

                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Schedule (id, time, description) VALUES ({0},N'{1}',N'{2}')", id, SaveDate.SelectedDate.Value.ToString().Replace("-", "").Split(' ')[0], SaveDescription.Text), connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee + " : code 4");
                }

                this.Close();
            }
            else if(SaveButtonText.Content.ToString().Equals("수정"))
            {
                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("UPDATE Schedule SET description = N'{0}', time = N'{1}' WHERE id = {2}", SaveDescription.Text, SaveDate.SelectedDate.Value.ToString().Replace("-", "").Split(' ')[0], id.Content.ToString().Replace("id", "")), connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee + " : code 5");
                }

                this.Close();
            }
        }

        private void DeleteButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SaveButtonText.Content.ToString().Equals("저장"))
            {
                this.Close();
            }
            else if (SaveButtonText.Content.ToString().Equals("수정"))
            {
                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("DELETE From Schedule WHERE id = {0}", id.Content.ToString().Replace("id", "")), connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee + " : code 6");
                }

                this.Close();
            }
        }
        private void Memo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.IsClose = 1;
            ScheduleView.IsClose = 1;
        }

    }
}
