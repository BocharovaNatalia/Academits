using System;
using Shapes.Shapes;
using Shapes.Comparers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Shape
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(7);
            Square s1 = new Square(8.5);
            Triangle t1 = new Triangle(1, 7, 4, 5, 9, 0);
            Rectangle r1 = new Rectangle(5.2, 7.3);
            Circle c2 = new Circle(1.9);
            Square s2 = new Square(10.2);
            Triangle t2 = new Triangle(3, 8, 2.3, 7, 1.5, 3.8);
            Rectangle r2 = new Rectangle(8, 20.4);

            IShape maxAreaShape = GetMaxAreaShape(c1, c2, s1, s2, t1, t2, r1, r2);
            Console.WriteLine("Фигура с максимальной площадью : " + maxAreaShape);

            IShape secondPerimeterShape = GetSecondPerimeterShape(c1, c2, s1, s2, t1, t2, r1, r2);
            Console.WriteLine("Фигура с вторым по величине периметром : " + secondPerimeterShape);
        }

        public static IShape GetMaxAreaShape(params IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesAreaComparer());
            return shapes[0];
        }

        public static IShape GetSecondPerimeterShape(params IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesPerimeterComparer());
            return shapes[shapes.Length - 2];
        }
    }
}
