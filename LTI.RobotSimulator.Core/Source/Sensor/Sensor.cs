using SFML.Graphics;
using SFML.System;

namespace LTI.RobotSimulator.Core
{
    public sealed partial class Sensor : Drawable
    {
        private float _x, _y;

        public Sensor()
        {
            _x = 0;
            _y = 0;

            Circle = new CircleShape()
            {
                Radius = 2.0F,
                Origin = new Vector2f(2.0F, 2.0F),
                FillColor = Color.Yellow
            };

            Angle = 0.0F;
            Distance = 0.0F;
            Line = new DrawableLine(new Vector2f(Simulation.Robot.X, Simulation.Robot.Y), new Vector2f(_x, _y));
            ID = 0;
            HasFoundPoint = false;
            PreviousCloudPoint = CloudPoint = new CloudPoint();
        }

        public float X
        {
            get { return _x; }
            set
            {
                _x = value;
                Circle.Position = new Vector2f(_x, _y);
            }
        }

        public float Y
        {
            get { return _y; }
            set
            {
                _y = value;
                Circle.Position = new Vector2f(_x, _y);
            }
        }

        public float Speed
        {
            get { return CloudPoint.DistanceFromSensor - PreviousCloudPoint.DistanceFromSensor; }
        }

        private CircleShape Circle { get; set; }
        public float Angle { get; set; }
        public float Distance { get; set; } // Distance between the sensor and a point from the point cloud
        private Line Line { get; set; }
        public byte ID { get; set; }
        public bool HasFoundPoint { get; private set; }

        // These 2 points will determine the movement rate
        public CloudPoint PreviousCloudPoint { get; private set; }
        public CloudPoint CloudPoint { get; private set; }

        /// <summary>
        /// Draws the sensor.
        /// </summary>
        /// <param name="target">The render target.</param>
        /// <param name="states">The render state (default).</param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            Circle.Draw(target, states);
        }
    }
}