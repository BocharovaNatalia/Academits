using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vectors
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(5);
            Vector v2 = new Vector(v1);
            Vector v3 = new Vector(new double[] { 1, 4, 7, 8, 9 });
            Vector v4 = new Vector(new double[] { 0, 3, 5, 8, 10, 12, 14 });

            Console.WriteLine(v1.ToString());
            Console.WriteLine(v2.ToString());
            Console.WriteLine(v3.ToString());
            Console.WriteLine(v4.ToString());

            Vector v5 = v3.GetSum(v4);

            Console.WriteLine(v5.GetSize());

            Vector v6 = v2.GetDifference(v4);

            Console.WriteLine(v6.GetScalarProduct(2));

            Console.WriteLine(v4.GetTurn());

            Console.WriteLine(v3.GetLength());

            Vector v7 = Vector.GetDifference(v4, v3);

            Console.WriteLine(v7.ToString());

            Console.WriteLine(v7.GetElementByIndex(1));

            Vector v8 = Vector.GetScalarProductVectors(v4, v3);

            Vector v9 = Vector.GetSum(v7, v8);

            Console.WriteLine(v7.ToString());
        }
    }
}


