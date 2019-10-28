using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Project
{
    abstract class Shapes
    {
        protected int xPos, yPos;

        public Shapes(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public abstract void draw(Graphics g);
    }
}
