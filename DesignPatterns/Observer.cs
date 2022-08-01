using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //观察者模式
    public abstract class Observer
    {
        public abstract void Update(string action);
    }
    public class RealObserver : Observer
    {
        private string _name;
        public RealObserver(string name)
        {
            _name = name;
        }
        public override void Update(string action)
        {
            Console.WriteLine("{0} Receive message from EventMaker,message is {1}",new object[] { _name,action });
        }
    }
    public abstract class Subject
    {
        public abstract void NotifyAll();
        public abstract void Attach(Observer observer);
        public abstract void Detach(Observer observer);

    }
    public class EventMaker : Subject
    {
        private List<Observer> observerList;
        private string _action;
        public EventMaker()
        {
            observerList = new List<Observer>();
        }

        public void SetAction(string action)
        {
            _action = action;
            NotifyAll();
        }

        public override void Attach(Observer observer)
        {
            observerList.Add(observer);
        }

        public override void Detach(Observer observer)
        {
            observerList.Remove(observer);
        }

        public override void NotifyAll()
        {
            observerList.ForEach(item =>
            {
                item.Update(_action);
            });
        }

    }
}
