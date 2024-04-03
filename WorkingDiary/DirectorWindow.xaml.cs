using Microsoft.VisualBasic;
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
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        internal Worker CurrentWorker { get; set; }
        internal Worker Director { get; set; }
        WorkerTask TaskForAdd { get; set; }
        public DirectorWindow()
        {
            InitializeComponent();
            
        }

        private void ChooseWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseWorkerWindow chooseWorkerWindow = new();
            chooseWorkerWindow.ShowDialog();
            if (chooseWorkerWindow.DialogResult == true) 
            {

                CurrentWorker = chooseWorkerWindow.ChosenWorker;

            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            DirectorAddTask directorAddTask = new DirectorAddTask();
            directorAddTask.ShowDialog();
            
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

        private void ShowAllTasksButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentWorker == null)
            {
                using (WorkersDbContext db = new())
                {
                    DataFromDb.ItemsSource = db.WorkerTasks.Where(t => t.TaskOwnerName.Equals(Director.WorkerName)).ToList();
                }

            }
            else 
            {
                using (WorkersDbContext db = new())
                {

                    DataFromDb.ItemsSource = db.WorkerTasks.Where(t => t.TaskOwnerName.Equals(CurrentWorker.WorkerName)).ToList();

                }
            }
           
        }

        private void DropWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentWorker = null;
        }

        private void ChangeTaskButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerTask taskForChange = DataFromDb.SelectedItem as WorkerTask;
            ChangeTaskWindow changeTaskWindow = new();
            changeTaskWindow.TaskNameTextBox.Text = taskForChange.TaskName;
            changeTaskWindow.TaskDescTextBox.Text = taskForChange.TaskDescription;
            changeTaskWindow.OwnerNameTextBox.Text = taskForChange.TaskOwnerName;
            changeTaskWindow.OwnerSurnameTextBox.Text = taskForChange.TaskOwnerSurname;
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
                
                DataFromDb.ItemsSource = workersDb.WorkerTasks.Where(t => t.TaskOwnerName.Equals(CurrentWorker.WorkerName)).OrderBy(t => t.TaskId).ToList();

            }
        }
    }
}
