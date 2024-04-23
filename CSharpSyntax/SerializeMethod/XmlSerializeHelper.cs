using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializeMethod
{
    /// <summary>
    /// Xml 方式的序列化与反序列化
    /// </summary>
    public class XmlSerializeHelper
    {
        public string Serialize<T>(T o)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(stream, o);
                return Encoding.UTF8.GetString(stream.ToArray());
            } 
        }

        public T DeSerialize<T>(byte[] inputs)
        {
            using (MemoryStream stream = new MemoryStream(inputs))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                T o = (T)formatter.Deserialize(stream);
                return o;
            }
        }

        public T DeSerializeString<T>(string input)
        {
            return DeSerialize<T>(Encoding.UTF8.GetBytes(input));
        }
    }
}
