using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using SFML.System;

namespace LTI.RobotSimulator.Core
{
    public sealed partial class Sensor : CircleShape
    {
        public Sensor()
        {
            Radius = 2;
            Origin = new Vector2f(2, 2);
            FillColor = Color.Yellow;
            Angle = 0;
            Distance = 0;
            Line = new DrawableLine(Simulation.Robot.Position, Position);
            ID = 0;
            HasFoundPoint = false;
            PreviousCloudPoint = CloudPoint = new CloudPoint();
        }

        public float Angle { get; set; }
        public float Distance { get; set; } // Distance between the sensor and a point from the point cloud
        private Line Line { get; set; }
        public byte ID { get; set; }
        public bool HasFoundPoint { get; private set; }
        public CloudPoint PreviousCloudPoint { get; private set; }
        public CloudPoint CloudPoint { get; private set; }
        public float Speed => CloudPoint.DistanceFromSensor - PreviousCloudPoint.DistanceFromSensor;
    }
}