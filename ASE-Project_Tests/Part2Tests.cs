using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Project;

namespace ASE_Project_Tests
{
    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void getMethodName_Test()
        {
            int penXPos = 0, penYPos = 0;
            string command = "Method MyMethod (parameter x)";
            string expected = "MyMethod";
            CommandHandler ch = new CommandHandler(command, penXPos, penYPos);
            string actual = ch.getMethodName();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getVariableValue_Test()
        {
            int penXPos = 0, penYPos = 0;
            string command = "int x = 10";
            string expected = "10";
            CommandHandler ch = new CommandHandler(command, penXPos, penYPos);
            int actual = ch.getVariableValue("x");

            Assert.AreEqual(expected, actual);
        }
    }
}
