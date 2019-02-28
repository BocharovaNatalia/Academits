using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape s1, IShape s2)
        {
            return s1.GetArea().CompareTo(s2.GetArea());
        }
    }
}

