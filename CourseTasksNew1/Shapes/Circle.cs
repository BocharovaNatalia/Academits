using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : Shape
    {
        public double Radius
        {
            get;
            set;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetWidth()
        {
            return Radius * 2;
        }

        public override double GetHeight()
        {
            return Radius * 2;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return "Окружность, радиус = " + Radius;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType()) return false;
            Circle c = (Circle)obj;
            return Radius == c.Radius;
        }

        public override int GetHashCode()
        {
            return (int) Radius;
        }
    }
}
