using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMain
{
    //元组(Tuple)是C# 4.0引入的一个新特性，可以在.NET Framework 4.0或更高版本中使用。组元使用泛型来简化类的定义，多用于方法的返回值。
    //在函数需要返回多个类型的时候，就不必使用out , ref等关键字了，直接定义一个Tuple类型，使用起来非常方便

    public interface IComponentC
    {

    }

    [Component]
    public class ComponentC:IComponentC
    {
        private IComponentD _componentD;
        private Dictionary<string, Func<int, string, string>> _dic;

        public ComponentC(IComponentD componentD)
        {
            _componentD = componentD;
            _dic = new Dictionary<string, Func<int, string, string>>();
            _dic.Add("1", MyFunc);
            _componentD.eventA += _componentC_eventA;
        }

        private void _componentC_eventA(object sender, MyEventArgs e)
        {
            Console.WriteLine("ComponentC receive eventA from ComponentD,id is {0},name is {1}",new object[] { e.id,e.name});
            Tuple<Func<int, string,string>, string> tuple = null;
            switch(e.id){
                case 1:
                    tuple = GenerateTuple(e);
                    break;
            }
            var s = tuple.Item1.Invoke(e.id,e.name);
            Console.WriteLine("Combining result is {0},After combining :{1}",new object[] { tuple.Item2,s});
        }

        private Tuple<Func<int,string,string>, string> GenerateTuple(MyEventArgs e)
        {
            if (_dic.ContainsKey(e.id.ToString()))
            {
                return new Tuple<Func<int, string, string>, string>(_dic[e.id.ToString()], "success");
            }
            return null;
        }

        private string MyFunc(int number,string name)
        {
            return name+ number.ToString();
        }
    }
}
