using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class SinglePattern
    {
        private static object _lock = new object();
        private static SinglePattern _singlePattern;
        private SinglePattern()
        {
        }

        public SinglePattern GetInstance()
        {
            
            if(_singlePattern == null)
            {
                lock (_lock)
                {
                    if(_singlePattern == null)
                    {
                        return _singlePattern = new SinglePattern();
                    }
                }
            }
            return _singlePattern;
        }
    }
}
