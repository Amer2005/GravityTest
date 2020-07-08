using Assets.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controllers
{
    public class GameController
    {
        public GravityObjectModel[] GravityObjects { get; set; }

        GravityObjectService gravityObjectService;

        public int CenterIndex { get; set; }

        public GameController(GravityObjectModel[] gravityObjects, int centerIndex)
        {
            GravityObjects = gravityObjects;
            gravityObjectService = new GravityObjectService();
            CenterIndex = centerIndex;
        }
        
        public void UpdatePositions()
        {
            foreach (var gravityObject in GravityObjects)
            {
                gravityObjectService.UpdateVelocity(gravityObject, GravityObjects);
            }

            for (int i = 0; i < GravityObjects.Length; i++)
            {
                if (CenterIndex != -1)
                {
                    if (CenterIndex != i)
                    {
                        gravityObjectService.UpdatePosition(GravityObjects[i], GravityObjects[CenterIndex].Position);
                    }
                }

                if (CenterIndex == -1)
                {
                    gravityObjectService.UpdatePosition(GravityObjects[i]);
                }
            }

            if (CenterIndex != -1)
            {
                gravityObjectService.UpdatePosition(GravityObjects[CenterIndex], GravityObjects[CenterIndex].Position);
            }
        }

    }
}
