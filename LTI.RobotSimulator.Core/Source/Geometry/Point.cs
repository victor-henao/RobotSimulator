using SFML.Graphics;
using SFML.System;
using System.Collections;

namespace LTI.RobotSimulator.Core
{
    /// <summary>
    /// A classic drawable point.
    /// </summary>
    public class Point : Drawable
    {
        protected float _x, _y;

        public Point()
        {
            _x = 0.0F;
            _y = 0.0F;

            Circle = new CircleShape(5.0F)
            {
                Origin = new Vector2f(5.0F, 5.0F),
                Position = new Vector2f(_x, _y),
                FillColor = Color.White
            };
        }

        public Point(float x, float y)
        {
            _x = x;
            _y = y;

            Circle = new CircleShape(5.0F)
            {
                Origin = new Vector2f(5.0F, 5.0F),
                Position = new Vector2f(_x, _y),
                FillColor = Color.White
            };
        }

        public CircleShape Circle { get; set; }

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

        /// <summary>
        /// Draws the point.
        /// </summary>
        /// <param name="target">The render target.</param>
        /// <param name="states">The render states (default).</param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            Circle.Draw(target, states);
        }
    }

    /// <summary>
    /// A point for drawing a point cloud.
    /// </summary>
    public sealed class CloudPoint : Point
    {
        public CloudPoint() : base() { }

        public CloudPoint(float x, float y) : base(x, y)
        {
            Circle.Radius = 2.0F;
            Circle.Origin = new Vector2f(2.0F, 2.0F);
        }

        public float DistanceFromSensor { get; set; }
    }

    /// <summary>
    /// A point that has a theta value and telemetry data.
    /// </summary>
    public sealed class TrajectoryPoint : Point
    {
        public TrajectoryPoint(float x, float y, float theta) : base(x, y)
        {
            Circle.Radius = 2.0F;
            Circle.Origin = new Vector2f(2.0F, 2.0F);

            Theta = theta;
            PointsFoundBySensors = new ArrayList();
        }

        public float Theta { get; private set; }
        public ArrayList PointsFoundBySensors { get; private set; } // Contains telemetry data (point objects)
    }
}