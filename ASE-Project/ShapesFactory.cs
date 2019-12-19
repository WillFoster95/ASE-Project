using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Project
{
    class ShapesFactory
    {
        public Shapes getShape(String shapeName)
        {
            shapeName= shapeName.ToLower().Trim(); //yoi could argue that you want a specific word string to create an object but I'm allowing any case combination


            if (shapeName.Equals("circle"))
            {
                return new Circle();

            }
            else if (shapeName.Equals("rectangle"))
            {
                return new Rectangle();
            }
            else if (shapeName.Equals("line"))
            {
                return new Line();
            }
            else if (shapeName.Equals("triangle"))
            {
                return new Triangle();
            }
            else
            {
                //if we get here then what has been passed in is inkown so throw an appropriate exception
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeName + " does not exist");
                throw argEx;
            }


        }
    }
}
