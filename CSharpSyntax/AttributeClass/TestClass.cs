using System;

namespace AttributeClass
{
    [My(Name ="TestClass")]
    public class TestClass
    {
        private int id;
        public string name;

        [Property]
        public int ID { get; set; }

        [Method(Name ="Method")]
        public void Method()
        {

        }

        private int Method(int number)
        {
            return 0;
        }
    }
}
