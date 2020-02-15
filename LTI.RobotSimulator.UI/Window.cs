using LTI.RobotSimulator.Core;
using LTI.RobotSimulator.Core.Geometry;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Drawing;
using System.Windows.Forms;
using Color = SFML.Graphics.Color;
using Sensor = LTI.RobotSimulator.Core.Sensor;

namespace LTI.RobotSimulator
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private RenderWindow Surface { get; set; }

        private void Window_Load(object sender, EventArgs e)
        {
            Simulation.Initialize();

            // Reads the settings file and sets the label size (render target)
            SetupFile.Read(@"..\..\..\resource\settings.ini");
            renderTarget.Size = SetupFile.SurfaceSize;

            Simulation.Robot.Position = new Vector2f(renderTarget.Width / 2, renderTarget.Height / 2);
            Simulation.Robot.EndPoint.Position = new Vector2f(renderTarget.Width / 2, renderTarget.Height / 2);

            ClientSize = new Size(renderTarget.Location.X + renderTarget.Width + 6 + robotGroupBox.Width + 12, renderTarget.Location.Y + renderTarget.Height + 12);
            robotGroupBox.Location = new System.Drawing.Point(renderTarget.Location.X + renderTarget.Width + 6, 24);
            robotFileGroupBox.Location = new System.Drawing.Point(renderTarget.Location.X + renderTarget.Width + 6, 472);

            CenterToScreen();

            Surface = new RenderWindow(renderTarget.Handle, new ContextSettings());
            Surface.SetVerticalSyncEnabled(true);
        }

        public void OnUpdate(float deltaTime)
        {
            if (Simulation.HasStarted)
            {
                if (Simulation.Robot.CanMove)
                {
                    Simulation.Robot.Move(deltaTime);
                    rotationNumericUpDown.Value = -(decimal)Simulation.Robot.Theta;
                }
            }
            else
            {
                Simulation.Robot.Theta = -(float)rotationNumericUpDown.Value;
            }

            if (Simulation.Robot.DistanceToEnd <= 5)
            {
                Simulation.Robot.CanMove = false;
            }

            Simulation.Robot.Speed = (float)speedNumericUpDown.Value;
            Simulation.Robot.LeftWheel.Text.DisplayedString = Simulation.Robot.LeftWheel.Speed.ToString();
            Simulation.Robot.RightWheel.Text.DisplayedString = Simulation.Robot.RightWheel.Speed.ToString();
        }

        public void OnRender()
        {
            Surface.Clear(new Color(100, 150, 200, 255));

            // Draws obstacles
            foreach (DrawableLine obstacle in Simulation.Obstacles)
            {
                obstacle.Draw(Surface, RenderStates.Default);
            }

            // Draws the trajectory and the point cloud from a robot file
            if (RobotFile.Loaded)
            {
                if (robotFileTrajectoryCheckBox.Checked)
                {
                    foreach (TrajectoryPoint trajectoryPoint in RobotFile.Trajectory.Points)
                    {
                        trajectoryPoint.Draw(Surface, RenderStates.Default);
                    }
                }

                if (robotFilePointCloudCheckBox.Checked)
                {
                    foreach (CloudPoint cloudPoint in RobotFile.PointCloud.Points)
                    {
                        cloudPoint.Draw(Surface, RenderStates.Default);
                    }
                }
            }

            // Draws the robot's trajectory
            if (robotTrajectoryCheckBox.Checked)
            {
                foreach (TrajectoryPoint trajectoryPoint in Simulation.Robot.Trajectory.Points)
                {
                    trajectoryPoint.Draw(Surface, RenderStates.Default);
                }
            }

            // Draws the robot's point cloud
            if (robotPointCloudCheckBox.Checked)
            {
                foreach (CloudPoint cloudPoint in Simulation.Robot.PointCloud.Points)
                {
                    cloudPoint.Draw(Surface, RenderStates.Default);
                }
            }

            // Draws the robot
            Simulation.Robot.Draw(Surface, RenderStates.Default);

            // Draws the robot's sensors
            if (sensorsCheckBox.Checked)
            {
                foreach (Sensor sensor in Simulation.Robot.Sensors)
                {
                    sensor.Draw(Surface, RenderStates.Default);
                }
            }

            // Draws the wheel's text
            if (wheelsCheckBox.Checked)
            {
                Simulation.Robot.LeftWheel.Text.Draw(Surface, RenderStates.Default);
                Simulation.Robot.RightWheel.Text.Draw(Surface, RenderStates.Default);
            }

            Surface.Display();
        }

        #region Event functions
        private void RenderTarget_MouseClick(object sender, MouseEventArgs e)
        {
            // Moves the robot with the mouse and lets the user to define a path from 2 points
            if (robotStartButton.Enabled)
            {
                if (e.Button == MouseButtons.Left) // Moves the robot with the mouse and defines a start point
                {
                    Simulation.Robot.Position = new Vector2f(e.Location.X, e.Location.Y);
                }
                else if (e.Button == MouseButtons.Right) // Defines an end point
                {
                    Simulation.Robot.EndPoint.Position = new Vector2f(e.Location.X, e.Location.Y);
                }
            }
        }

        private void ResetSpeedButton_Click(object sender, EventArgs e)
        {
            speedNumericUpDown.Value = 0;
        }

        private void ResetRotationButton_Click(object sender, EventArgs e)
        {
            rotationNumericUpDown.Value = 0;
        }

        private void RobotStartButton_Click(object sender, EventArgs e)
        {
            Simulation.HasStarted = true;
            Simulation.Robot.CanMove = true;

            resetSpeedButton.Enabled = false;
            resetRotationButton.Enabled = false;
            robotStartButton.Enabled = false;
            robotPauseButton.Enabled = true;
            rotationNumericUpDown.Enabled = false;
        }

        private void RobotPauseButton_Click(object sender, EventArgs e)
        {
            Simulation.Robot.CanMove = false;

            robotPauseButton.Enabled = false;
            robotResumeButton.Enabled = true;
        }

        private void RobotResumeButton_Click(object sender, EventArgs e)
        {
            Simulation.Robot.CanMove = true;

            robotPauseButton.Enabled = true;
            robotResumeButton.Enabled = false;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    RobotFile.Save(saveFileDialog.FileName);
                }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (openFileDialog)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    RobotFile.Load(openFileDialog.FileName);
                    robotFileGroupBox.Text = openFileDialog.SafeFileName;
                    robotFileGroupBox.Visible = true;
                }
            }
        }
        #endregion
    }
}
