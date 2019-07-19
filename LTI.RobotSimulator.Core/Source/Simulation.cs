using System.Collections;

namespace LTI.RobotSimulator.Core
{
    /// <summary>
    /// Handles simulation data.
    /// </summary>
    public static class Simulation
    {
        public static Robot Robot { get; set; }
        public static ArrayList Obstacles { get; set; } // Contains drawable line objects
        public static bool HasStarted { get; set; }

        public static void Initialize()
        {
            Robot = new Robot();
            Obstacles = new ArrayList();
        }
    }
}
