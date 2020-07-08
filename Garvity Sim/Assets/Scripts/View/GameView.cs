using Assets.Scripts.Controllers;
using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class GameView : MonoBehaviour
    {
        GameObject[] gravityGameObjects;

        VectorUtilities vectorUtilities;

        GameController gameController;

        public GameObject FocusGameObject;

        public bool CenterPlanets;

        bool started;

        private void Awake()
        {
            //StartSim();
            started = false;
        }

        public void StartSim()
        {
            gravityGameObjects = GameObject.FindGameObjectsWithTag("GravityObject");
            vectorUtilities = new VectorUtilities();

            GenerateGravityObjects();
            started = true;
        }

        private void GenerateGravityObjects()
        {
            var gravityObjects = new GravityObjectModel[gravityGameObjects.Length];

            int centerIndex = -1;

            for (int i = 0; i < gravityObjects.Length; i++)
            {
                if (gravityGameObjects[i] == FocusGameObject)
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

            if(!CenterPlanets)
            {
                centerIndex = -1;
            }

            gameController = new GameController(gravityObjects, centerIndex); //centerIndex
        }

        private void FixedUpdate()
        {
            if (started)
            {
                gameController.UpdatePositions();

                UpdateGameObjectPositions();
            }
        }

        private void UpdateGameObjectPositions()
        {
            for (int i = 0; i < gravityGameObjects.Length; i++)
            {
                Vector3 pos = new Vector3();

                vectorUtilities.MakeFristVectorEqualSecondVector(ref pos, gameController.GravityObjects[i].Position);

                Vector3 velocity = new Vector3();

                vectorUtilities.MakeFristVectorEqualSecondVector(ref velocity, gameController.GravityObjects[i].Velocity);

                gravityGameObjects[i].GetComponent<GravityGameObjectProperties>().StartVelocity = velocity;

                gravityGameObjects[i].transform.position = pos;
            }
        }
    }
}
