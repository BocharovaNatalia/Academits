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
            if (To < range.From || range.To < From)
            {
                return null;
            }

            double[] array = { To, From, range.To, range.From };
            Array.Sort(array);

            Range intersectionRanges = new Range(array[1], array[2]);
            return intersectionRanges;
        }

        public Range[] GetUnion(Range range)
        {
            Range[] unionRangesArray = null;
            if (To < range.From || range.To < From)
            {
                unionRangesArray = new Range[2];
                Range newRange1 = new Range(From, To);
                Range newRange2 = new Range(range.From, range.To);

                unionRangesArray[0] = newRange1;
                unionRangesArray[1] = newRange2;

                return unionRangesArray;
            }

            double[] array = { To, From, range.To, range.From };
            Array.Sort(array);

            Range unionRanges = new Range(array[0], array[3]);
            unionRangesArray = new Range[1];
            unionRangesArray[0] = unionRanges;

            return unionRangesArray;
        }

        public Range[] GetDifference(Range range)
        {
            Range[] differenceRangesArray = null;
            double[] array = { To, From, range.To, range.From };
            Array.Sort(array);

            if ((From < range.From && range.To < To) || (range.From < From && To < range.To))
            {
                differenceRangesArray = new Range[2];
                Range newRange1 = new Range(array[0], array[1]);
                Range newRange2 = new Range(array[2], array[3]);

                differenceRangesArray[0] = newRange1;
                differenceRangesArray[1] = newRange2;

                return differenceRangesArray;
            }

            Range differenceRanges = new Range(array[0], array[1]);
            differenceRangesArray = new Range[1];
            differenceRangesArray[0] = differenceRanges;

            return differenceRangesArray;
        }

        public void Print()
        {
            Console.WriteLine("({0}, {1})", From, To);
        }
    }
}




