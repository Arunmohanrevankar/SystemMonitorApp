SystemMonitorApp
The project is a Console Application that monitors system resources (CPU usage, RAM usage, and Disk usage). It is designed to run on Windows only, since it relies on Windows‑specific APIs (System.Management and PerformanceCounter).

1 Clone the repository
git clone https://github.com/Arunmohanrevankar/SystemMonitorApp.git
cd SystemMonitorApp
2 Install required packages 
dotnet add package System.Management
dotnet add package System.Diagnostics.PerformanceCounter
3 Build the project
dotnet build
4 Run the project
dotnet run
By default, the app refreshes every 5 seconds. You’ll see CPU, RAM, and Disk usage printed to the console.
A log file named monitor_log.txt will be created in the project folder.
If the API plugin is enabled but **no API URL is configured**, JSON payloads will be logged locally instead of posted.
