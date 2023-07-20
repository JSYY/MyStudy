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
        void CopyFloder(string sourcePath, string targetPath);
    }

    [Component]
    public class ComponentE:IComponentE,IDisposable
    {
        private int bufferSize = 1024*1024;
        private int alreadyTransferData = 0;
        private int totalSize = 0;
        private bool disposedValue;
        private readonly Timer _timer;

        public ComponentE()
        {
            _timer = new Timer(state => CalculateVelocityAndRemainingTime());
        }

        private void CalculateVelocityAndRemainingTime()
        {
            var v = alreadyTransferData/(1024*1024);
            Console.WriteLine("current velocity:"+v);
            var remainingTime = (totalSize - alreadyTransferData / (1024 * 1024)) / v;
            Console.WriteLine("remainingTime:"+remainingTime);
        }

        public void CopyFloder(string sourcePath,string targetPath)
        {
            totalSize = CalculateTotalSize(sourcePath);
            _timer.Change(0, 1000);
            
        }

        private int CalculateTotalSize(string sourcePath)
        {
            throw new NotImplementedException();
        }

        public void CopyFile(string sourceFile, string targetFile)
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
                        percent = (float)fsRead.Position / totalSize;
                        //输出进度
                        Console.WriteLine(percent.ToString("p"));
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
