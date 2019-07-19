using LTI.RobotSimulator.Core;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace LTI.RobotSimulator.UI
{
    /// <summary>
    /// Gets information from the settings.ini file to setup the simulator.
    /// </summary>
    static class SetupFile
    {
        public static Size SurfaceSize { get; private set; }

        public static void Read(string path)
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (!line.Contains(";")) // Ignores comments
                {
                    if (line.Contains("size"))
                    {
                        string[] sizeLine = line.Split('=');
                        string[] size = sizeLine[1].Split(',');

                        SurfaceSize = new Size(int.Parse(size[0]), int.Parse(size[1]));
                    }

                    if (line.Contains("sensors"))
                    {
                        string[] sensorsLine = line.Split('=');
                        Simulation.Robot.SensorCount = byte.Parse(sensorsLine[1]); // Sensor count
                    }

                    if (Regex.IsMatch(line, @"\bradius\b"))
                    {
                        string[] radiusLine = line.Split('=');
                        Simulation.Robot.Radius = float.Parse(radiusLine[1]); // Radius
                    }

                    if (line.Contains("wheel_radius"))
                    {
                        string[] wheelRadiusLine = line.Split('=');
                        Simulation.Robot.LeftWheel.Radius = float.Parse(wheelRadiusLine[1]);
                        Simulation.Robot.RightWheel.Radius = float.Parse(wheelRadiusLine[1]);
                    }

                    if (line.Contains("wall")) // Defines obstacles
                    {
                        ArrayList wallPoints = new ArrayList();

                        string[] wallLine = line.Split('=');
                        string[] coordinates = wallLine[1].Split(',');

                        // Gets the point coordinates
                        foreach (string pointCoordinates in coordinates)
                        {
                            string[] point = pointCoordinates.Split('_');

                            float x = float.Parse(point[0]);
                            float y = float.Parse(point[1]);

                            wallPoints.Add(new SFML.System.Vector2f(x, y));
                        }

                        // segmentPoints now has 2 points
                        Simulation.Obstacles.Add(new DrawableLine(
                            (SFML.System.Vector2f)wallPoints[0],
                            (SFML.System.Vector2f)wallPoints[1]));
                    }
                }
            }
        }
    }
}
