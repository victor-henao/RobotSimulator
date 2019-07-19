using SFML.Graphics;
using System.Collections;

namespace LTI.RobotSimulator.Core
{
    /// <summary>
    /// A set of drawable points.
    /// </summary>
    public class PointCloud : Drawable
    {
        public PointCloud()
        {
            Points = new ArrayList();
        }

        public ArrayList Points { get; set; } // Contains point objects

        /// <summary>
        /// Draws the point cloud.
        /// </summary>
        /// <param name="target">The render target.</param>
        /// <param name="states">The render states (default).</param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (CloudPoint point in Points)
            {
                point.Draw(target, states);
            }
        }
    }
}