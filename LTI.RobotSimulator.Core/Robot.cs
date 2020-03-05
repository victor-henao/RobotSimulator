using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using SFML.System;
using System.Collections;

namespace LTI.RobotSimulator.Core
{
    public sealed partial class Robot : Drawable
    {
        private readonly CircleShape _circle;
        private readonly RectangleShape _rectangle;
        private Vector2f _position;
        private float _theta;
        private float _radius;
        private float _speed;
        private byte _sensorCount;

        public Robot()
        {
            _position = new Vector2f();
            _theta = 0;
            _radius = 0;
            _sensorCount = 0;
            _speed = 50;



            _circle = new CircleShape(_radius)
            {
                Origin = new Vector2f(_radius, _radius),
                Position = _position,
                FillColor = new Color(180, 180, 180, 255)
            };

            _rectangle = new RectangleShape(new Vector2f(_radius * 2, 5))
            {
                Origin = new Vector2f(_radius, 5 / 2),
                Position = _position,
                Rotation = GeometryTools.ToDegrees(-_theta),
                FillColor = new Color(150, 150, 150, 255)
            };

            CanMove = false;
            Trajectory = new Trajectory();
            PointCloud = new PointCloud();

            LeftWheel = new Wheel(15.0F);
            RightWheel = new Wheel(15.0F);

            Sensors = new ArrayList();

            StartPoint = new Point(Position);
            EndPoint = new Point();
        }

        /// <summary>
        /// Draws the robot's shapes.
        /// </summary>
        /// <param name="target">The render target.</param>
        /// <param name="states">The render state (default).</param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            if (Simulation.HasStarted)
            {
                StartPoint.Draw(target, states);
            }

            EndPoint.Draw(target, states);
            _circle.Draw(target, states);
            _rectangle.Draw(target, states);
        }
    }
}