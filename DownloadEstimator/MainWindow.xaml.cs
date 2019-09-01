using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DownloadEstimator;

namespace DownloadEstimator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private IEnumerable<SimpleProcess> simpleProcesses; 
        public MainWindow()
        {
            InitializeComponent();
            InitProcessList();
            InitDoubleClickAction();
        }

        private void InitProcessList()
        {
            var processes = Process.GetProcesses();
            ProcessList.DataContext = new SimpleProcess();
            simpleProcesses = processes.Select(p => new SimpleProcess() {Name = p.ProcessName, PID = p.Id, WindowTitle = p.MainWindowTitle}).OrderBy(p => p.Name);
            ProcessList.ItemsSource = simpleProcesses.Where(p => p.Name.ToLower().Contains(Filter.Text.ToLower()));
        }
        
        private void InitDoubleClickAction()
        {
            ProcessList.MouseDoubleClick += ProcessListOnMouseDoubleClick;
        }

        private void ProcessListOnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var downloadEstimationWindow = new DownloadEstimation(((SimpleProcess)ProcessList.SelectedItem).PID);
            downloadEstimationWindow.Show();
        }

        private void Filter_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ProcessList.ItemsSource = simpleProcesses.Where(p => p.Name.ToLower().Contains(Filter.Text.ToLower()));
        }

        private void Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            InitProcessList();
        }
    }
}