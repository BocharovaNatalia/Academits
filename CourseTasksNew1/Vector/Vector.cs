using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        private double[] Components
        {
            get;
            set;
        }

        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("dimension must be > 0", nameof(dimension));
            }

            Components = new double[dimension];
        }

        public Vector(Vector v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v), "vector can't be null");
            }

            Components = new double[v.Components.Length];
            Array.Copy(v.Components, Components, v.Components.Length);
        }

        public Vector(double[] components)
        {
            if (components == null)
            {
                throw new ArgumentNullException(nameof(components), "components can't be null");
            }

            Components = new double[components.Length];
            Array.Copy(components, Components, components.Length);
        }

        public Vector(int dimension, double[] components)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("dimension must be > 0", nameof(dimension));
            }

            if (components == null)
            {
                throw new ArgumentNullException(nameof(components), "components can't be null");
            }

            Components = new double[dimension];

            Array.Copy(components, Components, Math.Min(dimension, components.Length));
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            return string.Format("{{ {0} }}", string.Join(", ", Components));
        }

        private static Vector GetMaxVector(Vector v1, Vector v2)
        {
            if (v1.GetSize() > v2.GetSize())
            {
                return v1;
            }
            return v2;
        }

        private static Vector GetMinVector(Vector v1, Vector v2)
        {
            if (v1.GetSize() < v2.GetSize())
            {
                return v1;
            }
            return v2;
        }

        public Vector GetSum(Vector v)
        {
            Vector maxVector = GetMaxVector(this, v);
            Vector minVector = GetMinVector(this, v);

            double[] newComponents = new double[maxVector.Components.Length];

            for (int i = 0; i < maxVector.Components.Length; i++)
            {
                if (i < minVector.Components.Length)
                {
                    newComponents[i] = maxVector.Components[i] + minVector.Components[i];
                }
                else
                {
                    newComponents[i] = maxVector.Components[i];
                }
            }

            Components = newComponents;

            return this;
        }

        public Vector GetDifference(Vector v)
        {
            Vector maxVector = GetMaxVector(this, v);
            Vector minVector = GetMinVector(this, v);

            double[] newComponents = new double[maxVector.Components.Length];

            for (int i = 0; i < maxVector.Components.Length; i++)
            {
                if (i < minVector.Components.Length)
                {
                    newComponents[i] = Components[i] - v.Components[i];
                }
                else if (GetSize() < v.GetSize())
                {
                    newComponents[i] = -v.Components[i];
                }
                else
                {
                    newComponents[i] = Components[i];
                }
            }

            Components = newComponents;

            return this;
        }

        public Vector GetProductWithScalar(double scalar)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] *= scalar;
            }

            return this;
        }

        public Vector GetTurn()
        {
            int turnIndex = -1;

            GetProductWithScalar(turnIndex);

            return this;
        }

        public double GetLength()
        {
            double sumPowComponents = 0;

            foreach (double е in Components)
            {
                sumPowComponents += е * е;
            }

            return Math.Sqrt(sumPowComponents);
        }

        public double GetElementByIndex(int index)
        {
            if (index >= GetSize() || index < 0)
            {
                throw new IndexOutOfRangeException("index must be >= 0 and < vector's size");
            }

            return Components[index];
        }

        public void SetElementByIndex(int index, double element)
        {
            if (index >= GetSize() || index < 0)
            {
                throw new IndexOutOfRangeException("index must be >= 0 and < vector's size");
            }

            Components[index] = element;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector v = (Vector)obj;

            return AreComponentsEqual(Components, v.Components);
        }

        public bool AreComponentsEqual(double[] array1, double[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            foreach (double е in Components)
            {
                hash = prime * hash + е.GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector v1, Vector v2)
        {
            return new Vector(v1).GetSum(v2);
        }

        public static Vector GetDifference(Vector v1, Vector v2)
        {
            return new Vector(v1).GetDifference(v2);
        }

        public static double GetScalarProductOfVectors(Vector v1, Vector v2)
        {
            int minLength = Math.Min(v1.Components.Length, v2.Components.Length);

            double scalarProductOfVectors = 0;

            for (int i = 0; i < minLength; i++)
            {
                scalarProductOfVectors += v1.Components[i] * v2.Components[i];
            }

            return scalarProductOfVectors;
        }
    }
}


