using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : IShape
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

        public double GetWidth()
        {
            return SideLength1;
        }

        public double GetHeight()
        {
            return SideLength2;
        }

        public double GetArea()
        {
            return SideLength1 * SideLength2;
        }

        public double GetPerimeter()
        {
            return (SideLength1 + SideLength2) * 2;
        }

        public override string ToString()
        {
            return string.Format("Прямоугольник, длины сторон : {0} , {1} ", SideLength1, SideLength2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }
            Rectangle r = (Rectangle)obj;
            return SideLength1 == r.SideLength1 && SideLength2 == r.SideLength2;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + SideLength1.GetHashCode();
            hash = prime * hash + SideLength2.GetHashCode();
            return hash;
        }
    }
}
