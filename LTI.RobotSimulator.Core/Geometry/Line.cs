using SFML.Graphics;
using SFML.System;

namespace LTI.RobotSimulator.Core.Geometry
{
    public class Line
    {
        public Line(Vector2f a, Vector2f b)
        {
            A = a;
            B = b;

            Vertices = new Vertex[2]
            {
                new Vertex(A),
                new Vertex(B)
            };
        }

        public float M
        {
            get { return (B.Y - A.Y) / (B.X - A.X); }
        }

        public float P
        {
            get { return A.Y - (M * A.X); }
        }

        public Vector2f A { get; set; }
        public Vector2f B { get; set; }
        public Vertex[] Vertices { get; set; }
    }

    /// <summary>
    /// A line which is rendered on the screen.
    /// </summary>
    public sealed class DrawableLine : Line, Drawable
    {
        public DrawableLine(Vector2f a, Vector2f b) : base(a, b)
        {
            if (a.X > b.X)
            {
                SwapPoints(ref a, ref b);
            }
            else if (a.X == b.X)
            {
                if (a.Y > b.Y)
                {
                    SwapPoints(ref a, ref b);
                }
            }

            A = a;
            B = b;

            Vertices = new Vertex[2]
            {
                new Vertex(A),
                new Vertex(B)
            };
        }

        private void SwapPoints(ref Vector2f a, ref Vector2f b)
        {
            Vector2f temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="target">The render target.</param>
        /// <param name="states">The render states (default).</param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Vertices, PrimitiveType.Lines, states);
        }
    }
}