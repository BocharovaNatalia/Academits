using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Triangle : IShape
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

        public double GetWidth()
        {
            return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3));
        }

        public double GetHeight()
        {
            return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
        }

        public double GetLength1()
        {
            return Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
        }

        public double GetLength2()
        {
            return Math.Sqrt(Math.Pow((X3 - X2), 2) + Math.Pow((Y3 - Y2), 2));
        }

        public double GetLength3()
        {
            return Math.Sqrt(Math.Pow((X3 - X1), 2) + Math.Pow((Y3 - Y1), 2));
        }

        public double GetPerimeter()
        {
            return this.GetLength1() + this.GetLength2() + this.GetLength3();
        }

        public double GetArea()
        {
            double halfPerimeter = this.GetPerimeter() / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - this.GetLength1()) * (halfPerimeter - this.GetLength2()) * (halfPerimeter - this.GetLength3()));
        }

        public override string ToString()
        {
            return string.Format("Треугольник, координаты вершин : ({0},{1}), ({2},{3}), ({4},{5})", X1, Y1, X2, Y2, X3, Y3);
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
            Triangle t = (Triangle)obj;
            return X1 == t.X1 && X2 == t.X2 && X3 == t.X3 && Y1 == t.Y1 && Y2 == t.Y2 && Y3 == t.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}
