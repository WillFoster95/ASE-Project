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
        private string command, consoleMessage = "";
        private string[] commandParts;
        private int parameter1, parameter2;
        private int penXPos, penYPos;
        private int radius, height, width;
        bool invalidParameter, parameterOutOfBounds;
        Graphics g;
       
        Dictionary<string, int> variableDict = new Dictionary<string, int>();

        public CommandHandler(Graphics g)
        {                    
            this.g = g;        
        }

        public void newCommand(string command, int penXPos, int penYPos)
        {
            consoleMessage = "";
            command = formatInstruction(command);
            commandParts = command.Split(' ');
            this.command = commandParts[0];           
            this.penXPos = penXPos;
            this.penYPos = penYPos;
        }
                      
        public void exeCommand()
        {
            Shapes s; 
            ShapesFactory factory = new ShapesFactory();
            try
            {
                if (command.Equals("moveto"))                               // Move pen command
                {
                    parameter1 = convertParameter(commandParts[1]);
                    parameter2 = convertParameter(commandParts[2]);
                    parameterOutOfBounds = checkParameterOutOfBounds(parameter1, parameter2);                   
                    if (!invalidParameter && !parameterOutOfBounds)
                    {
                        movePen(parameter1, parameter2);
                    }
                    
                }
                else if (command.Equals("drawto"))                          // Draw line command
                {
                    parameter1 = convertParameter(commandParts[1]);
                    parameter2 = convertParameter(commandParts[2]);
                    if (!invalidParameter && !parameterOutOfBounds)
                    {
                        s = factory.getShape("line");
                        s.setParams(penXPos, penYPos, parameter1, parameter2);
                        s.draw(g);
                        movePen(parameter1, parameter2);
                    }
                }
                else if (command.Equals("circle"))                          // Circle command
                {
                    parameter1 = convertParameter(commandParts[1]);
                    radius = parameter1;
                    if (!invalidParameter)
                    {
                        s = factory.getShape("circle");
                        s.setParams(penXPos - radius, penYPos - radius, radius);                        
                        s.draw(g);
                    }
                }
                else if (command.Equals("rectangle"))                       // Rectangle command
                {
                    parameter1 = convertParameter(commandParts[1]);
                    parameter2 = convertParameter(commandParts[2]);
                    width = parameter1;
                    height = parameter2;
                    if (!invalidParameter)
                    {
                        s = factory.getShape("rectangle");
                        s.setParams(penXPos, penYPos, width, height);                     
                        s.draw(g);
                    }
                }
                else if (command.Equals("triangle"))                        // Triangle command
                {
                    parameter1 = convertParameter(commandParts[1]);
                    parameter2 = convertParameter(commandParts[2]);
                    if (!invalidParameter)
                    {
                        s = factory.getShape("triangle");
                        s.setParams(penXPos, penYPos, parameter1, parameter2);
                        s.draw(g);
                                              
                    }
                }
                else if (command.Equals("clear"))                           // Clear paint window command
                {
                    g.Clear(Color.White);
                    consoleMessage += "cleared\n";                                              // Console cleared too
                }
                else if (commandParts[0].Equals("resetpen"))                        // Reset pen to top left command
                {
                    movePen(0, 0);
                }
                else if (command.Equals("var"))
                {
                    parameter1 = convertParameter(commandParts[2]);
                    variableDict.Add(commandParts[1], parameter1);
                    consoleMessage += "the variable " + commandParts[1] + " has value " + variableDict[commandParts[1]] + "\n";
                }
                else if (command.Equals("add"))
                {
                    parameter1 = convertParameter(commandParts[2]);
                    parameter2 = convertParameter(commandParts[3]);
                    variableDict[commandParts[1]] = parameter1 + parameter2;
                    consoleMessage += "the variable " + commandParts[1] + " has value " + variableDict[commandParts[1]] + "\n";
                }
                else if (command.Equals("sub"))
                {
                    parameter1 = convertParameter(commandParts[2]);
                    parameter2 = convertParameter(commandParts[3]);
                    variableDict[commandParts[1]] = parameter1 - parameter2;
                    consoleMessage += "the variable " + commandParts[1] + " has value " + variableDict[commandParts[1]] + "\n";
                }
                else if (command.Equals("mul"))
                {
                    parameter1 = convertParameter(commandParts[2]);
                    parameter2 = convertParameter(commandParts[3]);
                    variableDict[commandParts[1]] = parameter1 * parameter2;
                    consoleMessage += "the variable " + commandParts[1] + " has value " + variableDict[commandParts[1]] + "\n";
                }
                else if (command.Equals("div"))
                {
                    parameter1 = convertParameter(commandParts[2]);
                    parameter2 = convertParameter(commandParts[3]);
                    variableDict[commandParts[1]] = parameter1 / parameter2;
                    consoleMessage += "the variable " + commandParts[1] + " has value " + variableDict[commandParts[1]] + "\n";
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                consoleMessage += "Missing Parameter\n";
            }
        }     

        public string getMessage()
        {
            return consoleMessage;
        }
        public bool checkCommandValid()
        {
            if (command.Equals("run") || command.Equals("moveto") || command.Equals("drawto") || command.Equals("circle") ||
                command.Equals("rectangle") || command.Equals("triangle") || command.Equals("clear") || command.Equals("resetpen") || 
                command.Equals("var") || command.Equals("while") || command.Equals("add") || command.Equals("sub") || command.Equals("mul") || 
                command.Equals("div"))
            {                
                return true;
            }
            else
            {
                consoleMessage += "Invalid Command: \"" + getCommand() + "\"\n";
                return false;
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
        public string getCommandPart1()
        {
            return commandParts[1];
        }
        public string getCommandPart2()
        {
            return commandParts[2];
        }
        public string getCommandPart3()
        {
            return commandParts[3];
        }

        private void movePen(int x, int y)
        {
            penXPos = x;
            penYPos = y;
            consoleMessage += "Pen Moved to: " + x + ", " + y + "\n";
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
            bool result = int.TryParse(parameter, out param);
            if (!result)
            {
                param = variableDict[parameter];
            }           
            return param;
        }

        private bool checkParameterOutOfBounds(int xParam, int yParam)
        {            
            if (xParam > 445 || xParam < 0)
            {
                consoleMessage += "\"" + xParam + "\" " + "is out of bounds\n";
                return true;
            }
            if (yParam > 409 || yParam < 0)
            {
                consoleMessage += "\"" + yParam + "\" " + "is out of bounds\n";
                return true;
            }
            return false;
        }



        public string getMethodName()
        {
            return "";
        }
        public int getVariableValue(string varName)
        {
            return variableDict[varName];
        }
    }
}
