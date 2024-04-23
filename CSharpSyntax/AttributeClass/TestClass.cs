using System;

namespace AttributeClass
{
    [MyAttribute(Name ="TestClass")]
    public class TestClass
    {
        private int id;
        public string name;

        public int ID { get; set; }

        [MethodAttribute(Name ="Method")]
        public void Method()
        {

        }

        private int Method(int number)
        {
            return 0;
        }
    }
}
