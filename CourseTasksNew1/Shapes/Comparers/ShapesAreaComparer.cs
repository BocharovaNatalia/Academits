using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape s1, IShape s2)
        {
            return s2.GetArea().CompareTo(s1.GetArea());
        }
    }
}
