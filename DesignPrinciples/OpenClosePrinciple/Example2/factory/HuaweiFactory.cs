using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple.Example2.factory
{
    public class HuaweiFactory : IMobileFactory
    {
        public IMobilephone CreateMobile()
        {
            return new Huawei();
        }
    }
}
