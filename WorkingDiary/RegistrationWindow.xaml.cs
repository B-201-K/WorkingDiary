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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }


        private async void RegButton_Click(object sender, RoutedEventArgs e)
        {

            if (CheckField())
            {
                Worker worker = new()
                {

                    WorkerName = NameTextBox.Text,
                    WorkerSurname = SurnameTextBox.Text,
                    WorkerLastname = LastnameTextBox.Text,
                    WorkerDepartment = DepartmentTextBox.Text,
                    WorkerLogin = LogInTextBox.Text,
                    WorkerPassword = PasswordTextBox.Text,

                };
                await Task.Run(() => WriteToBase(worker));
                this.DialogResult = true;
            }
            else 
            {
                MessageBox.Show("Ошибка");
            }
            






        }
        async Task WriteToBase(Worker worker)
        {
            using (WorkersDbContext db = new())
            {

                db.Workers.Add(worker);
                db.SaveChanges();
            }
        }


        bool CheckField()
        {
            bool flag = false;
            List<TextBox> fields = new()
            {
                NameTextBox,
                SurnameTextBox,
                LastnameTextBox,
                DepartmentTextBox,
                LogInTextBox,
                PasswordTextBox
            };
            foreach (TextBox field in fields)
            {

                if (String.IsNullOrWhiteSpace(field.Text))
                {
                    field.Text = "";
                    field.BorderBrush = Brushes.Red;
                    flag = false;
                }
                else 
                {
                    flag = true;
                }
                
            }
            return flag;

        }

    }
}
