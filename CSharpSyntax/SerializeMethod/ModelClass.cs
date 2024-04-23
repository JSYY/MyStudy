using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeMethod
{
    [Serializable]
    public class ClassA
    {
        public int age { get; set; }
        public string name { get; set; }
        public List<string> addressHistory { get; set; }
    }
}
