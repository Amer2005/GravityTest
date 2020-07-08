using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class VectorUtilities
    {
        public void MakeFristVectorEqualSecondVector(Vector first, Vector3 second)
        {
            first.X = second.x;
            first.Y = second.y;
            first.Z = second.z;
        }

        public void MakeFristVectorEqualSecondVector(ref Vector3 first, Vector second)
        {
            first.x = second.X;
            first.y = second.Y;
            first.z = second.Z;
        }

        public float VectorSqrMagnitude(Vector vector)
        {
            Vector3 vector3 = new Vector3();

            MakeFristVectorEqualSecondVector(ref vector3, vector);

            return vector3.sqrMagnitude;
        }

        public Vector VectorNormalized(Vector vector)
        {
            Vector3 vector3 = new Vector3();

            MakeFristVectorEqualSecondVector(ref vector3, vector);

            Vector result = new Vector();

            MakeFristVectorEqualSecondVector(result, vector3.normalized);

            return result;
        }
    }
}
