using SFML.Graphics;
using SFML.System;

namespace LTI.RobotSimulator.Core
{
    public class Wheel
    {
        public Wheel(float radius)
        {
            Radius = radius;
            Angle = 0;
            Font font = new Font(@"..\..\..\resource\consola.ttf");

            Text = new Text
            {
                Font = font,
                CharacterSize = 20,
                Origin = new Vector2f(20 / 3, 20 / 2)
            };
        }

        public float Radius { get; set; }
        public float Angle { get; set; }
        public float Speed { get; set; }
        public Text Text { get; set; }
    }
}
