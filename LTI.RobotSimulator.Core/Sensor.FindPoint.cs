using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LTI.RobotSimulator.Core
{
    partial class Sensor
    {
        /// <summary>
        /// Finds the point on an obstacle, if there's one.
        /// </summary>
        public void FindPoint()
        {
            PreviousCloudPoint = CloudPoint;

            // Updates the sensor vertices
            Line.A = Simulation.Robot.Position; // First vertex: robot's center
            Line.B = Position; // Second vertex: sensor's center

            // Contains cloud point objects and their distance from the sensor.
            Dictionary<CloudPoint, float> CloudPoints = new Dictionary<CloudPoint, float>();

            foreach (DrawableLine wallLine in Simulation.Obstacles) // Determines the intersection point for each wall
            {
                if (Line.M != wallLine.M) // If the lines aren't parallel, let's solve the equation system
                {
                    CloudPoint cloudPoint = GeometryTools.SolveEquationSystem(Line, wallLine);
                    Distance = (float)Math.Sqrt(Math.Pow(cloudPoint.Position.X - Simulation.Robot.Position.X, 2) + Math.Pow(cloudPoint.Position.Y - Simulation.Robot.Position.Y, 2));

                    // Determines if the point is on the segment
                    if (wallLine.A.X != wallLine.B.X)                               // Non-vertical wall
                    {
                        if (cloudPoint.Position.X >= wallLine.A.X && cloudPoint.Position.X <= wallLine.B.X)
                        {
                            if (Line.A.X != Line.B.X)                               // Non-vertical sensor line
                            {
                                if (Position.X >= Simulation.Robot.Position.X && cloudPoint.Position.X >= Position.X)      // Right
                                {
                                    CloudPoints.Add(cloudPoint, Distance);
                                }
                                else if (Position.X < Simulation.Robot.Position.X && cloudPoint.Position.X <= Position.X)  // left
                                {
                                    CloudPoints.Add(cloudPoint, Distance);
                                }
                            }
                            else                                                    // Vertical sensor line
                            {
                                if (Position.Y < Simulation.Robot.Position.Y && cloudPoint.Position.Y < Position.Y)        // Up
                                {
                                    CloudPoints.Add(cloudPoint, Distance);
                                }
                                else if (Position.Y > Simulation.Robot.Position.Y && cloudPoint.Position.Y > Position.Y)   // Down
                                {
                                    CloudPoints.Add(cloudPoint, Distance);
                                }
                            }
                        }
                    }
                    else // Vertical wall
                    {
                        if (cloudPoint.Position.Y >= wallLine.A.Y && cloudPoint.Position.Y <= wallLine.B.Y)
                        {
                            if (Position.X >= Simulation.Robot.Position.X && cloudPoint.Position.X >= Position.X)
                            {
                                CloudPoints.Add(cloudPoint, Distance);
                            }
                            else if (Position.X < Simulation.Robot.Position.X && cloudPoint.Position.X <= Position.X)
                            {
                                CloudPoints.Add(cloudPoint, Distance);
                            }
                        }
                    }
                }
            }

            // PointDistances now has points which are pointed by the sensor and located on obstacles (drawable line segments)

            // Finds the nearest point
            if (CloudPoints.Count != 0)
            {
                var nearestPoint = CloudPoints.OrderBy(pair => pair.Value).Take(1); // Sorts by ascending distances
                HasFoundPoint = true;
                CloudPoint = nearestPoint.ElementAt(0).Key;
                CloudPoint.FillColor = Color.Green;
                CloudPoint.DistanceFromSensor = Distance;
                Simulation.Robot.PointCloud.Points.Add(CloudPoint); // Selects the first point (the nearest one)
            }
        }
    }
}
