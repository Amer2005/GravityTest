using Assets.Scripts.Controllers;
using Assets.Scripts.Services;
using Assets.Scripts.Utilities;
using Assets.Scripts.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOrbits : MonoBehaviour
{
    GameObject[] gravityGameObjects;

    VectorUtilities vectorUtilities;

    VectorService vectorService;

    GameController gameController;

    GameObject FocusGameObject;

    public int numberOfTurns = 1000;

    public GameView gameView;

    private float nextActionTime = 0.0f;
    public float period = 1f;

    private void Awake()
    {
        DrawOrbitStart();
    }

    private void FixedUpdate()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            DrawOrbitStart();
        }
    }

    public void DrawOrbitStart()
    {
        gravityGameObjects = GameObject.FindGameObjectsWithTag("GravityObject");
        vectorUtilities = new VectorUtilities();
        vectorService = new VectorService();

        FocusGameObject = gameView.FocusGameObject;

        GenerateGravityObjects();

        DrawOrbit();
    }

    private void DrawOrbit()
    {
        var points = new Vector[numberOfTurns, gameController.GravityObjects.Length];

        int numberOfTurns2 = numberOfTurns;

        for (int i = 0; i < numberOfTurns; i++)
        {
            for(int j = 0;j < gameController.GravityObjects.Length;j++)
            {
                points[i,j] = gameController.GravityObjects[j].Position;

                for(int k = j + 1;k < gameController.GravityObjects.Length;k++)
                {
                    if(vectorService.Distance(gameController.GravityObjects[j].Position, gameController.GravityObjects[k].Position) < 0.5f)
                    {
                        numberOfTurns2 = i;
                        break;
                    }
                }
            }
            gameController.UpdatePositions();
        }

        for (int i = 1; i < numberOfTurns2; i++)
        {
            for (int j = 0; j < gameController.GravityObjects.Length; j++)
            {
                Vector3 point1 = new Vector3();
                Vector3 point2 = new Vector3();

                vectorUtilities.MakeFristVectorEqualSecondVector(ref point1, points[i - 1, j]);
                vectorUtilities.MakeFristVectorEqualSecondVector(ref point2, points[i, j]);

                Debug.DrawLine(point1, point2, gravityGameObjects[j].GetComponent<MeshRenderer>().material.color, period, false);
            }
        }
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

        if (!gameView.CenterPlanets)
        {
            centerIndex = -1;
        }

        gameController = new GameController(gravityObjects, centerIndex); //centerIndex
    }
}
