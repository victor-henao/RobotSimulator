using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections;

namespace LTI.RobotSimulator.Core
{
    partial class Robot
    {
        /// <summary>
        /// This property is modified only when the user moves the robot with the mouse.
        /// </summary>
        public Vector2f Position
        {
            get { return _position; }
            set
            {
                _position = value;
                TransformShapes();
                StartPoint = new Point();
            }
        }

        /// <summary>
        /// This property is modified only when the user moves the robot with the mouse.
        /// </summary>
        public float Theta
        {
            get { return GeometryTools.ToDegrees(-_theta); }
            set
            {
                _theta = GeometryTools.ToRadians(-value);
                TransformShapes();
            }
        }

        public float Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                Circle.Radius = _radius;
                Circle.Origin = new Vector2f(_radius, _radius);
                Rectangle.Size = new Vector2f(_radius * 2, 5.0F);
                Rectangle.Origin = new Vector2f(_radius, 5.0F / 2);
            }
        }

        public byte SensorCount
        {
            get { return _sensorCount; }
            set
            {
                _sensorCount = value;

                for (byte sensorNumber = 0; sensorNumber < _sensorCount; sensorNumber++)
                {
                    Sensor sensor = new Sensor
                    {
                        Angle = (float)((sensorNumber * (2 * Math.PI / SensorCount)) - _theta),
                        ID = sensorNumber
                    };

                    Sensors.Add(sensor);
                }
            }
        }

        public float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;

                if (!CanMove)
                {
                    LeftWheel.Speed = _speed;
                    RightWheel.Speed = _speed;
                }
            }
        }

        public bool CanMove { get; set; }
        private CircleShape Circle { get; set; }
        private RectangleShape Rectangle { get; set; }
        public Trajectory Trajectory { get; private set; }
        public PointCloud PointCloud { get; private set; }
        public Wheel LeftWheel { get; set; }
        public Wheel RightWheel { get; set; }
        public ArrayList Sensors { get; private set; } // Contains sensor objects
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Vector2f Direction
        {
            get { return new Vector2f((float)Math.Cos(_theta), (float)Math.Sin(_theta)); }
        }

        public Vector2f Path
        {
            get { return new Vector2f(EndPoint.Position.X - _position.X, _position.Y - EndPoint.Position.Y); }
        }

        public float DistanceToEnd
        {
            get { return (float)Math.Sqrt(Math.Pow(EndPoint.Position.X - _position.X, 2) + Math.Pow(EndPoint.Position.Y - _position.Y, 2)); }
        }
    }
}
