using AbstractFactory.Factory;
using CommandHandler;
using DecoratorPrinciple;
using NUnit.Framework;
using System.Text;

namespace NUnit_DesignPrincipleUT
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCommandHandler()
        {
            var originalData = new byte[5];
            var transformData = Encoding.UTF8.GetString(originalData);
            var action = new CommandHandlerAction<string>((originalData) => { return Encoding.UTF8.GetString(originalData); }, (result) => { });
            action.DoCommand(originalData);
        }

        [Test]
        public void TestDecorator()
        {
            DecoratorObject obj = new DecoratorObject();
            ComponentADecorator A = new ComponentADecorator(null, obj);
            ComponentBDecorator B = new ComponentBDecorator(A, obj);
            ComponentCDecorator C = new ComponentCDecorator(B, obj);
            C.Handle();

            Assert.AreEqual(obj.PropertyA, "A");
            Assert.AreEqual(obj.PropertyB, "B");
            Assert.AreEqual(obj.PropertyC, "C");
        }

        [Test]
        public void TestAbstractFactory()
        {
            string size1 = "60";
            string size2 = "70";

            HuaweiFactory factory = new HuaweiFactory();
            var service1 = factory.CreateProductService(AbstractFactory.ProductType.mobilePhone, size1);
            Assert.AreEqual(size1, service1.CreateProduct().Size);
            var service2 = factory.CreateProductService(AbstractFactory.ProductType.computer, size2);
            Assert.AreEqual(size2, service2.CreateProduct().Size);
        }
    }
}