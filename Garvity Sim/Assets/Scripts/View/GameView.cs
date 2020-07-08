using Assets.Scripts.Controllers;
using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class GameView : MonoBehaviour
    {
        GameObject[] gravityGameObjects;

        VectorUtilities vectorUtilities;

        GameController gameController;

        public GameObject FocusGameObject;

        private void Awake()
        {
            gravityGameObjects = GameObject.FindGameObjectsWithTag("GravityObject");
            vectorUtilities = new VectorUtilities();

            GenerateGravityObjects();
        }

        private void GenerateGravityObjects()
        {
            var gravityObjects = new GravityObjectModel[gravityGameObjects.Length];

            int centerIndex = -1;

            for (int i = 0; i < gravityObjects.Length; i++)
            {
                if(gravityGameObjects[i] == FocusGameObject)
                {
                    centerIndex = i;
                }

                Vector position = new Vector();
                Vector velocity = new Vector();

                GravityGameObjectProperties properties = gravityGameObjects[i].GetComponent<GravityGameObjectProperties>();

                vectorUtilities.MakeFristVectorEqualSecondVector(position, gravityGameObjects[i].transform.position);
                vectorUtilities.MakeFristVectorEqualSecondVector(velocity, properties.StartVelocity);

                gravityObjects[i] = new GravityObjectModel(properties.Mass, position, velocity);
            }

            gameController = new GameController(gravityObjects, centerIndex);
        }

        private void FixedUpdate()
        {
            gameController.UpdatePositions();

            Debug.Log(gameController.GravityObjects[0].Position);

            UpdateGameObjectPositions();
        }

        private void UpdateGameObjectPositions()
        {
            for (int i = 0; i < gravityGameObjects.Length; i++)
            {
                Vector3 vector3 = new Vector3();

                vectorUtilities.MakeFristVectorEqualSecondVector(ref vector3, gameController.GravityObjects[i].Position);

                gravityGameObjects[i].transform.position = vector3;
            }
        }
    }
}
