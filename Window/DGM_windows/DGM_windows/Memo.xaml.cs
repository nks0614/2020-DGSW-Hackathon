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

        string count;

        public Memo()
        {
            InitializeComponent();
        }

        private void SaveButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

            connect.Open();

            using (SqlCommand command = new SqlCommand("SELECT description FROM Schedule where id = 0", connect))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    count = reader.GetString(0);
                }
            }

            MessageBox.Show(count);

            connect.Close();

            /*connect.Open();

            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Schedule (id, time, description) VALUES ({0},N'20030901',N'{1}')", count, SaveDescription.Text), connect);
            
            cmd.ExecuteNonQuery();

            connect.Close();*/

            this.Close();

        }

        private void Memo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.IsClose = 1;
        }
    }
}
