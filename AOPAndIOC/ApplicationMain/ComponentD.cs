using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMain
{
    //Action是无返回值的泛型委托，可以接受0个至16个传入参数

    //Action 表示无参，无返回值的委托

    //Action<int,string> 表示有传入参数int, string无返回值的委托

    //Func是有返回值的泛型委托，可以接受0个至16个传入参数

    //Func<int> 表示无参，返回值为int的委托

    //Func<object,string,int> 表示传入参数为object, string 返回值为int的委托

    //predicate 是返回bool型的泛型委托，只能接受一个传入参数

    //predicate<int> 表示传入参数为int 返回bool的委托
    public interface IComponentD
    {

        void EventHappen();
        event EventHandler<MyEventArgs> eventA;
    }

    [Component]
    public class ComponentD:IComponentD
    {
        public event EventHandler<MyEventArgs> eventA;
        private readonly int id = 1;
        private readonly string name = "event";

        public ComponentD()
        {

        }

        public void EventHappen()
        {
            if (eventA != null)
            {
                Console.WriteLine("ComponentD start broadcast EventA");
                eventA(this, new MyEventArgs(id,name));
            }
        }
    }

    public class MyEventArgs : EventArgs
    {
        public int id;
        public string name;

        public MyEventArgs(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
