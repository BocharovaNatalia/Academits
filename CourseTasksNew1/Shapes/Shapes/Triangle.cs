using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shapes
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

        protected static double GetMaxPoint(double point1, double point2, double point3)
        {
            return Math.Max(point1, Math.Max(point2, point3));
        }

        protected static double GetMinPoint(double point1, double point2, double point3)
        {
            return Math.Min(point1, Math.Min(point2, point3));
        }

        protected static double GetSectionLength(double point1, double point2, double point3)
        {
            return GetMaxPoint(point1, point2, point3) - GetMinPoint(point1, point2, point3);
        }

        public double GetWidth()
        {
            return GetSectionLength(X1, X2, X3);
        }

        public double GetHeight()
        {
            return GetSectionLength(Y1, Y2, Y3);
        }

        protected static double GetSideLength(double coordinateX1, double coordinateX2, double coordinateY1, double coordinateY2)
        {
            return Math.Sqrt(Math.Pow((coordinateX1 - coordinateX2), 2) + Math.Pow((coordinateY1 - coordinateY2), 2));
        }

        public double GetLength1()
        {
            return GetSideLength(X2, X1, Y2, Y1);
        }

        public double GetLength2()
        {
            return GetSideLength(X3, X2, Y3, Y2);
        }

        public double GetLength3()
        {
            return GetSideLength(X3, X1, Y3, Y1);
        }

        public double GetPerimeter()
        {
            return GetLength1() + GetLength2() + GetLength3();
        }

        public double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - GetLength1()) * (halfPerimeter - GetLength2()) * (halfPerimeter - GetLength3()));
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
            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
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
