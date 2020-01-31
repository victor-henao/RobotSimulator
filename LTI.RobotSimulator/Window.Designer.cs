namespace LTI.RobotSimulator
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.renderTarget = new System.Windows.Forms.Label();
            this.robotGroupBox = new System.Windows.Forms.GroupBox();
            this.robotPauseButton = new System.Windows.Forms.Button();
            this.robotResumeButton = new System.Windows.Forms.Button();
            this.robotStartButton = new System.Windows.Forms.Button();
            this.robotDisplayGroupBox = new System.Windows.Forms.GroupBox();
            this.wheelsCheckBox = new System.Windows.Forms.CheckBox();
            this.sensorsCheckBox = new System.Windows.Forms.CheckBox();
            this.robotPointCloudCheckBox = new System.Windows.Forms.CheckBox();
            this.robotTrajectoryCheckBox = new System.Windows.Forms.CheckBox();
            this.robotRotationGroupBox = new System.Windows.Forms.GroupBox();
            this.resetRotationButton = new System.Windows.Forms.Button();
            this.rotationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.speedGroupBox = new System.Windows.Forms.GroupBox();
            this.resetSpeedButton = new System.Windows.Forms.Button();
            this.speedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.robotFileGroupBox = new System.Windows.Forms.GroupBox();
            this.robotFilePointCloudCheckBox = new System.Windows.Forms.CheckBox();
            this.robotFileTrajectoryCheckBox = new System.Windows.Forms.CheckBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.robotGroupBox.SuspendLayout();
            this.robotDisplayGroupBox.SuspendLayout();
            this.robotRotationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationNumericUpDown)).BeginInit();
            this.speedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedNumericUpDown)).BeginInit();
            this.robotFileGroupBox.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderTarget
            // 
            this.renderTarget.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.renderTarget.Location = new System.Drawing.Point(12, 24);
            this.renderTarget.Name = "renderTarget";
            this.renderTarget.Size = new System.Drawing.Size(676, 567);
            this.renderTarget.TabIndex = 0;
            this.renderTarget.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RenderTarget_MouseClick);
            // 
            // robotGroupBox
            // 
            this.robotGroupBox.AutoSize = true;
            this.robotGroupBox.Controls.Add(this.robotPauseButton);
            this.robotGroupBox.Controls.Add(this.robotResumeButton);
            this.robotGroupBox.Controls.Add(this.robotStartButton);
            this.robotGroupBox.Controls.Add(this.robotDisplayGroupBox);
            this.robotGroupBox.Controls.Add(this.robotRotationGroupBox);
            this.robotGroupBox.Controls.Add(this.speedGroupBox);
            this.robotGroupBox.Location = new System.Drawing.Point(694, 24);
            this.robotGroupBox.Name = "robotGroupBox";
            this.robotGroupBox.Size = new System.Drawing.Size(133, 442);
            this.robotGroupBox.TabIndex = 1;
            this.robotGroupBox.TabStop = false;
            this.robotGroupBox.Text = "Robot";
            // 
            // robotPauseButton
            // 
            this.robotPauseButton.Enabled = false;
            this.robotPauseButton.Location = new System.Drawing.Point(7, 371);
            this.robotPauseButton.Name = "robotPauseButton";
            this.robotPauseButton.Size = new System.Drawing.Size(120, 23);
            this.robotPauseButton.TabIndex = 4;
            this.robotPauseButton.Text = "Pause";
            this.robotPauseButton.UseVisualStyleBackColor = true;
            this.robotPauseButton.Click += new System.EventHandler(this.RobotPauseButton_Click);
            // 
            // robotResumeButton
            // 
            this.robotResumeButton.Enabled = false;
            this.robotResumeButton.Location = new System.Drawing.Point(7, 400);
            this.robotResumeButton.Name = "robotResumeButton";
            this.robotResumeButton.Size = new System.Drawing.Size(120, 23);
            this.robotResumeButton.TabIndex = 4;
            this.robotResumeButton.Text = "Resume";
            this.robotResumeButton.UseVisualStyleBackColor = true;
            this.robotResumeButton.Click += new System.EventHandler(this.RobotResumeButton_Click);
            // 
            // robotStartButton
            // 
            this.robotStartButton.Location = new System.Drawing.Point(7, 342);
            this.robotStartButton.Name = "robotStartButton";
            this.robotStartButton.Size = new System.Drawing.Size(120, 23);
            this.robotStartButton.TabIndex = 3;
            this.robotStartButton.Text = "Start";
            this.robotStartButton.UseVisualStyleBackColor = true;
            this.robotStartButton.Click += new System.EventHandler(this.RobotStartButton_Click);
            // 
            // robotDisplayGroupBox
            // 
            this.robotDisplayGroupBox.AutoSize = true;
            this.robotDisplayGroupBox.Controls.Add(this.wheelsCheckBox);
            this.robotDisplayGroupBox.Controls.Add(this.sensorsCheckBox);
            this.robotDisplayGroupBox.Controls.Add(this.robotPointCloudCheckBox);
            this.robotDisplayGroupBox.Controls.Add(this.robotTrajectoryCheckBox);
            this.robotDisplayGroupBox.Location = new System.Drawing.Point(7, 212);
            this.robotDisplayGroupBox.Name = "robotDisplayGroupBox";
            this.robotDisplayGroupBox.Size = new System.Drawing.Size(120, 124);
            this.robotDisplayGroupBox.TabIndex = 2;
            this.robotDisplayGroupBox.TabStop = false;
            this.robotDisplayGroupBox.Text = "Display";
            // 
            // wheelsCheckBox
            // 
            this.wheelsCheckBox.AutoSize = true;
            this.wheelsCheckBox.Checked = true;
            this.wheelsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wheelsCheckBox.Location = new System.Drawing.Point(7, 42);
            this.wheelsCheckBox.Name = "wheelsCheckBox";
            this.wheelsCheckBox.Size = new System.Drawing.Size(62, 17);
            this.wheelsCheckBox.TabIndex = 3;
            this.wheelsCheckBox.Text = "Wheels";
            this.wheelsCheckBox.UseVisualStyleBackColor = true;
            // 
            // sensorsCheckBox
            // 
            this.sensorsCheckBox.AutoSize = true;
            this.sensorsCheckBox.Checked = true;
            this.sensorsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sensorsCheckBox.Location = new System.Drawing.Point(7, 19);
            this.sensorsCheckBox.Name = "sensorsCheckBox";
            this.sensorsCheckBox.Size = new System.Drawing.Size(64, 17);
            this.sensorsCheckBox.TabIndex = 2;
            this.sensorsCheckBox.Text = "Sensors";
            this.sensorsCheckBox.UseVisualStyleBackColor = true;
            // 
            // robotPointCloudCheckBox
            // 
            this.robotPointCloudCheckBox.AutoSize = true;
            this.robotPointCloudCheckBox.Checked = true;
            this.robotPointCloudCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.robotPointCloudCheckBox.Location = new System.Drawing.Point(7, 88);
            this.robotPointCloudCheckBox.Name = "robotPointCloudCheckBox";
            this.robotPointCloudCheckBox.Size = new System.Drawing.Size(80, 17);
            this.robotPointCloudCheckBox.TabIndex = 1;
            this.robotPointCloudCheckBox.Text = "Point Cloud";
            this.robotPointCloudCheckBox.UseVisualStyleBackColor = true;
            // 
            // robotTrajectoryCheckBox
            // 
            this.robotTrajectoryCheckBox.AutoSize = true;
            this.robotTrajectoryCheckBox.Checked = true;
            this.robotTrajectoryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.robotTrajectoryCheckBox.Location = new System.Drawing.Point(7, 65);
            this.robotTrajectoryCheckBox.Name = "robotTrajectoryCheckBox";
            this.robotTrajectoryCheckBox.Size = new System.Drawing.Size(73, 17);
            this.robotTrajectoryCheckBox.TabIndex = 0;
            this.robotTrajectoryCheckBox.Text = "Trajectory";
            this.robotTrajectoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // robotRotationGroupBox
            // 
            this.robotRotationGroupBox.AutoSize = true;
            this.robotRotationGroupBox.Controls.Add(this.resetRotationButton);
            this.robotRotationGroupBox.Controls.Add(this.rotationNumericUpDown);
            this.robotRotationGroupBox.Location = new System.Drawing.Point(7, 116);
            this.robotRotationGroupBox.Name = "robotRotationGroupBox";
            this.robotRotationGroupBox.Size = new System.Drawing.Size(120, 89);
            this.robotRotationGroupBox.TabIndex = 1;
            this.robotRotationGroupBox.TabStop = false;
            this.robotRotationGroupBox.Text = "Rotation";
            // 
            // resetRotationButton
            // 
            this.resetRotationButton.Location = new System.Drawing.Point(7, 47);
            this.resetRotationButton.Name = "resetRotationButton";
            this.resetRotationButton.Size = new System.Drawing.Size(107, 23);
            this.resetRotationButton.TabIndex = 1;
            this.resetRotationButton.Text = "Reset";
            this.resetRotationButton.UseVisualStyleBackColor = true;
            this.resetRotationButton.Click += new System.EventHandler(this.ResetRotationButton_Click);
            // 
            // rotationNumericUpDown
            // 
            this.rotationNumericUpDown.Location = new System.Drawing.Point(7, 20);
            this.rotationNumericUpDown.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.rotationNumericUpDown.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.rotationNumericUpDown.Name = "rotationNumericUpDown";
            this.rotationNumericUpDown.Size = new System.Drawing.Size(107, 20);
            this.rotationNumericUpDown.TabIndex = 0;
            // 
            // speedGroupBox
            // 
            this.speedGroupBox.AutoSize = true;
            this.speedGroupBox.Controls.Add(this.resetSpeedButton);
            this.speedGroupBox.Controls.Add(this.speedNumericUpDown);
            this.speedGroupBox.Location = new System.Drawing.Point(7, 20);
            this.speedGroupBox.Name = "speedGroupBox";
            this.speedGroupBox.Size = new System.Drawing.Size(120, 89);
            this.speedGroupBox.TabIndex = 0;
            this.speedGroupBox.TabStop = false;
            this.speedGroupBox.Text = "Speed";
            // 
            // resetSpeedButton
            // 
            this.resetSpeedButton.Location = new System.Drawing.Point(7, 47);
            this.resetSpeedButton.Name = "resetSpeedButton";
            this.resetSpeedButton.Size = new System.Drawing.Size(107, 23);
            this.resetSpeedButton.TabIndex = 2;
            this.resetSpeedButton.Text = "Reset";
            this.resetSpeedButton.UseVisualStyleBackColor = true;
            this.resetSpeedButton.Click += new System.EventHandler(this.ResetSpeedButton_Click);
            // 
            // speedNumericUpDown
            // 
            this.speedNumericUpDown.DecimalPlaces = 1;
            this.speedNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.speedNumericUpDown.Location = new System.Drawing.Point(7, 20);
            this.speedNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speedNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.speedNumericUpDown.Name = "speedNumericUpDown";
            this.speedNumericUpDown.Size = new System.Drawing.Size(107, 20);
            this.speedNumericUpDown.TabIndex = 0;
            // 
            // robotFileGroupBox
            // 
            this.robotFileGroupBox.AutoSize = true;
            this.robotFileGroupBox.Controls.Add(this.robotFilePointCloudCheckBox);
            this.robotFileGroupBox.Controls.Add(this.robotFileTrajectoryCheckBox);
            this.robotFileGroupBox.Location = new System.Drawing.Point(694, 472);
            this.robotFileGroupBox.Name = "robotFileGroupBox";
            this.robotFileGroupBox.Size = new System.Drawing.Size(133, 78);
            this.robotFileGroupBox.TabIndex = 2;
            this.robotFileGroupBox.TabStop = false;
            this.robotFileGroupBox.Text = "Robot File";
            this.robotFileGroupBox.Visible = false;
            // 
            // robotFilePointCloudCheckBox
            // 
            this.robotFilePointCloudCheckBox.AutoSize = true;
            this.robotFilePointCloudCheckBox.Checked = true;
            this.robotFilePointCloudCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.robotFilePointCloudCheckBox.Location = new System.Drawing.Point(7, 42);
            this.robotFilePointCloudCheckBox.Name = "robotFilePointCloudCheckBox";
            this.robotFilePointCloudCheckBox.Size = new System.Drawing.Size(80, 17);
            this.robotFilePointCloudCheckBox.TabIndex = 1;
            this.robotFilePointCloudCheckBox.Text = "Point Cloud";
            this.robotFilePointCloudCheckBox.UseVisualStyleBackColor = true;
            // 
            // robotFileTrajectoryCheckBox
            // 
            this.robotFileTrajectoryCheckBox.AutoSize = true;
            this.robotFileTrajectoryCheckBox.Checked = true;
            this.robotFileTrajectoryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.robotFileTrajectoryCheckBox.Location = new System.Drawing.Point(7, 19);
            this.robotFileTrajectoryCheckBox.Name = "robotFileTrajectoryCheckBox";
            this.robotFileTrajectoryCheckBox.Size = new System.Drawing.Size(73, 17);
            this.robotFileTrajectoryCheckBox.TabIndex = 0;
            this.robotFileTrajectoryCheckBox.Text = "Trajectory";
            this.robotFileTrajectoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(842, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Robot files (*.robot)|*.robot";
            this.saveFileDialog.InitialDirectory = "@\"..\\..\\..\\resource\"";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Save robot file";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Robot files (*.robot)|*.robot";
            this.openFileDialog.InitialDirectory = "@\"../../../resource\"";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 597);
            this.Controls.Add(this.robotFileGroupBox);
            this.Controls.Add(this.robotGroupBox);
            this.Controls.Add(this.renderTarget);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot Simulator";
            this.Load += new System.EventHandler(this.Window_Load);
            this.robotGroupBox.ResumeLayout(false);
            this.robotGroupBox.PerformLayout();
            this.robotDisplayGroupBox.ResumeLayout(false);
            this.robotDisplayGroupBox.PerformLayout();
            this.robotRotationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rotationNumericUpDown)).EndInit();
            this.speedGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedNumericUpDown)).EndInit();
            this.robotFileGroupBox.ResumeLayout(false);
            this.robotFileGroupBox.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label renderTarget;
        private System.Windows.Forms.GroupBox robotGroupBox;
        private System.Windows.Forms.GroupBox speedGroupBox;
        private System.Windows.Forms.NumericUpDown speedNumericUpDown;
        private System.Windows.Forms.Button resetSpeedButton;
        private System.Windows.Forms.GroupBox robotRotationGroupBox;
        private System.Windows.Forms.NumericUpDown rotationNumericUpDown;
        private System.Windows.Forms.Button resetRotationButton;
        private System.Windows.Forms.GroupBox robotDisplayGroupBox;
        private System.Windows.Forms.CheckBox robotPointCloudCheckBox;
        private System.Windows.Forms.CheckBox robotTrajectoryCheckBox;
        private System.Windows.Forms.CheckBox sensorsCheckBox;
        private System.Windows.Forms.Button robotResumeButton;
        private System.Windows.Forms.Button robotStartButton;
        private System.Windows.Forms.CheckBox wheelsCheckBox;
        private System.Windows.Forms.GroupBox robotFileGroupBox;
        private System.Windows.Forms.CheckBox robotFilePointCloudCheckBox;
        private System.Windows.Forms.CheckBox robotFileTrajectoryCheckBox;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button robotPauseButton;
    }
}

