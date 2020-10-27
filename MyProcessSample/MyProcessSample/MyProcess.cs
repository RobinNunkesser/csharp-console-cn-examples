using System;
using System.Diagnostics;

namespace MyProcessSample
{
    public class MyProcess
    {
        public void BindToRunningProcesses()
        {
            // Get the current process.
            var currentProcess = Process.GetCurrentProcess();
            Console.WriteLine(
                $"{currentProcess.ProcessName} ({currentProcess.Id})");
            // Get all processes running on the local computer.
            var localAll = Process.GetProcesses();

            // Get all instances of dotnet running on the local computer.
            // This will return an empty array if dotnet isn't running.
            var localByName = Process.GetProcessesByName("dotnet");

            // Get a process on the local computer, using the process id.
            // This will throw an exception if there is no such process.
            var localById = Process.GetProcessById(1);
        }
    }
}