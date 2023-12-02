using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static string filePath = "logs.log";
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Not enough arguments!");
            return;
        }

        int mainProcessId = int.Parse(args[0]);
        IntPtr logFileHandlePtr = new IntPtr(long.Parse(args[1]));

        
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            Process mainProcess = Process.GetProcessById(mainProcessId);

            writer.WriteLine($"The control process has started. Managed process {mainProcess.ProcessName}");
            writer.WriteLine($"Current priority: {mainProcess.PriorityClass}");


            Console.WriteLine("Select priority type:");
            Console.WriteLine("1. Idle");
            Console.WriteLine("2. BelowNormal");
            Console.WriteLine("3. AboveNormal");
            Console.WriteLine("4. High");

            int priorityChoice = int.Parse(Console.ReadLine());

            ProcessPriorityClass priorityClass = ProcessPriorityClass.Normal;

            switch (priorityChoice)
            {
                case 1:
                    priorityClass = ProcessPriorityClass.Idle;
                    break;
                case 2:
                    priorityClass = ProcessPriorityClass.BelowNormal;
                    break;
                case 3:
                    priorityClass = ProcessPriorityClass.AboveNormal;
                    break;
                case 4:
                    priorityClass = ProcessPriorityClass.High;
                    break;
                default:
                    Console.WriteLine("Wrong priority choice!");
                    break;
            }

            mainProcess.PriorityClass = priorityClass;

            writer.WriteLine($"Controlled process priority changed");
            writer.WriteLine($"Current priority: {mainProcess.PriorityClass}");
            writer.WriteLine("The control process is completed.");
        }
        Console.WriteLine("Logs saved successfully");
    }
}