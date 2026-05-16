using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SystemMonitorApp
{
    public class FileLoggerPlugin : IMonitorPlugin
    {
        private string logFile = "monitor_log.txt";

        public void OnUpdate(float cpuUsage, float ramUsed, float ramTotal, float diskUsed, float diskTotal)
        {
            string logEntry = $"{DateTime.Now}: CPU={cpuUsage:F2}% | RAM={ramUsed}/{ramTotal} GB | Disk={diskUsed}/{diskTotal} GB";
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
        }
    }
}
