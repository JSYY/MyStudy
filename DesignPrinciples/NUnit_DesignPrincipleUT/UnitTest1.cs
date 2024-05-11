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
            ComponentADecorator A = new ComponentADecorator(null, null);
            ComponentBDecorator B = new ComponentBDecorator(A, null);
            ComponentCDecorator C = new ComponentCDecorator(B, null);
            C.Handle();
        }
    }
}