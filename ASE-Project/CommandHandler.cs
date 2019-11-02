using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Project
{
    public class CommandHandler
    {
        private string command, consoleMessage;
        private string[] commandParts;
        private int parameter1, parameter2, parameter3;
        private int penXPos, penYPos;
        private int radius, height, width;
        bool invalidParameter, invalidTriangle;
        Graphics g;
        public CommandHandler(string command, int penXPos, int penYPos)
        {          
            command = formatInstruction(command);
            commandParts = command.Split(' ');

            this.command = commandParts[0];                     
            this.penXPos = penXPos;
            this.penYPos = penYPos;
        }
                      
        public void exeCommand()
        {
            try
            {
                if (command.Equals("moveto"))                               // Move pen command
                {
                    parameter1 = convertParameter(commandParts[1]);
                    parameter2 = convertParameter(commandParts[2]);
                    if (!invalidParameter)
                    {
                        movePen(parameter1, parameter2);
                    }
                    
                }
                else if (command.Equals("drawto"))                          // Draw line command
                {
                    parameter1 = convertParameter(commandParts[1]);
                    parameter2 = convertParameter(commandParts[2]);
                    if (!invalidParameter)
                    {
                        Shapes L = new Line(penXPos, penYPos, parameter1, parameter2);      // Simplifiable?
                        L.draw(g);
                        movePen(parameter1, parameter2);
                    }
                }
                else if (commandParts[0].Equals("circle"))                          // Circle command
                {
                    radius = convertParameter(commandParts[1]);
                    if (!invalidParameter)
                    {
                        Shapes C = new Circle(penXPos - radius, penYPos - radius, radius);  // this object should be removed from memory on clear?
                        C.draw(g);
                    }
                }
                else if (commandParts[0].Equals("rectangle"))                       // Rectangle command
                {
                    width = convertParameter(commandParts[1]);
                    height = convertParameter(commandParts[2]);
                    if (!invalidParameter)
                    {
                        Shapes R = new Rectangle(penXPos - (width / 2), penYPos - (height / 2), width, height);
                        R.draw(g);
                    }
                }
                else if (commandParts[0].Equals("triangle"))                        // Triangle command
                {
                    parameter1 = convertParameter(commandParts[1]);
                    parameter2 = convertParameter(commandParts[2]);
                    if(!invalidParameter)
                    {
                        //checkValidTriangle(parameter1, parameter2, parameter3);
                        //if(!invalidTriangle)
                        //{
                            Shapes T = new Triangle(penXPos, penYPos, parameter1, parameter2);
                            T.draw(g);
                        //}                       
                    }
                }
                else if (commandParts[0].Equals("clear"))                           // Clear paint window command
                {
                    g.Clear(Color.White);
                    consoleMessage += "cleared\n";                                              // Console cleared too
                }
                else if (commandParts[0].Equals("resetpen"))                        // Reset pen to top left command
                {
                    movePen(0, 0);
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                consoleMessage += "Missing Parameter\n";
            }
        }

        /*
        private void checkValidTriangle(int parameter1, int parameter2, int parameter3)
        {
            invalidTriangle = false;
            if (parameter1 + parameter2 <= parameter3 || parameter1 + parameter3 <= parameter2 || parameter2 + parameter3 <= parameter1)
            {
                invalidTriangle = true;
            }          
        }
        */

        public string getMessage()
        {
            return consoleMessage;
        }
        public bool checkCommandValid()
        {
            bool valid = false;
            if (command.Equals("run") || command.Equals("moveto") || command.Equals("drawto") || command.Equals("circle") ||
                command.Equals("rectangle") || command.Equals("triangle") || command.Equals("clear") || command.Equals("resetpen"))
            {
                valid = true;
                return valid;
            }
            else
            {
                return valid;
            }            
        }
        public int getPenXPos()
        {
            return penXPos;
        }
        public int getPenYPos()
        {
            return penYPos;
        }
        public string getCommand()
        {
            return command;
        }
        public void setGraphicsObject(Graphics g)
        {
            this.g = g;
        }

        private void movePen(int x, int y)
        {
            penXPos = x;
            penYPos = y;
        }
        private string formatInstruction(string instruction)
        {
            instruction = instruction.Trim();
            instruction = instruction.ToLower();
            return instruction;
        }
        private int convertParameter(string parameter)
        {
            int param = 0;
            invalidParameter = false;
            try
            {
                param = Convert.ToInt32(parameter);
            }
            catch
            {
                consoleMessage += "\"" + parameter + "\" " + "is not a vaild parameter\n";
                invalidParameter = true;
            }
            return param;
        }
    }
}
