using LTI.RobotSimulator.Core;
using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using System.IO;

namespace LTI.RobotSimulator.UI
{
    /// <summary>
    /// Saves and loads simulation data.
    /// </summary>
    static class RobotFile
    {
        public static Trajectory Trajectory { get; private set; }
        public static PointCloud PointCloud { get; private set; }
        public static bool Loaded { get; private set; }

        public static void Save(string name)
        {
            StreamWriter file = new StreamWriter(name);

            file.WriteLine("; Sensors: " + Simulation.Robot.Sensors.Count.ToString());

            // Writes sensor data: sensor count and each sensor angle
            foreach (Sensor sensor in Simulation.Robot.Sensors)
            {
                file.WriteLine("; sensor " + sensor.ID.ToString() + ": angle = " + sensor.Angle.ToString());
            }

            file.WriteLine();
            file.WriteLine("; Trajectory points data:");
            file.WriteLine("; x_y theta x1_y1 x2_y2 ... xn_yn");
            file.WriteLine();
            file.WriteLine("; x_y = point coordinates");
            file.WriteLine("; theta = point orientation (radians)");
            file.WriteLine("; xn_yn = point found by sensors");
            file.WriteLine();

            // Writes each trajectory point data
            foreach (TrajectoryPoint trajectoryPoint in Simulation.Robot.Trajectory.Points)
            {
                // Point coordinates and angle
                file.Write(trajectoryPoint.Position.X.ToString() + "_" + trajectoryPoint.Position.Y.ToString() + " " + (trajectoryPoint.Theta + GeometryTools.ToRadians(Simulation.Robot.Theta)).ToString());

                // Points found by each sensor
                foreach (CloudPoint cloudPoint in trajectoryPoint.PointsFoundBySensors)
                {
                    file.Write(" " + cloudPoint.Position.X.ToString() + "_" + cloudPoint.Position.Y.ToString());
                }

                file.WriteLine();
            }

            file.Close();
        }

        public static void Load(string path)
        {
            Loaded = true;
            Trajectory = new Trajectory();
            PointCloud = new PointCloud();

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (!line.Contains(";") && line.Length != 0) // Ignores comments
                {
                    string[] pointLine = line.Split(' ');

                    // Point coordinates
                    string[] coordinates = pointLine[0].Split('_');
                    float x = float.Parse(coordinates[0]);
                    float y = float.Parse(coordinates[1]);

                    // Theta
                    float theta = float.Parse(pointLine[1]);

                    // Adds a trajectory point object to the trajectory
                    TrajectoryPoint trajectoryPoint = new TrajectoryPoint(new SFML.System.Vector2f(x, y), theta);
                    trajectoryPoint.FillColor = Color.Red;

                    Trajectory.Points.Add(trajectoryPoint);

                    // Points found by sensors
                    for (byte pointFoundIndex = 0; pointFoundIndex < pointLine.Length - 2; pointFoundIndex++)
                    {
                        string[] pointFoundCoordinates = pointLine[pointFoundIndex + 2].Split('_');

                        float pointFoundX = float.Parse(pointFoundCoordinates[0]);
                        float pointFoundY = float.Parse(pointFoundCoordinates[1]);

                        // Adds a point object to the point cloud
                        CloudPoint point = new CloudPoint(new SFML.System.Vector2f(pointFoundX, pointFoundY));
                        point.FillColor = Color.Red;

                        PointCloud.Points.Add(point);
                    }
                }
            }
        }
    }
}
