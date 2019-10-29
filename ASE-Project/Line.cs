using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Project
{
    class Line : Shapes
    {
        private int xEnd, yEnd;
        public Line(int xPos, int yPos, int xEnd, int yEnd) : base(xPos, yPos)
        {
            this.xEnd = xEnd;
            this.yEnd = yEnd;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawLine(p, xPos, yPos, xEnd, yEnd);
        }
    }
}
