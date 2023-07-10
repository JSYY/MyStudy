using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMain
{
    /// <summary>
    /// 文件流
    /// </summary>
    public interface IComponentE
    {
        void CopyFile(string sourceFile, string targetFile);
    }

    [Component]
    public class ComponentE:IComponentE
    {
        private int bufferSize = 1024;
        public ComponentE()
        {

        }

        public void CopyFile(string sourceFile,string targetFile)
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
    }
}
