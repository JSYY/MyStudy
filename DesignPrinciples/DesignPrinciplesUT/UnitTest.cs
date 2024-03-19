using CommandHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace DesignPrinciplesUT
{
    [TestClass]
    public class UnitTest
    {

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine();
        }

        [TestMethod]
        public void TestCommandHandler()
        {
            var originalData = new byte[5];
            var transformData = Encoding.UTF8.GetString(originalData);
            var action = new CommandHandlerAction<string>((originalData)=> { return Encoding.UTF8.GetString(originalData); },(result)=> {  });
            action.DoCommand(originalData);
            
        }
    }
}
