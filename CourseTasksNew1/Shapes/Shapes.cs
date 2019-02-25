using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Shapes
    {
        static void Main(string[] args)
        {
            Shape c1 = new Circle(7);
            Shape s1 = new Square(8.5);
            Shape t1 = new Triangle(1, 7, 4, 5, 9, 0);
            Shape r1 = new Rectangle(5.2, 7.3);
            Shape c2 = new Circle(1.9);
            Shape s2 = new Square(10.2);
            Shape t2 = new Triangle(3, 8, 2.3, 7, 1.5, 3.8);
            Shape r2 = new Rectangle(8, 10.4);

            Shape maxAreaShape = GetMaxAreaShape(c1, c2, s1, s2, t1, t2, r1, r2);
            Console.WriteLine("Фигура с максимальной площадью : " + maxAreaShape);

            Shape secondPerimeterShape = GetSecondPerimeterShape(c1, c2, s1, s2, t1, t2, r1, r2);
            Console.WriteLine("Фигура с вторым по величине периметром : " + secondPerimeterShape);
        }

        public static Shape GetMaxAreaShape(params Shape[] shapes)
        {
            Array.Sort(shapes, new ShapesAreaComparer());
            return shapes[shapes.Length - 1];
        }

        public static Shape GetSecondPerimeterShape(params Shape[] shapes)
        {
            Array.Sort(shapes, new ShapesPerimeterComparer());
            return shapes[shapes.Length - 2];
        }
    }
}
