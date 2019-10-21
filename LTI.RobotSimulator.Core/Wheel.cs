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
            TextSize = 20;
            Font font = new Font(@"..\..\..\resource\consola.ttf");

            Text = new Text
            {
                Font = font,
                CharacterSize = TextSize,
                Origin = new Vector2f(TextSize / 3, TextSize / 2)
            };
        }

        public float Radius { get; set; }
        public float Angle { get; set; }
        public float Speed { get; set; }
        public Text Text { get; set; }
        private ushort TextSize { get; set; }
    }
}
