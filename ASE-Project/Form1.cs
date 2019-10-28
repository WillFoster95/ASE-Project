using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Project
{
    public partial class Form1 : Form
    {
        private string command;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            codeWindow.Text = "No";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            console.Text += "run pressed\n";
            command = commandLine.Text;
            command = command.Trim();
            command = command.ToLower();

            if (command.Equals("draw"))
            {
                drawShapes();
            }
            
        }

        private void drawShapes()
        {
            console.Text += "in method\n";
            Graphics g = paintWindow.CreateGraphics();

            
            Shapes R = new Rectangle(100, 100, 200, 100);
            Shapes C = new Circle(110, 100, 100);
            R.draw(g);
            C.draw(g);
            


        }    
    }
}
