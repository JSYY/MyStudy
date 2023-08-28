using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer
{
    public delegate void DataChangedHandler(string id);
    public class ServiceReturnToWeb
    {
        public event EventHandler<MyEventArgs> OnDataChanged;
        public event DataChangedHandler datachanged;

        public ServiceReturnToWeb()
        {

        }

        public void notify()
        {
            if (datachanged != null)
            {
                datachanged("2");
            }
        }

        public void notifyData()
        {
            if (OnDataChanged != null)
            {
                OnDataChanged(this, new MyEventArgs(1, "1"));
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
