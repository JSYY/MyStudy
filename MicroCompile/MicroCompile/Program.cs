using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MicroCompile
{
    class Program
    {
        static void Main(string[] args)
        {
            var defaultConfigs = CompileConfigHelper.GetConfig();
            if (defaultConfigs == null)
            {
                Console.WriteLine("输入工作目录");
                var workPath = Console.ReadLine();
                Console.WriteLine("输入VS 编译器目录");
                var vsPath = Console.ReadLine();
                CompileConfigHelper.GenerateDefaultConfig(workPath, vsPath);
            }
            var configs = CompileConfigHelper.GetConfig();
            configs.Configs.ToList().ForEach(config =>
            {
                Console.WriteLine("{0}-----{1}",new object[] { config.CommandName,config.Id });
            });
            Console.WriteLine("整体编译-----0");
            Console.WriteLine("组合编译-----C");

            var str = Console.ReadLine();
            switch (str.ToLower())
            {
                case "0":
                    //全编译
                    configs.Configs.ToList().ForEach(config =>
                    {
                        if (!config.flag)
                        {
                            CmdUtil.RunCmd(config.Command, config.WorkPath);
                        }
                    });
                    break;
                case "c":
                    //组合编译
                    Console.WriteLine("请根据上述提示id输入组合，如1#2#3");
                    var strc = Console.ReadLine();
                    var cList = strc.Split("#");
                    cList.ToList().ForEach(item =>
                    {
                        configs.Configs.ToList().ForEach(o =>
                        {
                            if (o.Id == item)
                            {
                                CmdUtil.RunCmd(o.Command, o.WorkPath);
                            }
                        });
                    });
                    break;
            }
            //单编译
            configs.Configs.ToList().ForEach(item =>
            {
                if(item.Id == str)
                {
                    CmdUtil.RunCmd(item.Command, item.WorkPath);
                }
            }); 
        }
    }
}
