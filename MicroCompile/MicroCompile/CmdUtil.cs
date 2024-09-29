using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCompile
{
    public static class CmdUtil
    {
        public static void RunCmd(string cmd,string workingDir)
        {
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = workingDir;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.AutoFlush = true;
            Task.Run(() =>
            {
                while (true)
                {
                    string output = p.StandardOutput.ReadLine();
                    if (!string.IsNullOrEmpty(output))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(output);
                    }
                }
            });
            p.WaitForExit();
        }
    }
}
