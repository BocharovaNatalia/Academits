using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class RangeNumbers
    {
        public static void Main(string[] args)
        {
            Range range1 = new Range(1, 7);
            Console.WriteLine("Длина диапазона чисел = " + range1.GetLength());

            Range range2 = new Range(1, 7);
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
                Console.WriteLine("Пересечение интервалов: ");
                intersectionRanges.Print();
            }

            Range[] unionRanges = range1.GetUnion(range2);
            Console.WriteLine("Объединение интервалов: ");
            foreach (Range е in unionRanges)
            {
                е.Print();
            }

            Range[] differenceRanges = range1.GetDifference(range2);
            Console.WriteLine("Разность интервалов: ");
            foreach (Range е in differenceRanges)
            {
                е.Print();
            }
        }
    }
}
