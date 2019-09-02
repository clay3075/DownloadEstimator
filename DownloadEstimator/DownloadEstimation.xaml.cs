using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace DownloadEstimator
{
    public partial class DownloadEstimation : Window
    {
        private readonly PerformanceCounter _readByteSec;
        private DispatcherTimer _updateNetworkSpeedTimer;

        public DownloadEstimation(int pid)
        {
            InitializeComponent();
            var process = Process.GetProcessById(pid);
            _readByteSec = new PerformanceCounter("Process", "IO Read Bytes/sec", GetProcessInstanceName(process.Id));
            DownloadSizeInGB.Text = "0";
            DownloadSpeed.Content = "0";
            InitNetworkSpeedTimer();
        }
        
        private static string GetProcessInstanceName(int pid)
        {
            var cat = new PerformanceCounterCategory("Process");

            var instances = cat.GetInstanceNames();
            foreach (var instance in instances)
            {
                using (var cnt = new PerformanceCounter("Process",  
                    "ID Process", instance, true))
                {
                    var val = (int) cnt.RawValue;
                    if (val == pid)
                    {
                        return instance;
                    }
                }
            }
            throw new Exception("Could not find performance counter " + 
                                "instance name for current process. This is truly strange ...");
        }

        private void InitNetworkSpeedTimer()
        {
            _updateNetworkSpeedTimer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(500)};
            _updateNetworkSpeedTimer.Tick += UpdateNetworkSpeedTimerOnElapsed;
            _updateNetworkSpeedTimer.Start();
        }

        private void UpdateNetworkSpeedTimerOnElapsed(object sender, EventArgs e)
        {
            DownloadSpeed.Content = GetDownloadSpeed();
            if (DownloadSizeInGB.IsFocused) 
                return;
            
            DownloadSizeInGB.Text = GetNewDownloadSize();
            TimeRemaining.Content = GetTimeRemaining();
        }

        private string GetNewDownloadSize()
        {
            var downloadSize = new DownloadSize(DownloadSize.Type.GigaByte, double.Parse(DownloadSizeInGB.Text));
            var downloadSpeed = new DownloadSpeed(DownloadEstimator.DownloadSpeed.Type.Mbps, double.Parse(DownloadSpeed.Content.ToString()));

            return
                $"{new DownloadSize(DownloadSize.Type.MegaBit, downloadSize.MegaBits - (downloadSpeed.Mbps * 0.5)).GigaBytes:F2}";
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TimeRemaining.Content = GetTimeRemaining();
        }

        private string GetTimeRemaining()
        {
            if (DownloadSpeed.Content == null || string.IsNullOrEmpty(DownloadSizeInGB.Text))
                return "";
            
            var downloadSize = new DownloadSize(DownloadSize.Type.GigaByte, double.Parse(DownloadSizeInGB.Text));
            var downloadSpeed = new DownloadSpeed(DownloadEstimator.DownloadSpeed.Type.Mbps,double.Parse((string)DownloadSpeed.Content));
            if (Math.Abs(downloadSpeed.BitsPerSecond) < .001)
                return "0.00";
            
            var timeRemaining = DownloadCalculations.GetTimeRemaining(downloadSpeed, downloadSize);

            return $"{timeRemaining:F2}";
        }

        private string GetDownloadSpeed()
        {
            var downloadSpeed = DownloadCalculations.GetProcessDownloadSpeed(_readByteSec);
            
            return $"{downloadSpeed.Mbps:F2}";
        }

        private void DownloadSizeInGB_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) 
                return;
            
            MainPanel.Focusable = true;
            MainPanel.Focus();
        }
    }
}