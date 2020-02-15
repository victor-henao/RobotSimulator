using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using System.Collections;

namespace LTI.RobotSimulator.Core
{
    public class Trajectory : Drawable
    {
        public Trajectory()
        {
            Points = new ArrayList();
        }

        public ArrayList Points { get; private set; } // Contains trajectory point objects

        /// <summary>
        /// Draws the trajectory's points.
        /// </summary>
        /// <param name="target">The render target.</param>
        /// <param name="states">The render states (default).</param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (TrajectoryPoint trajectoryPoint in Points)
            {
                trajectoryPoint.Draw(target, states);
            }
        }
    }
}