using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using SFML.System;
using System.Collections;

namespace LTI.RobotSimulator.Core
{
    public sealed partial class Robot : Drawable
    {
        private float _x, _y, _theta, _radius, _speed;
        private byte _sensorCount;

        public Robot()
        {
            _x = 0;
            _y = 0;
            _theta = 0;
            _radius = 0;
            _sensorCount = 0;
            _speed = 0.0F;

            CanMove = false;

            Circle = new CircleShape(_radius)
            {
                Origin = new Vector2f(_radius, _radius),
                Position = new Vector2f(_x, _y),
                FillColor = new Color(180, 180, 180, 255)
            };

            Rectangle = new RectangleShape(new Vector2f(_radius * 2, 5.0F))
            {
                Origin = new Vector2f(_radius, 5.0F / 2),
                Position = new Vector2f(_x, _y),
                Rotation = GeometryTools.ToDegrees(-_theta),
                FillColor = new Color(150, 150, 150, 255)
            };

            Trajectory = new Trajectory();
            PointCloud = new PointCloud();

            LeftWheel = new Wheel(15.0F);
            RightWheel = new Wheel(15.0F);

            Sensors = new ArrayList();

            StartPoint = new Point();
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

            Circle.Draw(target, states);
            Rectangle.Draw(target, states);
        }
    }
}