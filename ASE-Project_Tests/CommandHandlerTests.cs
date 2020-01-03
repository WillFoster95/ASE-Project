using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Project;
using System.Drawing;
using System;

namespace ASE_Project_Tests
{
    [TestClass]
    public class CommandHandlerTests
    {
        //test the getCommand method to see if it returns the correct value
        [TestMethod]
        public void getCommand_Test()
        {
            string command = "Run", expected = "run";
            int penXPos = 0, penYPos = 0;
            
            CommandHandler ch = new CommandHandler();
            ch.newCommand(command, penXPos, penYPos);

            string actual = ch.getCommand();

            Assert.AreEqual(expected, actual);
        }

        //tests the getPenXPos to see if it returns the correct value
        [TestMethod]
        public void getPenXPos_Test()
        {
            string command = "Run";
            int penXPos = 100, penYPos = 200, expected = 100;
            CommandHandler ch = new CommandHandler();
            ch.newCommand(command, penXPos, penYPos);

            int actual = ch.getPenXPos();

            Assert.AreEqual(expected, actual);
        }

        //tests the getPenYPos to see if it returns the correct value
        [TestMethod]
        public void getPenYPos_Test()
        {
            string command = "Run";
            int penXPos = 100, penYPos = 200, expected = 200;
            CommandHandler ch = new CommandHandler();
            ch.newCommand(command, penXPos, penYPos);

            int actual = ch.getPenYPos();
            

            Assert.AreEqual(expected, actual);
        }

        //Test the getMessage method with a valid command
        [TestMethod]
        public void getMessage_WithValidCommand()
        {
            string command = "Run", expected = "";
            int penXPos = 0, penYPos = 0;
            CommandHandler ch = new CommandHandler();
            ch.newCommand(command, penXPos, penYPos);
            ch.checkCommandValid();
            string actual = ch.getMessage();

            Assert.AreEqual(expected, actual);
        }

        //Test the getMessage method with an invalid command
        [TestMethod]
        public void getMessage_WithInValidCommand()
        {
            string command = "fan", expected = "Invalid Command: \"fan\"\n";
            int penXPos = 0, penYPos = 0;
            CommandHandler ch = new CommandHandler();
            ch.newCommand(command, penXPos, penYPos);
            ch.checkCommandValid();
            string actual = ch.getMessage();        

            Assert.AreEqual(expected, actual);
        }
    }
}
