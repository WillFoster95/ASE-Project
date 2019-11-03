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
        private Graphics g;
        private string codeWindowText;
        private bool commandValid;
        CommandHandler ch;
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
            ch = new CommandHandler(command, penXPos, penYPos);
            ch.setGraphicsObject(g);
            commandValid = ch.checkCommandValid();
            if (!commandValid)
            {
                console.Text += "Invalid Command: \"" + ch.getCommand() + "\"\n";                
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
                    ch = new CommandHandler(commandList[i], penXPos, penYPos);
                    ch.setGraphicsObject(g);
                    if (!ch.checkCommandValid())
                    {
                        console.Text += "Invalid Command: \"" + ch.getCommand() + "\"\n";
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
