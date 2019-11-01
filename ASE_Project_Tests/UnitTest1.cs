using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Project;
using System.Windows.Forms;

namespace ASE_Project_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void checkValidCommand_WithAllValidCommands()
        {
            bool valid = true, check;
            string[] commands = { "run", "movto", "drawto", "circle", "rectangle", "triangle", "clear", "resetpen" } ;
            Form1 f1 = new Form1();
            for (int i = 0; i<commands.Length; i++)
            {
                check = f1.checkVaildCommand();
                if (!check)
                {
                    valid = false;
                }
            }
            Assert.IsTrue(valid);
        }
    }
}
