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
            if (From >= range.From && To <= range.To)
            {
                return this;
            }

            if (From <= range.From && To >= range.To && From <= range.To)
            {
                return range;
            }

            if (From <= range.From)
            {
                Range intersectionRanges = new Range(range.From, To);
                return intersectionRanges;
            }

            if (From <= range.To)
            {
                Range intersectionRanges = new Range(From, range.To);
                return intersectionRanges;
            }

            return null;
        }

        public Range[] GetUnion(Range range)
        {
            Range[] unionRanges = new Range[2];

            if (From >= range.From && To <= range.To)
            {
                unionRanges[0] = range;
            }
            else if (From <= range.From && To >= range.To && From <= range.To)
            {
                unionRanges[0] = this;
            }
            else if (From <= range.From)
            {
                Range newRange = new Range(From, range.To);
                unionRanges[0] = newRange;
            }
            else if (From <= range.To)
            {
                Range newRange = new Range(range.From, To);
                unionRanges[0] = newRange;
            }

            else
            {
                unionRanges[0] = range;
                unionRanges[1] = this;
            }

            return unionRanges;
        }

        public Range[] GetDifference(Range range)
        {
            Range[] differenceRanges = new Range[2];

            if (To < range.From)
            {
                differenceRanges[0] = this;
            }
            else if (range.From <= To && range.To <= To)
            {
                differenceRanges[0] = new Range(From, range.From);
                differenceRanges[1] = new Range(range.To, To);
            }
            else if (From <= range.To && From <= range.From)
            {
                Range newRange = new Range(From, range.From);
                differenceRanges[0] = newRange;
            }

            return differenceRanges;
        }

        public void Print()
        {
            Console.WriteLine("({0}, {1})", From, To);
        }
    }

    class RangeNumbers
    {
        public static void Main(string[] args)
        {
            Range range1 = new Range(1, 6);
            Console.WriteLine("Длина диапазона чисел = " + range1.GetLength());

            Range range2 = new Range(3, 5);
            bool isNumberInside = range2.IsInside(10);

            if (isNumberInside)
            {
                Console.WriteLine("Число находится внутри диапазона");
            }
            else
            {
                Console.WriteLine("Число не находится внутри диапазона");
            }

            Range intersectionRanges = range1.GetIntersection(range2);

            if (intersectionRanges == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                intersectionRanges.Print();
            }

            Range[] unionRanges = range1.GetUnion(range2);
            for (int i = 0; i < unionRanges.Length; i++)
            {
                if (unionRanges[i] == null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    unionRanges[i].Print();
                }
            }

            Range[] differenceRanges = range1.GetDifference(range2);
            for (int i = 0; i < differenceRanges.Length; i++)
            {
                if (differenceRanges[i] == null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    differenceRanges[i].Print();
                }
            }
        }
    }
}




