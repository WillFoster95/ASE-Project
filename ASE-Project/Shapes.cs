using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Project
{
    abstract class Shapes : IShapes
    {
        protected int xPos, yPos;

        public Shapes(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }
        public virtual void setParams(params int[] dimensions)
        {
            this.xPos = dimensions[0];
            this.yPos = dimensions[1];
        }

        public abstract void draw(Graphics g); // Can Pen be moved to here?
    }
}
