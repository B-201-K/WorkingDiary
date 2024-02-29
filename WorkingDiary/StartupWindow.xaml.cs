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
    /// Логика взаимодействия для StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();

        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            
            LogInWindow logInWindow = new LogInWindow();
            
            if (logInWindow.ShowDialog() == true) 
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                this.Close();

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
    }
}
