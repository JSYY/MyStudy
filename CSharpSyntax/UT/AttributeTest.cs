using AttributeClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UT
{
    [TestClass]
    public class AttributeTest
    {

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void Test1()
        {
            Type t = typeof(TestClass);
            //拿到类的方法
            var method = t.GetMethods();
            //拿到类的属性
            var property = t.GetProperties();
            //拿到类的字段
            var field = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            //拿到类的特性
            var attr = t.GetCustomAttributes(false);

            foreach(MethodInfo item in method)
            {
                //拿到方法的特性
                var a = item.GetCustomAttributes(false);
            }

        }
    }
}
