using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Triangle : Shape
    {
        public double X1
        {
            get;
            set;
        }

        public double X2
        {
            get;
            set;
        }

        public double X3
        {
            get;
            set;
        }

        public double Y1
        {
            get;
            set;
        }

        public double Y2
        {
            get;
            set;
        }

        public double Y3
        {
            get;
            set;
        }

        public Triangle(double x1, double x2, double x3, double y1, double y2, double y3)
        {
            X1 = x1;
            X2 = x2;
            X3 = x3;
            Y1 = y1;
            Y2 = y2;
            Y3 = y3;
        }

        public override double GetWidth()
        {
            return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3));
        }

        public override double GetHeight()
        {
            return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
        }

        public override double GetArea()
        {
            return 0.5 * Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3)) * Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
        }

        public override double GetPerimeter()
        {
            double length1 = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
            double length2 = Math.Sqrt(Math.Pow((X3 - X2), 2) + Math.Pow((Y3 - Y2), 2));
            double length3 = Math.Sqrt(Math.Pow((X3 - X1), 2) + Math.Pow((Y3 - Y1), 2));
            return length1 + length2 + length3;
        }

        public override string ToString()
        {
            double[] tops = { X1, Y1, X2, Y2, X3, Y3 };
            return "Треугольник, координаты вершин : " + string.Join(" , ", tops);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType()) return false;
            Triangle t = (Triangle)obj;
            return X1 == t.X1 && X2 == t.X2 && X3 == t.X3 && Y1 == t.Y1 && Y2 == t.Y2 && Y3 == t.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + (int)X1;
            hash = prime * hash + (int)X2;
            hash = prime * hash + (int)X3;
            hash = prime * hash + (int)Y1;
            hash = prime * hash + (int)Y2;
            hash = prime * hash + (int)Y3;

            return hash;
        }
    }
}
