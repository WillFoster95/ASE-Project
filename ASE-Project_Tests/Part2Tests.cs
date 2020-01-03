using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Project;

namespace ASE_Project_Tests
{
    [TestClass]
    public class Part2Tests
    {
        //tests the getMethodName method to see if it returns the correct value
        [TestMethod]
        public void getMethodName_Test()
        {
            int penXPos = 0, penYPos = 0;
            string command = "Method MyMethod (parameter x)";
            string expected = "MyMethod";
            CommandHandler ch = new CommandHandler();
            ch.newCommand(command, penXPos, penYPos);
            ch.exeCommand();
            string actual = ch.getMethodName();

            Assert.AreEqual(expected, actual);
        }

        //checks to see if the method getVariableValue returns the correct value
        [TestMethod]
        public void getVariableValue_Test()
        {
            int penXPos = 0, penYPos = 0;
            string command = "var x 10";
            int expected = 10;
            CommandHandler ch = new CommandHandler();
            ch.newCommand(command, penXPos, penYPos);
            ch.exeCommand();
            int actual = ch.getVariableValue("x");

            Assert.AreEqual(expected, actual);
        }
    }
}
