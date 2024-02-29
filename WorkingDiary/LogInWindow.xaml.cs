﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();

        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {


          
            if (CheckLogPass(Login, Password) > 0)
            {
                this.DialogResult = true;
            }


        }
        internal string Login
        {
            get { return LogInTextBox.Text; }
        }
        internal string Password
        {
            get { return PasswordTextBox.Text; }
        }

        int CheckLogPass(string login, string password)
        {
            using (WorkersDbContext workersDb = new())
            {
                if (workersDb.Workers.Any(w => w.WorkerLogin.Equals(login)))
                {
                    if (workersDb.Workers.Any(w => w.WorkerLogin.Equals(login) && w.WorkerPassword.Equals(password)))
                    {
                        int workerId = GetWorkerId(login, password);
                        return workerId;
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                        login = null;
                        password = null;
                        PasswordTextBox.Text = null;
                        return 0;
                    }
                }
                else 
                {
                    MessageBox.Show("Пользователь не найден");
                    login = null;
                    password = null;
                    PasswordTextBox.Text = null;
                    LogInTextBox.Text = null;
                    return 0;
                }


            }
        }
        int GetWorkerId(string login, string password)
        {
            using (WorkersDbContext workersDbContext = new())
            {

                /*Worker currWork = (from worker in workersDbContext.Workers
                                   where worker.WorkerLogin.Equals(Login) && worker.WorkerPassword.Equals(Password)
                                   select worker).ToList().First();*/
                int currWorkId = workersDbContext.Workers.Where(w => w.WorkerLogin.Equals(login) && w.WorkerPassword.Equals(password)).Select(w => w.WorkerId).FirstOrDefault();
                return currWorkId;

            }

        }
    }
}
