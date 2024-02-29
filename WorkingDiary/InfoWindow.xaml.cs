using Microsoft.EntityFrameworkCore;
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

namespace WorkingDiary
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
            
        }

        private void GetInfoButton_Click(object sender, RoutedEventArgs e)
        {

            using (WorkersDbContext workersDb = new())
            {
                var workersInfo = workersDb.Workers.OrderBy(w => w.WorkerId).ToList();
                Db_DataGrid.ItemsSource = workersInfo;
            }

        }

        private void GetWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            string login = "baev_ii";
            string password = "12345";
            using (WorkersDbContext workersDb = new())
            {
                
                var value = workersDb.Workers.Where(w=>w.WorkerLogin.Equals("gdsgsgs") && w.WorkerPassword.Equals("dadad")).Select(w=>w.WorkerId);
                WorkerLabel.Content = value.ToString();
                
                
                
            }
        }

        private void ClearBigIntButton_Click(object sender, RoutedEventArgs e)
        {
            using (WorkersDbContext workersDb = new())
            {
                workersDb.Database.ExecuteSqlRaw(@"Alter sequence worker_worker_id_seq restart with 1");
                workersDb.SaveChanges();
            }
        }

        private void DeleteBaseButton_Click(object sender, RoutedEventArgs e)
        {
            using (WorkersDbContext workersDb = new())
            {
                workersDb.Database.ExecuteSqlRaw(@"Delete from worker");
                workersDb.SaveChanges();
            }
        }
    }
}
