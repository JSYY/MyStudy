using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializeMethod;
using System.Collections.Generic;

namespace SerializeTest
{
    [TestClass]
    public class UnitTest
    {
        public XmlSerializeHelper xmlSerializeHelper;
        public StreamConvertHelper streamConvertHelper;

        [TestInitialize]
        public void TestInitialize()
        {
            xmlSerializeHelper = new XmlSerializeHelper();
            streamConvertHelper = new StreamConvertHelper();
        }

        [TestMethod]
        public void XmlSerializeTest()
        {
            ClassA classA = new ClassA()
            {
                age = 22,
                name = "lili",
                addressHistory = new List<string>() { "111", "222" }
            };
            var n = xmlSerializeHelper.Serialize<ClassA>(classA);
            var result = xmlSerializeHelper.DeSerializeString<ClassA>(n);
            Assert.AreEqual(result.name, classA.name);
        }

        [TestMethod]
        public void BinarySerializeTest()
        {
            ClassA classA = new ClassA()
            {
                age = 22,
                name = "lili",
                addressHistory = new List<string>() { "111", "222" }
            };
            var n = streamConvertHelper.Serialize(classA);
            var result = streamConvertHelper.DeSerialize<ClassA>(n);
            Assert.AreEqual(result.name, classA.name);
        }
    }
}
