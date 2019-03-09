using System;
using Shapes.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Comparers
{
    class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape s1, IShape s2)
        {
            return s1.GetPerimeter().CompareTo(s2.GetPerimeter());
        }
    }
}

