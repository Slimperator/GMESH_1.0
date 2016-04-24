namespace GMESH
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Change = new System.Windows.Forms.ToolStripMenuItem();
            this.CurveToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Astroid = new System.Windows.Forms.ToolStripMenuItem();
            this.Bezier = new System.Windows.Forms.ToolStripMenuItem();
            this.Cardioid = new System.Windows.Forms.ToolStripMenuItem();
            this.Line = new System.Windows.Forms.ToolStripMenuItem();
            this.Gauge = new System.Windows.Forms.ToolStripMenuItem();
            this.Build = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Open,
            this.Change,
            this.Build});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(289, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(43, 20);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(48, 20);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Change
            // 
            this.Change.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurveToolStripMenu,
            this.Gauge});
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(60, 20);
            this.Change.Text = "Change";
            // 
            // CurveToolStripMenu
            // 
            this.CurveToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Astroid,
            this.Bezier,
            this.Cardioid,
            this.Line});
            this.CurveToolStripMenu.Name = "CurveToolStripMenu";
            this.CurveToolStripMenu.Size = new System.Drawing.Size(108, 22);
            this.CurveToolStripMenu.Text = "Curve";
            // 
            // Astroid
            // 
            this.Astroid.Name = "Astroid";
            this.Astroid.Size = new System.Drawing.Size(119, 22);
            this.Astroid.Text = "Astroid";
            // 
            // Bezier
            // 
            this.Bezier.Name = "Bezier";
            this.Bezier.Size = new System.Drawing.Size(119, 22);
            this.Bezier.Text = "Bezier";
            // 
            // Cardioid
            // 
            this.Cardioid.Name = "Cardioid";
            this.Cardioid.Size = new System.Drawing.Size(119, 22);
            this.Cardioid.Text = "Cardioid";
            // 
            // Line
            // 
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(119, 22);
            this.Line.Text = "Line";
            // 
            // Gauge
            // 
            this.Gauge.Name = "Gauge";
            this.Gauge.Size = new System.Drawing.Size(108, 22);
            this.Gauge.Text = "Gauge";
            // 
            // Build
            // 
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(46, 20);
            this.Build.Text = "Build";
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem Change;
        private System.Windows.Forms.ToolStripMenuItem CurveToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem Astroid;
        private System.Windows.Forms.ToolStripMenuItem Bezier;
        private System.Windows.Forms.ToolStripMenuItem Cardioid;
        private System.Windows.Forms.ToolStripMenuItem Line;
        private System.Windows.Forms.ToolStripMenuItem Gauge;
        private System.Windows.Forms.ToolStripMenuItem Build;
    }
}

