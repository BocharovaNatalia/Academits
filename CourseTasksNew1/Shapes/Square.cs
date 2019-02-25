using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : Shape
    {
        public double SideLength
        {
            get;
            set;
        }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public override double GetWidth()
        {
            return SideLength;
        }

        public override double GetHeight()
        {
            return SideLength;
        }

        public override double GetArea()
        {
            return SideLength * SideLength;
        }

        public override double GetPerimeter()
        {
            return SideLength * 4;
        }

        public override string ToString()
        {
            return "Квадрат, длина стороны = " + SideLength;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType()) return false;
            Square s = (Square)obj;
            return SideLength == s.SideLength;
        }

        public override int GetHashCode()
        {
            return (int)SideLength;
        }
    }
}
