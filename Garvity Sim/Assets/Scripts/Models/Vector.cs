using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utilities
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector() : this(0, 0, 0) 
        {
            
        }

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator *(Vector a, float b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator /(Vector a, float b)
        {
            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }
    }
}
