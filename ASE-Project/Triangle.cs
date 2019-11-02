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
            corner1X = xPos;
            corner1Y = yPos;
            corner2X = xPos + sideA;
            corner2Y = yPos;
            corner3X = xPos + sideA;
            corner3Y = yPos + sideB;
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
