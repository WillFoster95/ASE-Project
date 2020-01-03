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
    // deal with the triangle situation
    // add console text output to show what's happening
   
    public partial class Form1 : Form
    {
        private string whileCondition, ifCondition, syntaxErrorMessage;
        private string[] commandList, conditionStatementParts, SCcommand;
        private string[] recognisedCommands = { "var", "add", "sub", "mul", "div", "if", "while", "circle", "rectangle", 
            "triangle", "drawto", "moveto", "clear", "resetpen", "method", "endif", "endwhile", "endmethod" };
        private int penXPos, penYPos, temp;        
        private Graphics g;
        private string codeWindowText;
        private List<string> whileLoopBlock = new List<string>();
        private List<string> ifBlock = new List<string>();
        Dictionary<string, string> methods = new Dictionary<string, string>();
        private List<string> variableNames = new List<string>();
        private List<string> methodNames = new List<string>();

        CommandHandler ch;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)                     //Runs on Load
        {            
            g = paintWindow.CreateGraphics();    
            ch = new CommandHandler();
            ch.setGraphics(g);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ch.newCommand(commandLine.Text, penXPos, penYPos);
            if (!ch.checkCommandValid())
            {                
                console.Text += ch.getMessage();
            }                                                
            else if (!ch.getCommand().Equals("run"))
            {                               
                ch.exeCommand();
                console.Text += ch.getMessage();
                penXPos = ch.getPenXPos();
                penYPos = ch.getPenYPos();                              
            }                                
            else if (ch.getCommand().Equals("run"))
            {
                codeWindowText = codeWindow.Text.ToLower();
                commandList = codeWindowText.Split('\n');
                if(syntaxChecker(commandList))
                {
                    handleMethods(commandList);
                    for (int i = 0; i < commandList.Length; i++)
                    {
                        ch.newCommand(commandList[i], penXPos, penYPos);
                        /*
                        if (!ch.checkCommandValid())
                        {
                            console.Text += ch.getMessage();
                        }
                        */
                        
                        if (ch.getCommand().Equals("while"))
                        {
                            i = exeWhileLoop(i);
                        }
                        
                        else if (ch.getCommand().Equals("if"))
                        {                            
                            i = exeIf(i);                           
                        }                        
                        
                        else
                        {
                            ch.exeCommand();
                            console.Text += ch.getMessage();
                            penXPos = ch.getPenXPos();
                            penYPos = ch.getPenYPos();
                        }
                    }
                }
                else
                {
                    console.Text += syntaxErrorMessage;
                }
            }          
        }

        private int exeIf(int pc)
        {
            ifCondition = commandList[pc].Remove(0, 3);
            storeIfBlock(pc);
            if (conditionChecker(ifCondition))
            {
                for (int k = 0; k < ifBlock.Count; k++)
                {
                    if (ifBlock[k].StartsWith("if"))                     //if in if doesnt work as they both use the first endif
                    {
                        k = exeIf(pc + k + 1) - pc;
                    }
                    if (ifBlock[k].StartsWith("while"))                 
                    {
                        k = exeWhileLoop(pc + k + 1) - pc;
                    }
                    ch.newCommand(ifBlock[k], penXPos, penYPos);
                    ch.exeCommand();
                    console.Text += ch.getMessage();
                    penXPos = ch.getPenXPos();
                    penYPos = ch.getPenYPos();
                }
            }
            pc = pc + ifBlock.Count + 1;
            ifBlock.Clear();
            return pc;
        }
        private int exeWhileLoop(int pc)
        {
            storeWhileBlock(pc);
            whileCondition = commandList[pc].Remove(0, 6);
            while (conditionChecker(whileCondition))
            {
                for (int k = 0; k < whileLoopBlock.Count; k++)
                {       
                    if(whileLoopBlock[k].StartsWith("if"))
                    {
                        k = exeIf(pc + k + 1) - pc;
                    }
                    if (whileLoopBlock[k].StartsWith("while"))                  //while in while doesnt work as they both use the first endwhile
                    {
                        k = exeWhileLoop(pc + k + 1) - pc;
                    }

                    ch.newCommand(whileLoopBlock[k], penXPos, penYPos);
                    ch.exeCommand();
                    console.Text += ch.getMessage();
                    penXPos = ch.getPenXPos();
                    penYPos = ch.getPenYPos();
                }
            }
            pc = pc + whileLoopBlock.Count + 1;
            whileLoopBlock.Clear();
            return pc;
        }
        private void storeWhileBlock(int whileStart)
        {
            for (int j = whileStart + 1; j < commandList.Length; j++)
            {
                if (commandList[j].Equals("endwhile"))
                {
                    break;
                }
                else
                {
                    whileLoopBlock.Add(commandList[j]);
                }
            }
        } 
        private void storeIfBlock(int ifStart)
        {
            for (int j = ifStart + 1; j < commandList.Length; j++)
            {
                if (commandList[j].Equals("endif"))
                {
                    break;
                }
                else
                {
                    ifBlock.Add(commandList[j]);
                }
            }
        }

        private void handleMethods(string[] allCommands)
        {
            string methodName;
            int methStart, methEnd;
            
            for (int i = 0; i < allCommands.Length; i++)
            {
                if (allCommands[i].StartsWith("method "))
                {
                    methodName = allCommands[i].Split(' ')[1];
                    methStart = i;
                }                
            }
        }

        private bool conditionChecker(string conditionStatement)
        {
            conditionStatementParts = conditionStatement.Split(' ');
            int val1, val2;
            bool intcheck;
            intcheck = int.TryParse(conditionStatementParts[0], out val1);
            if(!intcheck)
            {
                val1 = ch.getVariableValue(conditionStatementParts[0]);
            }
            intcheck = int.TryParse(conditionStatementParts[2], out val2);
            if (!intcheck)
            {
                val2 = ch.getVariableValue(conditionStatementParts[2]);
            }

            if (conditionStatementParts[1].Equals("="))
            {
                if(val1 == val2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (conditionStatementParts[1].Equals("<"))
            {
                if(val1 < val2)
                {
                    return true;
                }
                else
                {   
                    return false;
                }
                
            }
            else if (conditionStatementParts[1].Equals(">"))
            {
                if (val1 > val2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (conditionStatementParts[1].Equals(">="))
            {
                if (val1 >= val2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (conditionStatementParts[1].Equals("<="))
            {
                if (val1 <= val2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }       
        private bool syntaxChecker(string[] comList)
        {
            bool goodSyntax = true;
            for(int i = 0; i < comList.Length; i++)                                             //List all method names
            {
                SCcommand = comList[i].Split(' ');
                if (SCcommand[0].Equals("method"))
                {
                    methodNames.Add(SCcommand[1]);
                }
            }
            for(int i = 0; i < comList.Length; i++)                                            
            {
                SCcommand = comList[i].Split(' ');
                for (int j = 0; j < recognisedCommands.Length; j++)                             //check if command recognised including going through method names                             
                {                   
                    if (SCcommand[0].Equals(recognisedCommands[j]))
                    {
                        break;
                    }
                    if (j == recognisedCommands.Length - 1)
                    {
                        if(methodNames.Count == 0)
                        {
                            syntaxErrorMessage += "Command not recognised at: " + comList[i] + "\n";
                            goodSyntax = false;
                        }
                        for(int k = 0; k < methodNames.Count; k++)
                        {
                            if (SCcommand[0].Equals(methodNames[k]))
                            {
                                break;
                            }
                            if(k == methodNames.Count - 1)
                            {
                                syntaxErrorMessage += "Command not recognised at: " + comList[i] + "\n";
                                goodSyntax = false;
                            }
                        }                       
                    }
                }

                if (SCcommand[0].Equals("var"))
                {
                    if(variableNames.Contains(SCcommand[1]))
                    {
                        syntaxErrorMessage += "The variable: \"" + SCcommand[1] + "\" is declared more than once. \n";
                        goodSyntax = false;
                    }
                    else
                    {
                        variableNames.Add(SCcommand[1]);
                    }
                    
                }
                if (SCcommand[0].Equals("sub") || SCcommand[0].Equals("div") || SCcommand[0].Equals("mul") || SCcommand[0].Equals("add"))
                {
                    if (int.TryParse(SCcommand[1], out temp))
                    {
                        syntaxErrorMessage += "The 1st parameter(" + SCcommand[1] + ") at: \"" + comList[i] + "\" should not be a number.\n";
                        goodSyntax = false;
                    }
                    if (SCcommand.Length < 4)
                    {
                        syntaxErrorMessage += "Missing parameter/s at: " + comList[i] + "\n";
                        goodSyntax = false;
                    }
                    if (SCcommand.Length > 4)
                    {
                        syntaxErrorMessage += "Missing parameter/s at: " + comList[i] + "\n";
                        goodSyntax = false;
                    }

                }
            }
            variableNames.Clear();
            methodNames.Clear();

            return goodSyntax;
        }
               
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();            
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {                    
            File.WriteAllText(saveFileDialog1.FileName, codeWindow.Text);
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            codeWindow.Text = File.ReadAllText(openFileDialog1.FileName);
        }
    }
}
