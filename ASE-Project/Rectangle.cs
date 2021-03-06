﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Project
{
    class Rectangle : Shapes
    {
        private int width, height;

        public Rectangle()
        {

        }

        public Rectangle(int xPos, int yPos, int width, int height) : base(xPos, yPos)
        {
            this.width = width;
            this.height = height;
        }

        public override void setParams(params int[] dimensions)
        {            
            base.setParams(dimensions[0], dimensions[1]);
            this.width = dimensions[2];
            this.height = dimensions[3];
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawRectangle(p, xPos - width/2, yPos - height/2, width, height);
        }
    }
}
