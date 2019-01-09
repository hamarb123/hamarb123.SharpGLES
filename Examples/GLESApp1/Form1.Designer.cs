namespace GLESApp1
{
	partial class Form1
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
			this.glesControl1 = new hamarb123.SharpGLES.GLESControl();
			this.SuspendLayout();
			// 
			// glesControl1
			// 
			this.glesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.glesControl1.Location = new System.Drawing.Point(0, 0);
			this.glesControl1.Name = "glesControl1";
			this.glesControl1.Size = new System.Drawing.Size(800, 450);
			this.glesControl1.TabIndex = 0;
			this.glesControl1.OnRender += new System.EventHandler(this.glesControl1_OnRender);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.glesControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.ResumeLayout(false);

		}

		#endregion

		private hamarb123.SharpGLES.GLESControl glesControl1;
	}
}

