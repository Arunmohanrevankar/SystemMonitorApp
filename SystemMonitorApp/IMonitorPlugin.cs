using System;
using System.Collections.Generic;
using System.Text;

namespace SystemMonitorApp
{
    public interface IMonitorPlugin
    {
        void OnUpdate(float cpuUsage, float ramUsed, float ramTotal, float diskUsed, float diskTotal);
    }

}
