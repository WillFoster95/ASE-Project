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
        public Triangle(int xPos, int yPos, int sideA, int sideB, int sideC) : base(xPos, yPos)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawPolygon(p, )
        }
    }
}
