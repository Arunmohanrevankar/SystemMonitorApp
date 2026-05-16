using System;
using System.Collections.Generic;
using System.Text;

namespace SystemMonitorApp
{
    public class ConsolePlugin : IMonitorPlugin
    {
        public void OnUpdate(float cpuUsage, float ramUsed, float ramTotal, float diskUsed, float diskTotal)
        {
            Console.WriteLine($"CPU={cpuUsage:F2}% | RAM={ramUsed:F2}/{ramTotal:F2} GB | Disk={diskUsed:F2}/{diskTotal:F2} GB");
        }
    }
}
