using SFML.Graphics;
using SFML.System;
using System.Collections;

namespace LTI.RobotSimulator.Core.Geometry
{
    /// <summary>
    /// A classic drawable point.
    /// </summary>
    public class Point : CircleShape
    {
        public Point() : base(5)
        {
            Origin = new Vector2f(5, 5);
        }

        public Point(Vector2f position) : this()
        {
            Position = position;
        }
    }

    /// <summary>
    /// A point for drawing a point cloud.
    /// </summary>
    public sealed class CloudPoint : Point
    {
        public CloudPoint() : base()
        {
            Radius = 2;
            Origin = new Vector2f(2, 2);
        }

        public CloudPoint(Vector2f position) : this()
        {
            Position = position;
        }

        public float DistanceFromSensor { get; set; }
    }

    /// <summary>
    /// A point that has a theta value and telemetry data.
    /// </summary>
    public sealed class TrajectoryPoint : Point
    {
        public TrajectoryPoint(Vector2f position, float theta) : base(position)
        {
            Radius = 2;
            Origin = new Vector2f(2, 2);
            Theta = theta;
            PointsFoundBySensors = new ArrayList();
        }

        public float Theta { get; private set; }
        public ArrayList PointsFoundBySensors { get; private set; } // Contains telemetry data (point objects)
    }
}