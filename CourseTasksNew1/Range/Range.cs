using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    public class Range
    {
        public double From
        {
            get;
            set;
        }

        public double To
        {
            get;
            set;
        }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            double epsilon = 1.0e-10;
            return number - From >= -epsilon && To - number >= -epsilon;
        }

        public Range GetIntersection(Range range)
        {
            if (To <= range.From || range.To <= From)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if (To < range.From || range.To < From)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (To <= range.From || range.To <= From)
            {
                return new Range[] { new Range(From, To) };
            }
            else if (From < range.From && range.To >= To)
            {
                return new Range[] { new Range(From, range.From) };
            }
            else if (From < range.From)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }
            else if (To > range.To)
            {
                return new Range[] { new Range(range.To, To) };
            }

            return new Range[] { };
        }

        public void Print()
        {
            Console.WriteLine("({0}, {1})", From, To);
        }
    }
}




