using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public List<WorkerTask> Information { get; set; }
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
                Information = workersDb.WorkerTasks.Where(t => t.TaskOwnerName.Equals(CurrentWorker.WorkerName)).ToList();
                DataFromDb.ItemsSource = Information;
                
            }
        }

        

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new();
            addTaskWindow.ShowDialog();

            

            using (WorkersDbContext db = new()) 
            {
                WorkerTask addedTask = new()
                {
                    TaskName = addTaskWindow.TaskNameTextBox.Text,
                    TaskDescription = addTaskWindow.TaskDescTextBox.Text,
                    TaskOwnerName = CurrentWorker.WorkerName,
                    TaskOwnerSurname = CurrentWorker.WorkerSurname,
                    TaskStatus = "Создана"
                };
                db.Add(addedTask);
                db.SaveChanges();
                Console.WriteLine("Задача сохранена");
                
            }
            
        }

        private void ChangeTaskButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerTask taskForChange = DataFromDb.SelectedItem as WorkerTask;
            ChangeTaskWindow changeTaskWindow = new();
            changeTaskWindow.TaskNameTextBox.Text = taskForChange.TaskName;
            changeTaskWindow.TaskDescTextBox.Text = taskForChange.TaskDescription;
            changeTaskWindow.OwnerNameTextBox.Text = taskForChange.TaskOwnerName;
            changeTaskWindow.OwnerNameTextBox.IsEnabled= false;
            changeTaskWindow.OwnerSurnameTextBox.Text = taskForChange.TaskOwnerSurname;
            changeTaskWindow.OwnerSurnameTextBox.IsEnabled = false;
            changeTaskWindow.DateStartTextBox.Text = taskForChange.TaskCreateDate.ToString();
            changeTaskWindow.DateEndTextBox.Text = taskForChange.TaskEndDate.ToString();
            changeTaskWindow.TaskStatusComboBox.Text = taskForChange.TaskStatus;
            changeTaskWindow.Id = taskForChange.TaskId;
            changeTaskWindow.ShowDialog();

            Refresh();
        }
        void Refresh() 
        {
            using (WorkersDbContext workersDb = new())
            {
                Information = workersDb.WorkerTasks.Where(t => t.TaskOwnerName.Equals(CurrentWorker.WorkerName)).OrderBy(t=>t.TaskId).ToList();
                DataFromDb.ItemsSource = Information;

            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerTask taskForDelete = DataFromDb.SelectedItem as WorkerTask;

            using (WorkersDbContext db = new()) 
            {
                db.Remove(taskForDelete);
                db.SaveChanges();
            }
            Refresh();
        }
    }
}
