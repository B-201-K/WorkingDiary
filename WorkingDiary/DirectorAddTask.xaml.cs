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
    /// Логика взаимодействия для DirectorAddTask.xaml
    /// </summary>
    public partial class DirectorAddTask : Window
    {

        public DirectorAddTask()
        {
            InitializeComponent();
            List<string> statuses = new() { "Создана", "В работе", "Приостановлена", "Выполнена" };
            TaskStatusComboBox.ItemsSource = statuses;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            using (WorkersDbContext db = new())
            {
                WorkerTask addedTask = new();
                addedTask.TaskName = TaskNameTextBox.Text;
                addedTask.TaskDescription = TaskDescTextBox.Text;
                addedTask.TaskOwnerName = OwnerNameTextBox.Text;
                addedTask.TaskOwnerSurname = OwnerSurnameTextBox.Text;
                addedTask.TaskStatus = TaskStatusComboBox.Text;
                db.Add(addedTask);
                db.SaveChanges();
            }
            MessageBox.Show("Задача успешно создана");
            this.Close();
        }
    }
}
