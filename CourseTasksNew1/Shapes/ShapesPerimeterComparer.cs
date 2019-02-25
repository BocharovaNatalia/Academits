using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ShapesPerimeterComparer : IComparer<Shape>
    {
        public int Compare(Shape s1, Shape s2)
        {
            if (s1.GetPerimeter() > s2.GetPerimeter()) return 1;
            if (s1.GetPerimeter() < s2.GetPerimeter()) return -1;
            return 0;
        }
    }
}
