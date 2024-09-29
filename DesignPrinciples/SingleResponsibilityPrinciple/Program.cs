using Google.Protobuf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {

            //var s = "20240906145038";
            //DateTime b = DateTime.ParseExact(s.ToString(), "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            //var aa = b.Date.ToString("yyyy-MM-dd");
            //var ss = b.TimeOfDay.ToString();
            //var jsonText = "[{'T_SW_Patient_Gender': 'O', 'T_SW_Patient_Age': '100D', 'T_SW_Patient_Weight': 0, 'T_SW_Patient_Size': 0, 'T_SW_Patient_Name': 'RatB', 'LSI_Species': 'None', 'T_SW_PatientID': '1.2.156.112605.172056109220623.240906145047.1.17344.676658', 'T_SW_Patient_Birth_date': '20230711'}]";
            //var res = JArray.Parse(jsonText);
            //res.Children().ToList().ForEach(item =>
            //{
            //    var a = item.Value<string>("T_SW_Patient_Gender");
            //});

            //var obj = new JArray();
            //var token1 = new JObject();
            //token1.Add("T_SW_Patient_Gender", "0");

            //var token2 = new JObject();
            //token2.Add("T_SW_Patient_Gender", "1");

            //obj.Add(token1);
            //obj.Add(token2);

            //Console.WriteLine(obj.ToString());
            //TestDriveInfo();
            //Test test = new Test();
            ////获取文件夹所有目录
            ////获取当前程序所在的文件路径
            //String rootPath = @"E:\";
            ////string parentPath = Directory.GetParent(rootPath).FullName;//上级目录
            ////string topPath = Directory.GetParent(parentPath).FullName;//上上级目录
            //StreamWriter sw = null;
            //Console.WriteLine(System.DateTime.Now.ToString());
            //try
            //{
            //    //创建输出流，将得到文件名子目录名保存到txt中
            //    sw = new StreamWriter(new FileStream("fileList.txt", FileMode.Append));
            //    sw.WriteLine("根目录：" + rootPath);
            //    test.getDirectory(sw, rootPath, 2,2);
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    if (sw != null)
            //    {
            //        sw.Close();
            //        Console.WriteLine("完成"+ System.DateTime.Now.ToString());
            //    }
            //}

            RunCmd("ping 10.5.80.43");
        }

        public static void RunCmd(string cmd)
        {
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.WorkingDirectory = workingDir;
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
                        Console.WriteLine("print:" + output);
                    }

                }
            });
            p.WaitForExit();
        }

        public static void TestDriveInfo()
        {
            DriveInfo[] allDirves = DriveInfo.GetDrives();
            //检索计算机上的所有逻辑驱动器名称
            foreach (DriveInfo item in allDirves)
            {
                //Fixed 硬盘
                //Removable 可移动存储设备，如软盘驱动器或USB闪存驱动器。
                Console.Write(item.Name + "---" + item.DriveType);
                if (item.IsReady)
                {
                    Console.Write(",容量：" + item.TotalSize + "，可用空间大小：" + item.TotalFreeSpace);
                }
                else
                {
                    Console.Write("没有就绪");
                }
                Console.WriteLine();
            }
        }
    }

    public class Test
    {
        public void getFileName(StreamWriter sw, string path, int indent)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (FileInfo f in root.GetFiles())
            {
                for (int i = 0; i < indent; i++)
                {
                    sw.Write("  ");
                }
                sw.WriteLine(f.Name);
            }
        }

        /// <summary>
        /// 获得指定路径下所有子目录名
        /// </summary>
        /// <param name="sw">文件写入流</param>
        /// <param name="path">文件夹路径</param>
        /// <param name="indent">输出时的缩进量</param>
        public void getDirectory(StreamWriter sw, string path, int indent, int depth=0)
        {
            //getFileName(sw, path, indent);
            DirectoryInfo root = new DirectoryInfo(path);
            var directories = root.GetDirectories().ToList();
            directories = directories.Where(t =>
                (t.Attributes & (FileAttributes.Hidden | FileAttributes.System)) !=
                (FileAttributes.Hidden | FileAttributes.System)).ToList();
            directories = directories.OrderBy(t => t.Name).ToList();
            if (depth != 0)
            {
                foreach (DirectoryInfo d in directories)
                {
                    for (int i = 0; i < indent; i++)
                    {
                        sw.Write("  ");
                    }
                    sw.WriteLine("文件夹：" + d.Name);
                    getDirectory(sw, d.FullName, indent + 2, depth - 1);
                    sw.WriteLine();
                }
            }
        }
    }


    public class MyDirectoryInfo
    {
        public string DirectoryName { get; set; }

        public MyDirectoryInfo directoryInfo { get; set; }
    }
}
