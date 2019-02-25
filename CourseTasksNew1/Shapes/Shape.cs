using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape : IShape
    {
        public abstract double GetWidth();
        public abstract double GetHeight();
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
