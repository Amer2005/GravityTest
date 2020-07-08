using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Services
{
    public class VectorService
    {
        private VectorUtilities vectorUtilities;

        public VectorService()
        {
            vectorUtilities = new VectorUtilities();
        }

        public Vector Normilize(Vector vector)
        {
            return vectorUtilities.VectorNormalized(vector);
        }

        public float SqrMagnitude(Vector vector)
        {
            return vectorUtilities.VectorSqrMagnitude(vector);
        }

        public float Distance(Vector a, Vector b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
}
