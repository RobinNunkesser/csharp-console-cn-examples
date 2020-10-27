using System;

namespace MyProcessSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProcess = new MyProcess();
            myProcess.BindToRunningProcesses();
        }
    }
}