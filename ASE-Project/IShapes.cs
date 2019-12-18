using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Project
{
    interface IShapes
    {
        void setParams(params int[] dimensions);
        void draw(Graphics g);
        
    }
}
