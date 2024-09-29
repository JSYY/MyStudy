using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MicroCompile
{
    public static class CompileConfigHelper
    {
        public static void GenerateDefaultConfig(string workPath,string vsPath)
        {
            CompileConfig compileConfig = new CompileConfig();
            List<Config> configs = new List<Config>();
            
            configs.Add(new Config()
            {
                Command = "BuildAllBase.bat",
                CommandName = "Common前端Component编译",
                Id = "1",
                WorkPath = Path.Combine(workPath, "Common", "uih.micro.base")
            });
            configs.Add(new Config()
            {
                Command = "BuildAll.bat",
                CommandName = "CT前端Component编译",
                Id = "2",
                WorkPath = Path.Combine(workPath, "CT", "FE")
            });
            configs.Add(new Config()
            {
                Command = "BuildAll.bat",
                CommandName = "PET前端Component编译",
                Id = "3",
                WorkPath = Path.Combine(workPath, "PET", "FE")
            });
            configs.Add(new Config()
            {
                Command = "\""+vsPath+"\""+" MicroCommon.sln /Build",
                CommandName = "Common BE编译",
                Id = "4",
                WorkPath = Path.Combine(workPath, "Common", "MicroCommon")
            });
            configs.Add(new Config()
            {
                Command = "\"" + vsPath + "\"" + " MicroCT.sln /Build",
                CommandName = "CT BE编译",
                Id = "5",
                WorkPath = Path.Combine(workPath, "CT", "BE")
            });
            configs.Add(new Config()
            {
                Command = "\"" + vsPath + "\"" + " MicroPET.sln /Build",
                CommandName = "PET BE编译",
                Id = "6",
                WorkPath = Path.Combine(workPath, "PET", "BE")
            });
            configs.Add(new Config()
            {
                Command = "npm run build-pro",
                CommandName = "PET 前端app编译",
                Id = "7",
                WorkPath = Path.Combine(workPath, "PET", "FE", "micropetctclientapp")
            });
            configs.Add(new Config()
            {
                Command = "npm run build-pro",
                CommandName = "CT 前端app编译",
                Id = "8",
                WorkPath = Path.Combine(workPath, "CT", "FE", "microctclientapp")
            });
            configs.Add(new Config()
            {
                Command = "npm run build",
                CommandName = "PET 前端app编译(实时)",
                Id = "9",
                WorkPath = Path.Combine(workPath, "PET", "FE", "micropetctclientapp"),
                flag=true
            });
            configs.Add(new Config()
            {
                Command = "npm run build",
                CommandName = "CT 前端app编译(实时)",
                Id = "10",
                WorkPath = Path.Combine(workPath, "CT", "FE", "microctclientapp"),
                flag=true
            });


            compileConfig.Configs = configs;
            XmlSerializer serializer = new XmlSerializer(typeof(CompileConfig));
            using (FileStream stream = new FileStream(@"compile.xml", FileMode.Create))
            {
                serializer.Serialize(stream, compileConfig);
                stream.Close();
            }
        }

        public static CompileConfig GetConfig()
        {
            if (File.Exists(@"compile.xml"))
            {
                CompileConfig info;
                XmlSerializer xmlSearializer = new XmlSerializer(typeof(CompileConfig));
                using (var fs = File.OpenRead(@"compile.xml"))
                {
                    info = (CompileConfig)xmlSearializer.Deserialize(fs);
                    fs.Close();
                }

                return info;
            }
            return null;
        }
    }

    [XmlType(TypeName = "CompileConfig")]
    public class CompileConfig
    {
        [XmlArray("Configs")]
        public List<Config> Configs { get; set; }
    }

    [XmlType(TypeName = "Config")]
    public class Config
    {
        [XmlElement("Command")]
        public string Command { get; set; }

        [XmlElement("CommandName")]
        public string CommandName { get; set; }

        [XmlElement("WorkPath")]
        public string WorkPath { get; set; }

        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("flag")]
        public bool flag { get; set; }
    }
}
