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
            Components = v.Components;
        }

        public Vector(double[] components)
        {
            Components = new double[components.Length];

            Array.Copy(components, Components, components.Length);
        }

        public Vector(double[] components, int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("dimension must be > 0", nameof(dimension));
            }

            Components = new double[dimension];

            Array.Copy(components, Components, components.Length);

            if (dimension > components.Length)
            {
                for (int i = components.Length; i < dimension; i++)
                {
                    Components[i] = 0;
                }
            }
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            return string.Format("{{ {0} }}", string.Join(",", Components));
        }

        public Vector GetSum(Vector v)
        {
            if (GetSize() < v.GetSize())
            {
                double[] newComponents = new double[v.Components.Length];

                for (int i = 0; i < v.Components.Length; i++)
                {
                    if (i < Components.Length)
                    {
                        newComponents[i] = v.Components[i] + Components[i];
                    }
                    newComponents[i] = v.Components[i];
                }

                return new Vector(newComponents);
            }

            Vector vector = new Vector(this);

            for (int i = 0; i < Components.Length; i++)
            {
                if (i < v.Components.Length)
                {
                    vector.Components[i] = v.Components[i] + Components[i];
                }
                vector.Components[i] = Components[i];
            }

            return vector;
        }

        public Vector GetDifference(Vector v)
        {
            if (GetSize() < v.GetSize())
            {
                double[] newComponents = new double[v.Components.Length];

                for (int i = 0; i < v.Components.Length; i++)
                {
                    if (i < Components.Length)
                    {
                        newComponents[i] = Components[i] - v.Components[i];
                    }
                    newComponents[i] = -v.Components[i];
                }

                return new Vector(newComponents);
            }

            Vector vector = new Vector(this);

            for (int i = 0; i < Components.Length; i++)
            {
                if (i < v.Components.Length)
                {
                    vector.Components[i] -= v.Components[i];
                }

                vector.Components[i] = Components[i];
            }

            return vector;
        }

        public Vector GetProductWithScalar(int scalar)
        {
            Vector vector = new Vector(this);

            for (int i = 0; i < vector.Components.Length; i++)
            {
                vector.Components[i] *= scalar;
            }

            return vector;
        }

        public Vector GetTurn()
        {
            Vector vector = new Vector(this);

            int turnIndex = -1;

            for (int i = 0; i < vector.Components.Length; i++)
            {
                vector.Components[i] *= turnIndex;
            }

            return vector;
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
                throw new ArgumentOutOfRangeException("index must be >=0 and < vector's size", nameof(index));
            }

            return Components[index];
        }

        public void SetElementByIndex(int index, double element)
        {
            if (index >= GetSize() || index < 0)
            {
                throw new ArgumentOutOfRangeException("index must be >=0 and < vector's size", nameof(index));
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

            return Components.Length == v.Components.Length && IsComponentsEquals(Components, v.Components);
        }

        public bool IsComponentsEquals(double[] array1, double[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                const double epsilon = 1.0e-10;
                if (Math.Abs(array1[i] - array2[i]) > epsilon)
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

            for (int i = 0; i < Components.Length; i++)
            {
                hash = prime * hash + Components[i].GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector v1, Vector v2)
        {
            Vector newVector = new Vector(v1.Components);
            return newVector.GetSum(v2);
        }

        public static Vector GetDifference(Vector v1, Vector v2)
        {
            Vector newVector = new Vector(v1.Components);
            return newVector.GetDifference(v2);
        }

        public static double GetScalarProductOfVectors(Vector v1, Vector v2)
        {
            int minLength = Math.Min(v1.Components.Length, v2.Components.Length);

            double scalarProductOfVector = 0;

            for (int i = 0; i < minLength; i++)
            {
                scalarProductOfVector += v1.Components[i] * v2.Components[i];
            }

            return scalarProductOfVector;
        }
    }
}


