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
            Vector vector = new Vector(this);
            int maxLength = Math.Max(Components.Length, v.Components.Length);
            int minLength = Math.Min(Components.Length, v.Components.Length);

            for (int i = 0; i < minLength; i++)
            {
                Components[i] += v.Components[i];
            }

            if (GetSize() < v.GetSize())
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    Components[i] = v.Components[i];
                }
            }
            return vector;
        }

        public Vector GetDifference(Vector v)
        {
            int maxLength = Math.Max(Components.Length, v.Components.Length);
            int minLength = Math.Min(Components.Length, v.Components.Length);

            Vector vector = new Vector(this);

            for (int i = 0; i < minLength; i++)
            {
                vector.Components[i] -= v.Components[i];
            }

            if (vector.GetSize() > v.GetSize())
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    vector.Components[i] = vector.Components[i];
                }
            }

            if (vector.GetSize() < v.GetSize())
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    vector.Components[i] = -v.Components[i];
                }
            }

            return vector;
        }

        public Vector Get(int scalar)
            +
        {
            Vector vector = new Vector(Components, Dimension);

            for (int i = 0; i < vector.Dimension; i++)
            {
                vector.Components[i] *= scalar;
            }

            return vector;
        }

        public Vector GetTurn()
        {
            Vector vector = new Vector(Components, Dimension);

            int turnIndex = -1;

            for (int i = 0; i < vector.Dimension; i++)
            {
                vector.Components[i] *= turnIndex;
            }

            return vector;
        }

        public double GetLength()
        {
            double sumPowComponents = 0;

            for (int i = 0; i < Dimension; i++)
            {
                sumPowComponents += Components[i] * Components[i];
            }

            return Math.Sqrt(sumPowComponents);
        }

        public double GetElementByIndex(int index)
        {
            if (index > GetSize())
            {
                throw new ArgumentException("index must be <= vector's size", nameof(index));
            }

            double element = 0;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == index)
                {
                    element = Components[i];
                }
            }

            return element;
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

            return Dimension == v.Dimension && Components.Equals(v.Components);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            for (int i = 0; i < Dimension; i++)
            {
                hash = prime * hash + Components[i].GetHashCode();
            }

            return hash + Dimension;
        }

        public static Vector GetSum(Vector v1, Vector v2)
        {
            int maxLength = Math.Max(v1.Dimension, v2.Dimension);
            int minLength = Math.Min(v1.Dimension, v2.Dimension);

            Vector vector = new Vector(maxLength);

            for (int i = 0; i < minLength; i++)
            {
                vector.Components[i] = v1.Components[i] + v2.Components[i];
            }

            if (v1.GetSize() > v2.GetSize())
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    vector.Components[i] = v1.Components[i];
                }
            }

            if (v1.GetSize() < v2.GetSize())
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    vector.Components[i] = v2.Components[i];
                }
            }

            return vector;
        }

        public static Vector GetDifference(Vector v1, Vector v2)
        {
            int maxLength = Math.Max(v1.Dimension, v2.Dimension);
            int minLength = Math.Min(v1.Dimension, v2.Dimension);

            Vector vector = new Vector(maxLength);

            for (int i = 0; i < minLength; i++)
            {
                vector.Components[i] = v1.Components[i] - v2.Components[i];
            }

            if (v1.GetSize() > v2.GetSize())
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    vector.Components[i] = v1.Components[i];
                }
            }

            if (v1.GetSize() < v2.GetSize())
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    vector.Components[i] = -v2.Components[i];
                }
            }

            return vector;
        }

        public static Vector GetScalarProductVectors(Vector v1, Vector v2)
        {
            int maxLength = Math.Max(v1.Dimension, v2.Dimension);
            int minLength = Math.Min(v1.Dimension, v2.Dimension);

            Vector vector = new Vector(maxLength);

            for (int i = 0; i < minLength; i++)
            {
                vector.Components[i] = v1.Components[i] * v2.Components[i];
            }

            if (v1.GetSize() > v2.GetSize() || v1.GetSize() < v2.GetSize())
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    vector.Components[i] = 0;
                }
            }

            return vector;
        }
    }
}


