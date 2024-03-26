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
    /// Логика взаимодействия для ChooseWorkerWindow.xaml
    /// </summary>
    public partial class ChooseWorkerWindow : Window
    {
        List<Worker> Workers { get; set; }
        internal Worker ChosenWorker { get; set; }
        
        public ChooseWorkerWindow()
        {
            InitializeComponent();
            using (WorkersDbContext db = new()) 
            {
                Workers = db.Workers.Where(w=>w.WorkerDepartment.Equals("IT")).ToList();
                List<string> workerNames = new();
                foreach (var w in Workers) 
                {
                    workerNames.Add($"{w.WorkerName} {w.WorkerSurname}");
                }
                WorkersListComboBox.ItemsSource = workerNames;
            }
        }

        private void ChooseWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            string[] nameSurname = WorkersListComboBox.Text.Split(' ');
            string chosenWorkerName = nameSurname[0];
            string chosenWorkerSurname = nameSurname[1];
            ChosenWorker = Workers.Where(w => w.WorkerName.Equals(chosenWorkerName)).FirstOrDefault();
/*
            using (WorkersDbContext db = new())
            {
                foreach (var w in Workers) { }
                var test = db.Workers.Where(w => w.WorkerName.Equals("Test") && w.Equals("Test")).Select(w => w).FirstOrDefault();
                var test2 = 1;
            }*/
            DialogResult = true;
        }
    }
}
