using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : Shape
    {
        public double SideLength1
        {
            get;
            set;
        }

        public double SideLength2
        {
            get;
            set;
        }

        public Rectangle(double sideLength1, double sideLength2)
        {
            SideLength1 = sideLength1;
            SideLength2 = sideLength2;
        }

        public override double GetWidth()
        {
            return SideLength1;
        }

        public override double GetHeight()
        {
            return SideLength2;
        }

        public override double GetArea()
        {
            return SideLength1 * SideLength2;
        }

        public override double GetPerimeter()
        {
            return (SideLength1 + SideLength2) * 2;
        }

        public override string ToString()
        {
            double[] sideLengths = { SideLength1, SideLength2 };
            return "Прямоугольник, длины сторон : " + string.Join(" , ", sideLengths);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType()) return false;
            Rectangle r = (Rectangle)obj;
            return SideLength1 == r.SideLength1 && SideLength2 == r.SideLength2;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + (int)SideLength1;
            hash = prime * hash + (int)SideLength2;
            return hash;
        }
    }
}
