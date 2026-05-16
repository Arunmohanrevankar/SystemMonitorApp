using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace SystemMonitorApp
{
    public class ApiPlugin : IMonitorPlugin
    {
        private readonly string apiUrl;
        private readonly HttpClient client = new HttpClient();

        public ApiPlugin(string url)
        {
            apiUrl = url;
        }

        public async void OnUpdate(float cpuUsage, float ramUsed, float ramTotal, float diskUsed, float diskTotal)
        {
            var payload = new
            {
                cpu = cpuUsage,
                ram_used = ramUsed * 1024,   // convert GB to MB if needed
                disk_used = diskUsed * 1024  // convert GB to MB if needed
            };

            string json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(apiUrl, content);
        }
    }
}
