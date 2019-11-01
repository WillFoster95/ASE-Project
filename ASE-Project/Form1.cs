using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Project
{
    // check pen is within drawing area?
    // check vaild commands
    // check valid parameters
    // deal with the triangle situation
    // add console text output to show what's happening
   
    // save/load


    public partial class Form1 : Form
    {
        private string command;
        private string[] commandParts, commandList;
        private int penXPos, penYPos;
        private int radius, height, width;
        private Graphics g;
        private string codeWindowText;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)                     //Runs on Load
        {
            g = paintWindow.CreateGraphics();           
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            command = commandLine.Text;
            command = formatInstruction(command);           
            commandParts = command.Split(' ');

            checkVaildCommand(commandParts[0]);                       
            
            if (!commandParts[0].Equals("run"))
            {                               
                exeCommand(command);                            
            }            
            else if (commandParts[0].Equals("run"))
            {
                codeWindowText = codeWindow.Text;
                commandList = codeWindowText.Split('\n');
                
                for (int i = 0; i < commandList.Length; i++)
                {
                    exeCommand(commandList[i]);
                }
            }
            else
            {
                console.Text += "Invalid Command: \"" + commandParts[0] + "\"\n";
            }
        }

        private void checkVaildCommand(string command)
        {
            bool valid = false;
            if (command.Equals("run") || command.Equals("moveto") || command.Equals("drawto") || command.Equals("circle")|| 
                command.Equals("rectangle") || command.Equals("triangle") || command.Equals("clear") || command.Equals("resetpen"))
            {
                valid = true;
            }
            if (!valid)
            {
                console.Text += "Invalid Command: \"" + command + "\"\n";
            }
        }       

        private void exeCommand(string instruction)
        {
            instruction = formatInstruction(instruction);
            commandParts = instruction.Split(' ');
            checkVaildCommand(commandParts[0]);            
            try
            {

                if (commandParts[0].Equals("moveto"))                               // Move pen command
                {
                    movePen(Convert.ToInt32(commandParts[1]), Convert.ToInt32(commandParts[2]));        // Simplifiable?                
                }
                else if (commandParts[0].Equals("drawto"))                          // Draw line command
                {
                    Shapes L = new Line(penXPos, penYPos, Convert.ToInt32(commandParts[1]), Convert.ToInt32(commandParts[2]));      // Simplifiable?
                    L.draw(g);
                    movePen(Convert.ToInt32(commandParts[1]), Convert.ToInt32(commandParts[2]));        // Simplifiable?
                }
                else if (commandParts[0].Equals("circle"))                          // Circle command
                {
                    radius = Convert.ToInt32(commandParts[1]);
                    Shapes C = new Circle(penXPos - radius, penYPos - radius, radius);  // this object should be removed from memory on clear?
                    C.draw(g);
                }
                else if (commandParts[0].Equals("rectangle"))                       // Rectangle command
                {
                    width = Convert.ToInt32(commandParts[1]);
                    height = Convert.ToInt32(commandParts[2]);
                    Shapes R = new Rectangle(penXPos - (width / 2), penYPos - (height / 2), width, height);
                    R.draw(g);
                }
                else if (commandParts[0].Equals("triangle"))                        // Triangle command
                {
                    //ToDo. Draws triangle
                }
            }
            catch
            {
                console.Text += "Invalid parameter\n";
            }
            if (commandParts[0].Equals("clear"))                           // Clear paint window command
            {
                paintWindow.Refresh();  //this may not work all the time? 
                console.Text = "";                                              // Console cleared too
            }
            else if (commandParts[0].Equals("resetpen"))                        // Reset pen to top left command
            {
                movePen(0, 0);
            }
        }

        private string formatInstruction(string instruction)
        {
            instruction = instruction.Trim();
            instruction = instruction.ToLower();
            return instruction;
        }

        private void movePen(int x, int y)
        {
            penXPos = x;
            penYPos = y;
            console.Text += ("Pen moved to: " + penXPos + ", " + penYPos + "\n");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:\\Users\\Will\\Desktop\\test.txt", codeWindow.Text);
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeWindow.Text = File.ReadAllText("C:\\Users\\Will\\Desktop\\test.txt");
        }
    }
}
