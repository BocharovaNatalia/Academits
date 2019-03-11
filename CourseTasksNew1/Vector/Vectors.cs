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
            Vector v3 = new Vector(new double[] { 1, 2, 3, 4, 5, 6, 2 });
            Vector v4 = new Vector(new double[] { 0, 3, 5, 8, 10, 12, 14 });

            Console.WriteLine(v1.ToString());
            Console.WriteLine(v2.ToString());
            Console.WriteLine(v3.ToString());
            Console.WriteLine(v4.ToString());

            Console.WriteLine(v4.GetSum(v3));

            Console.WriteLine(v4.ToString());

            Vector v5 = new Vector(v3.GetDifference(v4));

            Console.WriteLine(v5.GetSize());

            Console.WriteLine(v3.GetTurn());

            Console.WriteLine(v5.GetProductWithScalar(2));

            Console.WriteLine(v5.GetElementByIndex(6));

            Console.WriteLine(v1.Equals(v2));

            v1.SetElementByIndex(0, 7);
            Console.WriteLine(v1.ToString());

            Console.WriteLine(v2.ToString());

            Vector v6 = Vector.GetSum(v1, v2);
            Console.WriteLine(v6.ToString());

            double scalarProduct = Vector.GetScalarProductOfVectors(v1, v6);
            Console.WriteLine(scalarProduct);
        }
    }
}


