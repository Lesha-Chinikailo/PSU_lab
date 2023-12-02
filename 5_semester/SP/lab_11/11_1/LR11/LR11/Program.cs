using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "logs.log";
        FileStream fileStream = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);

        Process mainProcess = new Process();
        mainProcess.StartInfo.FileName = "notepad.exe";
        mainProcess.Start();

        Process childProcess = new Process();
        childProcess.StartInfo.FileName = "ChildApp.exe";
        childProcess.StartInfo.Arguments = $"{mainProcess.Id} {fileStream.Handle}";
        fileStream.Close();
        childProcess.Start();
        childProcess.WaitForExit();

        fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            mainProcess.Kill();
            writer.WriteLine("The managed process has terminated");
            writer.WriteLine("Is the control process completed?: " + childProcess.HasExited);
            writer.WriteLine("Is the control process completed?: " + mainProcess.HasExited);
        }
    }
}