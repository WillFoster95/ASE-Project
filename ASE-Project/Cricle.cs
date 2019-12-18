using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Project
{
    class Circle : Shapes
    {
        private int radius;
        public Circle(int xPos, int yPos, int radius) : base(xPos, yPos)
        {
            this.radius = radius;
        }
        public override void setParams(params int[] dimensions)
        {
            base.setParams(dimensions[0], dimensions[1]);
            this.radius = dimensions[2];            
        }
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawEllipse(p, xPos, yPos, radius * 2, radius * 2);
        }
    }
}
