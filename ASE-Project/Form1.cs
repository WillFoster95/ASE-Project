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
        private string command, whileCondition;
        private string[] commandList, conditionStatementParts;
        private int penXPos, penYPos;        
        private Graphics g;
        private string codeWindowText;
        private List<string> whileLoopBlock = new List<string>();


        CommandHandler ch;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)                     //Runs on Load
        {            
            g = paintWindow.CreateGraphics();    
            ch = new CommandHandler(g);

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
                codeWindowText = codeWindow.Text;
                commandList = codeWindowText.Split('\n');
                
                for (int i = 0; i < commandList.Length; i++)
                {
                    ch.newCommand(commandList[i], penXPos, penYPos);
                    if (!ch.checkCommandValid())
                    {                        
                        console.Text += ch.getMessage();
                    }
                    else if (ch.getCommand().Equals("while"))
                    {
                        storeWhileBlock(i);
                        whileCondition = commandList[i].Remove(0, 6);                        
                        exeWhileLoop();
                        i = i + whileLoopBlock.Count + 1;
                        whileLoopBlock.Clear();                       
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

        private void exeWhileLoop()
        {
            int k = 0;
            while(conditionChecker(whileCondition))
            {
                ch.newCommand(whileLoopBlock[k], penXPos, penYPos);
                ch.exeCommand();
                console.Text += ch.getMessage();
                penXPos = ch.getPenXPos();
                penYPos = ch.getPenYPos();
                k++;
            }           
        }

        private bool conditionChecker(string conditionStatement)
        {
            conditionStatementParts = conditionStatement.Split(' ');
            int val1, val2;
            try
            {
                val1 = Convert.ToInt32(conditionStatementParts[0]);
            }
            catch
            {
                val1 = ch.getVariableValue(conditionStatementParts[0]);
            }
            try
            {
                val2 = Convert.ToInt32(conditionStatementParts[2]);
            }
            catch
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
                return false;
            }
            else if (conditionStatementParts[1].Equals(">"))
            {
                return false;
            }
            else if (conditionStatementParts[1].Equals(">="))
            {
                return false;
            }
            else if (conditionStatementParts[1].Equals("<="))
            {
                return false;
            }
            return false;
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
