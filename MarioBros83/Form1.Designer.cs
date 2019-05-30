namespace MarioBros83
{
	partial class MarioBros
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
			this.components = new System.ComponentModel.Container();
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.labelDebug = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// gameTimer
			// 
			this.gameTimer.Enabled = true;
			this.gameTimer.Interval = 10;
			this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
			// 
			// labelDebug
			// 
			this.labelDebug.AutoSize = true;
			this.labelDebug.Location = new System.Drawing.Point(2, 78);
			this.labelDebug.Name = "labelDebug";
			this.labelDebug.Size = new System.Drawing.Size(45, 13);
			this.labelDebug.TabIndex = 0;
			this.labelDebug.Text = "DEBUG";
			// 
			// MarioBros
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(256, 224);
			this.Controls.Add(this.labelDebug);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MarioBros";
			this.Text = "Mario Bros \'83";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MarioBros_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MarioBros_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MarioBros_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer gameTimer;
		private System.Windows.Forms.Label labelDebug;
	}
}

