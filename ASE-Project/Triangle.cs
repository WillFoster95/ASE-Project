using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Project
{
    class Triangle :Shapes
    {
        private int sideA, sideB, sideC;
        private int corner1X, corner1Y, corner2X, corner2Y, corner3X, corner3Y;
        public Triangle(int xPos, int yPos, int sideA, int sideB) : base(xPos, yPos)
        {
            corner1X = xPos - sideA/2;
            corner1Y = yPos + sideB/2;
            corner2X = xPos + sideA/2;
            corner2Y = yPos + sideB/2;
            corner3X = xPos;
            corner3Y = yPos - sideB/2;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawLine(p, corner1X, corner1Y, corner2X, corner2Y);
            g.DrawLine(p, corner2X, corner2Y, corner3X, corner3Y);
            g.DrawLine(p, corner3X, corner3Y, corner1X, corner1Y);

        }       
    }
}
