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
        protected float _x, _y;

        public Point() : base(5F)
        {
            //FillColor = Color.White;
        }

        public Point(Vector2f position) : this()
        {
            Origin = new Vector2f(5.0F, 5.0F);
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

        }

        public CloudPoint(Vector2f position) : base(position)
        {
            Radius = 2F;
            Origin = new Vector2f(2F, 2F);
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
            Radius = 2F;
            Origin = new Vector2f(2F, 2F);
            Theta = theta;
            PointsFoundBySensors = new ArrayList();
        }

        public float Theta { get; private set; }
        public ArrayList PointsFoundBySensors { get; private set; } // Contains telemetry data (point objects)
    }
}