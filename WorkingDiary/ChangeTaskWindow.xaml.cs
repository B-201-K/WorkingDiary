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
    /// Логика взаимодействия для ChangeTaskWindow.xaml
    /// </summary>
    public partial class ChangeTaskWindow : Window
    {
        internal int Id { get; set; }
        public ChangeTaskWindow()
        {
            InitializeComponent();
            List<string> statuses = new() { "Создана", "В работе", "Приостановлена", "Выполнена" };
            TaskStatusComboBox.ItemsSource = statuses;
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            using (WorkersDbContext db = new())
            {
                WorkerTask taskForChange = db.WorkerTasks.Find(Id);
                taskForChange.TaskName = TaskNameTextBox.Text;
                taskForChange.TaskDescription = TaskDescTextBox.Text;
                taskForChange.TaskOwnerName = OwnerNameTextBox.Text;
                taskForChange.TaskOwnerSurname = OwnerSurnameTextBox.Text;


                taskForChange.TaskStatus = TaskStatusComboBox.Text;
                db.SaveChanges();
            }
            DialogResult = true;
        }
    }
}
