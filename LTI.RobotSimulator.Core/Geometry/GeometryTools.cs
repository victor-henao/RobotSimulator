using SFML.System;
using System;

namespace LTI.RobotSimulator.Core.Geometry
{
    /// <summary>
    /// Provides geometry tools.
    /// </summary>
    public static class GeometryTools
    {
        /// <summary>
        /// Solves a system of 2 equations with 2 variables.
        /// y = m * x + p
        /// </summary>
        /// <param name="sensorLine">First line.</param>
        /// <param name="wallLine">Second line.</param>
        /// <returns>A point object.</returns>
        public static CloudPoint SolveEquationSystem(Line sensorLine, Line wallLine)
        {
            float x, y; // Intersection point coordinates

            // First line's vertices position
            Vector2f A1 = new Vector2f(sensorLine.A.X, sensorLine.A.Y); // First point
            Vector2f B1 = new Vector2f(sensorLine.B.X, sensorLine.B.Y); // Second point

            // Second line's vertices position
            Vector2f A2 = new Vector2f(wallLine.A.X, wallLine.A.Y); // First point
            Vector2f B2 = new Vector2f(wallLine.B.X, wallLine.B.Y); // Second point

            if (A1.X == B1.X)                           // Checks if the sensor's line is vertical
            {
                x = A1.X;                               // X point coordinate (or x = B1.X)
                y = wallLine.M * x + wallLine.P;        // Y point coordinate
            }
            else if (A2.X == B2.X)                      // Checks if the wall is vertical
            {
                x = A2.X;                               // X point coordinate (or x = B2.X)
                y = sensorLine.M * x + sensorLine.P;    // Y point coordinate
            }
            else                                                                // Here, both lines aren't vertical
            {
                x = (wallLine.P - sensorLine.P) / (sensorLine.M - wallLine.M);  // X point coordinate
                y = (sensorLine.M * x) + sensorLine.P;                          // Y point coordinate
            }

            return new CloudPoint(new Vector2f(x, y));
        }

        /// <summary>
        /// Determines the distance between 2 coordinates.
        /// </summary>
        /// <param name="coordinate1">The first coordinates.</param>
        /// <param name="coordinate2">The second coordinates.</param>
        /// <returns>The distance (float).</returns>
        public static float Distance(Vector2f coordinate1, Vector2f coordinate2)
            => (float)Math.Sqrt(Math.Pow(coordinate1.X - coordinate2.X, 2) + Math.Pow(coordinate1.Y - coordinate2.Y, 2));

        /// <summary>
        /// Returns the cross product of 2 vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns></returns>
        public static float CrossProduct(Vector2f vector1, Vector2f vector2)
            => vector1.X * vector2.Y - (vector2.X * vector1.Y);

        /// <summary>
        /// Converts an angle in radians to degrees.
        /// </summary>
        /// <param name="angle">Angle value in radians.</param>
        /// <returns>The angle value in degrees.</returns>
        public static float ToDegrees(float angle)
            => angle * (180 / (float)Math.PI);

        /// <summary>
        /// Converts an angle in degrees to radians.
        /// </summary>
        /// <param name="angle">Angle value in degrees.</param>
        /// <returns>The angle value in radians.</returns>
        public static float ToRadians(float angle)
            => angle * (float)Math.PI / 180;
    }
}