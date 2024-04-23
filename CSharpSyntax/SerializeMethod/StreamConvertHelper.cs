using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeMethod
{
    /// <summary>
    /// 二进制方式的序列化与反序列化
    /// </summary>
    public class StreamConvertHelper
    {
        public T DeSerialize<T>(byte[] data)
        {
            object result = null;
            using (MemoryStream ms = new MemoryStream(data))
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = bf.Deserialize(ms);
            }
            return (T)result;
        }

        public byte[] Serialize(object data)
        {
            byte[] result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, data);
                result = ms.ToArray();
            }
            return result;
        }
    }
}
