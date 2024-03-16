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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkingDiary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Worker CurrentWorker { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
            
            


        }

        

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            StartupWindow startupWindow = new StartupWindow();
            startupWindow.Show();
            this.Close();
        }

        private void ShowAllTasksButton_Click(object sender, RoutedEventArgs e)
        {
            using (WorkersDbContext workersDb = new()) 
            {
                var info = workersDb.WorkerTasks.Where(t => t.TaskOwnerName.Equals(CurrentWorker.WorkerName)).ToList();
                DataFromDb.ItemsSource = info;
            }
        }
    }
}
