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

            Range intersectionRanges = new Range((From > range.From) ? From : range.From, (To < range.To) ? To : range.To);
            return intersectionRanges;
        }

        public Range[] GetUnion(Range range)
        {
            if (To < range.From || range.To < From)
            {
                Range newRange1 = new Range(From, To);
                Range newRange2 = new Range(range.From, range.To);

                return new Range[] { newRange1, newRange2 };
            }

            Range unionRanges = new Range((From < range.From) ? From : range.From, (To > range.To) ? To : range.To);
            return new Range[] { unionRanges };
        }

        public Range[] GetDifference(Range range)
        {
            if (To <= range.From || range.To <= From)
            {
                Range differenceRanges = new Range(From, To);
                return new Range[] { differenceRanges };
            }
            else if (From <= range.From && range.To >= To)
            {
                Range differenceRanges = new Range(From, range.From);
                return new Range[] { differenceRanges };
            }
            else if (From < range.From)
            {
                Range newRange1 = new Range(From, range.From);
                Range newRange2 = new Range(range.To, To);

                return new Range[] { newRange1, newRange2 };
            }

            return new Range[] { null };
        }

        public void Print()
        {
            Console.WriteLine("({0}, {1})", From, To);
        }
    }
}




