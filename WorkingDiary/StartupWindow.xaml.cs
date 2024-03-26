using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        Worker checkWorker { get; set; }
        public StartupWindow()
        {
            InitializeComponent();

        }
        

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {

            LogInWindow logInWindow = new LogInWindow();

            if (logInWindow.ShowDialog() == true)
            {
               
                int id = GetWorkerId(logInWindow.Login, logInWindow.Password);
                using (WorkersDbContext db = new())
                {
                    checkWorker = db.Workers.Find(id);
                    if (checkWorker.WorkerDepartment.Equals("Director")) 
                    {
                        DirectorWindow directorWindow = new();

                        logInWindow.Dispose();
                        directorWindow.Director = checkWorker;
                        directorWindow.UsernameLabel.Content = directorWindow.Director.WorkerName;
                        directorWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MainWindow mainWindow = new();
                        mainWindow.CurrentWorker = GetWorker(id);
                        mainWindow.UsernameLabel.Content = mainWindow.CurrentWorker.WorkerName;

                        mainWindow.Show();
                        this.Close();
                    }
                }
             
                
              
               

            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            if (registrationWindow.ShowDialog() == true)
            {
                MessageBox.Show("Регистрация прошла успешно");
                registrationWindow.Close();
            }
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new();

            infoWindow.Show();
        }
        int GetWorkerId(string login, string password)
         {
             using (WorkersDbContext workersDb = new())
                 return workersDb.Workers.Where(w => w.WorkerLogin.Equals(login) && w.WorkerPassword.Equals(password)).Select(w => w.WorkerId).FirstOrDefault();
         }
        Worker GetWorker(int id)
         {
             using (WorkersDbContext workersDb = new())
             {
                 return workersDb.Workers.Find(id);
             }
         }
    }
}
