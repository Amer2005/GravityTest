using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Services;

namespace Assets.Scripts.Services
{
    public class GravityObjectService
    {
        private VectorService vectorService;

        const float gravitationalConstant = 1f;
        const float physicsTimeStep = 0.001f;

        public GravityObjectService()
        {
            vectorService = new VectorService();
        }

        public void UpdateVelocity(GravityObjectModel objectNow, GravityObjectModel[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if(objects[i] != objectNow)
                {
                    float sqrtDst = vectorService.SqrMagnitude(objects[i].Position - objectNow.Position);
                    Vector forceDir = vectorService.Normilize(objects[i].Position - objectNow.Position);
                    Vector force = forceDir * gravitationalConstant * objectNow.Mass * objects[i].Mass / sqrtDst;
                    Vector acceleration = force / objectNow.Mass;
                    objectNow.Velocity = objectNow.Velocity + force * physicsTimeStep;
                }
            }
        }

        public void UpdatePosition(GravityObjectModel objectNow, Vector centerPosition)
        {
            objectNow.Position = objectNow.Position + objectNow.Velocity * physicsTimeStep - centerPosition;
        }

        public void UpdatePosition(GravityObjectModel objectNow)
        {
            objectNow.Position = objectNow.Position + objectNow.Velocity * physicsTimeStep;
        }
    }
}
