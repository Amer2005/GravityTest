using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;

public class GravityObjectModel
{
    public float Mass { get; set; }

    public Vector Position { get; set; }

    public Vector Velocity { get; set; }

    public GravityObjectModel(float mass, Vector position, Vector velocity)
    {
        Mass = mass;
        Position = position;
        Velocity = velocity;
    }
}
