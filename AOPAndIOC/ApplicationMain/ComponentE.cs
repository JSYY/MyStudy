using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationMain
{
    /// <summary>
    /// 文件流
    /// </summary>
    public interface IComponentE
    {
        void CopySingleFile(string sourceFile, string targetFile);
        void CopyFolder(string sourcePath, string targetPath,bool deleteSourceFolder=false);
    }

    [Component]
    public class ComponentE:IComponentE,IDisposable
    {
        private int bufferSize = 1024*1024;
        private long alreadyTransferData = 0;
        private long alreadyTransferDataEx = 0;
        private long totalSize = 0;
        private bool disposedValue;
        private readonly Timer _timer;
        private List<string> pathList;
        private List<string> directoryList;
        private DateTime startTime;

        public ComponentE()
        {
            _timer = new Timer(state => CalculateVelocityAndRemainingTimeEx());
        }

        public void CopyFolder(string sourcePath, string targetPath, bool deleteSourceFolder = false)
        {
            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine("cannot find sourcePath:{0}",new object[] { sourcePath });
                return;
            }
            //开始初始化文件与文件夹相关信息
            Init(sourcePath);
            _timer.Change(0, 1000);
            pathList.ForEach(item =>
            {
                var path = item.Replace(sourcePath, targetPath);
                CreateFolder(path);
                CopyFile(item, path);
            });
            _timer.Change(Timeout.Infinite, 0);
            if (deleteSourceFolder)
            {
                DeleteSorrceFolder(sourcePath);
            }
        }
        /// <summary>
        /// 通过统计到的已写数据与总数据对比计算进度
        /// </summary>
        private void CalculateVelocityAndRemainingTime()
        {
            var v = (alreadyTransferData / (1024 * 1024)) / (DateTime.Now - startTime).TotalSeconds;
            Console.WriteLine("current velocity:"+Math.Round(v,1)+"M/s");
            if (v != 0)
            {
                var remainingTime = ((totalSize - alreadyTransferData )/ (1024 * 1024)) / v;
                Console.WriteLine("remainingTime:" + sec_to_hms(remainingTime));
            }
            var percent= ((float)alreadyTransferData / (1024 * 1024) )/ ((float)totalSize / (1024 * 1024));
            Console.WriteLine("current process:"+ Math.Round(percent,2)*100+"%");
        }

        /// <summary>
        /// 通过轮询目标文件夹下的数据大小与实际大小进行比较计算进度
        /// </summary>
        private void CalculateVelocityAndRemainingTimeEx()
        {
            alreadyTransferDataEx = 0;
            getDirectoryEx(@"E:\target");
            var v = (alreadyTransferDataEx / (1024 * 1024)) / (DateTime.Now - startTime).TotalSeconds;
            Console.WriteLine("current velocity:" + Math.Round(v, 1) + "M/s");
            if (v != 0)
            {
                var remainingTime = ((totalSize - alreadyTransferDataEx) / (1024 * 1024)) / v;
                Console.WriteLine("remainingTime:" + sec_to_hms(remainingTime));
            }
            var percent = ((float)alreadyTransferDataEx / (1024 * 1024)) / ((float)totalSize / (1024 * 1024));
            Console.WriteLine("current process:" + Math.Round(percent, 2) * 100 + "%");
        }

        private string sec_to_hms(double duration)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(duration));
            string str = "";
            if (ts.Hours > 0)
            {
                str = String.Format("{0:00}", ts.Hours) + ":" + String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = "00:" + String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = "00:00:" + String.Format("{0:00}", ts.Seconds);
            }
            return str;
        }

        private void DeleteSorrceFolder(string sourcePath)
        {
            DirectoryInfo di = new DirectoryInfo(sourcePath);
            di.Delete(true);
        }

        private void CreateFolder(string targetFile)
        {
            var dir = targetFile.Split(@"\");
            dir = dir.Take(dir.Length - 1).ToArray();
            var path = string.Join("\\", dir);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void Init(string sourcePath)
        {
            pathList = new List<string>();
            directoryList = new List<string>();
            alreadyTransferData = 0;
            totalSize = 0;
            startTime = DateTime.Now;
            getDirectory(sourcePath);
        }
        private void getDirectoryEx(string path)
        {
            getFileNameEx(path);
            if (Directory.Exists(path))
            {
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (DirectoryInfo d in root.GetDirectories())
                {
                    getDirectoryEx(d.FullName);
                }
            }
        }

        private void getFileNameEx(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (FileInfo f in root.GetFiles())
                {
                    alreadyTransferDataEx += f.Length;
                }
            }
        }

        private void getDirectory(string path)
        {
            if (!directoryList.Contains(path))
            {
                directoryList.Add(path);
            }
            getFileName(path);
            DirectoryInfo root = new DirectoryInfo(path);
            foreach(DirectoryInfo d in root.GetDirectories())
            {
                getDirectory(d.FullName);
            }
        }

        private void getFileName(string path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            foreach(FileInfo f in root.GetFiles())
            {
                pathList.Add(f.FullName);
                totalSize += f.Length;
            }
        }

        public void CopyFile(string sourceFile, string targetFile)
        {
            byte[] array = new byte[bufferSize]; //创建缓冲区
            using (FileStream fsRead = File.Open(sourceFile, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsWrite = File.Open(targetFile, FileMode.Create, FileAccess.Write))
                {
                    while (fsRead.Position < fsRead.Length)
                    {
                        //读取到文件缓冲区
                        int length = fsRead.Read(array, 0, array.Length);
                        //从缓冲区写到新文件
                        fsWrite.Write(array, 0, length);
                        alreadyTransferData += array.Length;
                    }
                  
                    fsWrite.Dispose();
                }
                fsRead.Dispose();
            }
        }

        public void CopySingleFile(string sourceFile,string targetFile)
        {
            byte[] array = new byte[bufferSize]; //创建缓冲区
            float percent = 0;
            using (FileStream fsRead = File.Open(sourceFile, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsWrite = File.Open(targetFile, FileMode.Create, FileAccess.Write))
                {
                    while (fsRead.Position < fsRead.Length)
                    {
                        //读取到文件缓冲区
                        int length = fsRead.Read(array, 0, array.Length);
                        //从缓冲区写到新文件
                        fsWrite.Write(array, 0, length);
                        //计算进度
                        percent = (float)fsRead.Position / fsRead.Length;
                        //输出进度
                        Console.WriteLine(percent.ToString("p"));
                    }
                    fsWrite.Dispose();
                }
                fsRead.Dispose();
            }
            //文件流的对象如果在之后不再使用，推荐直接dispose掉，close只是关闭了连接，该文件流对象依然存在
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _timer.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
