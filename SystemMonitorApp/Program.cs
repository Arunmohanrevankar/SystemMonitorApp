using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;
using SystemMonitorApp;

class Program
{
    static void Main(string[] args)
    {
        int interval = 5; // seconds

        // Load plugins
        var plugins = new IMonitorPlugin[]
        {
            new ConsolePlugin(),
            new FileLoggerPlugin(),
            //new ApiPlugin("http://localhost:5000/api/monitor") // replace with your API URL
        };

        // CPU counter
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        cpuCounter.NextValue();
        Thread.Sleep(1000);
        while (true)
        {
            Console.Clear();

            // --- CPU Usage ---
            float cpuUsage = cpuCounter.NextValue();

            // --- RAM Usage ---
            var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem");
            ulong total = 0, free = 0;
            foreach (ManagementObject item in searcher.Get())
            {
                total = Convert.ToUInt64(item["TotalVisibleMemorySize"]) * 1024UL;
                free = Convert.ToUInt64(item["FreePhysicalMemory"]) * 1024UL;
            }
            ulong used = total - free;

            float ramUsedGB = used / (1024f * 1024f * 1024f);
            float ramTotalGB = total / (1024f * 1024f * 1024f);

            // --- Disk Usage (C:) ---
            DriveInfo driveC = new DriveInfo("C");
            long totalDisk = driveC.TotalSize;
            long freeDisk = driveC.AvailableFreeSpace;
            long usedDisk = totalDisk - freeDisk;

            float diskUsedGB = usedDisk / (1024f * 1024f * 1024f);
            float diskTotalGB = totalDisk / (1024f * 1024f * 1024f);

            // Notify all plugins
            foreach (var plugin in plugins)
            {
                plugin.OnUpdate(cpuUsage, ramUsedGB, ramTotalGB, diskUsedGB, diskTotalGB);
            }

            Console.WriteLine($"\nRefreshing in {interval} seconds...");
            Thread.Sleep(interval * 1000);
        }
    }
}
