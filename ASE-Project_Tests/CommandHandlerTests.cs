using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Project;
using System.Drawing; 

namespace ASE_Project_Tests
{
    [TestClass]
    public class CommandHandlerTests
    {
        [TestMethod]
        public void getCommand_Test()
        {
            string command = "Run", expected = "run";
            int penXPos = 0, penYPos = 0;          
            CommandHandler ch = new CommandHandler(command, penXPos, penYPos);

            string actual = ch.getCommand();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getPenXPos_Test()
        {
            string command = "Run";
            int penXPos = 100, penYPos = 200, expected = 100;
            CommandHandler ch = new CommandHandler(command, penXPos, penYPos);

            int actual = ch.getPenXPos();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getPenYPos_Test()
        {
            string command = "Run";
            int penXPos = 100, penYPos = 200, expected = 200;
            CommandHandler ch = new CommandHandler(command, penXPos, penYPos);

            int actual = ch.getPenYPos();

            Assert.AreEqual(expected, actual);
        }
    }
}
