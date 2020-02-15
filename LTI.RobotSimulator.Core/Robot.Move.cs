using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using SFML.System;
using System;

namespace LTI.RobotSimulator.Core
{
    partial class Robot
    {
        public void Move(float deltaTime)
        {
            UpdateSensors();
            UpdateDirection();
            ApplyAngle(LeftWheel.Speed * deltaTime, RightWheel.Speed * deltaTime);
            TransformShapes();
        }

        /// <summary>
        /// Updates the trajectory and the point cloud from sensor data.
        /// </summary>
        private void UpdateSensors()
        {
            float highestSensorSpeed = 0;

            TrajectoryPoint trajectoryPoint = new TrajectoryPoint(_position, _theta)
            {
                FillColor = Color.Green
            };

            // Finds the points discovered by sensors for a trajectory point
            foreach (Sensor sensor in Sensors)
            {
                sensor.FindPoint();

                if (sensor.HasFoundPoint)
                {
                    trajectoryPoint.PointsFoundBySensors.Add(sensor.CloudPoint);
                }

                if (sensor.Speed > highestSensorSpeed)
                {
                    highestSensorSpeed = sensor.Speed;
                }
            }

            Trajectory.Points.Add(trajectoryPoint);
        }

        private void UpdateDirection()
        {
            if (Math.Round(GeometryTools.CrossProduct(Direction, Path)) >= -1 && Math.Round(GeometryTools.CrossProduct(Direction, Path)) <= 1) // Same direction
            {
                LeftWheel.Speed = _speed;
                RightWheel.Speed = _speed;
            }
            else if (Math.Round(GeometryTools.CrossProduct(Direction, Path)) < 0) // Left
            {
                LeftWheel.Speed = _speed * 2;
                RightWheel.Speed = _speed;
            }
            else if (Math.Round(GeometryTools.CrossProduct(Direction, Path)) > 0) // Right
            {
                LeftWheel.Speed = _speed;
                RightWheel.Speed = _speed * 2;
            }
        }

        /// <summary>
        /// Moves the robot by adding angle values (in degrees) to each wheel.
        /// </summary>
        /// <param name="leftWheelAngleDelta">Angle value to add to the left wheel.</param>
        /// <param name="rightWheelAngleDelta">Angle value to add to the left wheel.</param>
        private void ApplyAngle(float leftWheelAngleDelta, float rightWheelAngleDelta)
        {
            leftWheelAngleDelta = GeometryTools.ToRadians(leftWheelAngleDelta);
            rightWheelAngleDelta = GeometryTools.ToRadians(rightWheelAngleDelta);

            LeftWheel.Angle += leftWheelAngleDelta;
            RightWheel.Angle += rightWheelAngleDelta;

            float thetaDelta = ((RightWheel.Radius * rightWheelAngleDelta) - (LeftWheel.Radius * leftWheelAngleDelta)) / (2 * _radius);

            _position += new Vector2f(
                (LeftWheel.Radius * leftWheelAngleDelta + RightWheel.Radius * rightWheelAngleDelta) / 2 * (float)Math.Cos(-_theta),
                (LeftWheel.Radius * leftWheelAngleDelta + RightWheel.Radius * rightWheelAngleDelta) / 2 * (float)Math.Sin(-_theta));

            _theta += thetaDelta;
        }

        /// <summary>
        /// Moves all robot's shapes.
        /// </summary>
        private void TransformShapes()
        {
            Circle.Position = _position;
            Rectangle.Position = _position;
            Rectangle.Rotation = GeometryTools.ToDegrees(-_theta);

            LeftWheel.Text.Position = new Vector2f(
                _position.X + (float)Math.Cos((-Math.PI / 2) - _theta) * _radius,
                _position.Y + (float)Math.Sin((-Math.PI / 2) - _theta) * _radius);

            RightWheel.Text.Position = new Vector2f(
                _position.X + (float)Math.Cos((Math.PI / 2) - _theta) * _radius,
                _position.Y + (float)Math.Sin((Math.PI / 2) - _theta) * _radius);

            if (SensorCount != 0)
            {
                for (byte sensorNumber = 0; sensorNumber < SensorCount; sensorNumber++)
                {
                    ((Sensor)Sensors[sensorNumber]).Position = new Vector2f(
                        _position.X + (float)Math.Cos((sensorNumber * (2 * Math.PI / SensorCount)) - _theta) * _radius,
                        _position.Y + (float)Math.Sin((sensorNumber * (2 * Math.PI / SensorCount)) - _theta) * _radius);
                }
            }
        }
    }
}
