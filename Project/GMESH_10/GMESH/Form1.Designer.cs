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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Build = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.Quality = new System.Windows.Forms.ToolStripTextBox();
            this.pentagonOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decomposeOnTrianglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decomposeOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decomposeWithStarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurveMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bezierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.CurveMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Open,
            this.Build,
            this.Clear,
            this.Quality,
            this.pentagonOptionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(43, 23);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(48, 23);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Build
            // 
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(46, 23);
            this.Build.Text = "Build";
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // Clear
            // 
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(46, 23);
            this.Clear.Text = "Clear";
            this.Clear.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Quality
            // 
            this.Quality.AutoSize = false;
            this.Quality.Name = "Quality";
            this.Quality.Size = new System.Drawing.Size(100, 23);
            // 
            // pentagonOptionsToolStripMenuItem
            // 
            this.pentagonOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decomposeOnTrianglesToolStripMenuItem,
            this.decomposeOnToolStripMenuItem,
            this.decomposeWithStarToolStripMenuItem});
            this.pentagonOptionsToolStripMenuItem.Name = "pentagonOptionsToolStripMenuItem";
            this.pentagonOptionsToolStripMenuItem.Size = new System.Drawing.Size(115, 23);
            this.pentagonOptionsToolStripMenuItem.Text = "Pentagon Options";
            // 
            // decomposeOnTrianglesToolStripMenuItem
            // 
            this.decomposeOnTrianglesToolStripMenuItem.Name = "decomposeOnTrianglesToolStripMenuItem";
            this.decomposeOnTrianglesToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.decomposeOnTrianglesToolStripMenuItem.Text = "Decompose on triangles";
            this.decomposeOnTrianglesToolStripMenuItem.Click += new System.EventHandler(this.decomposeOnTrianglesToolStripMenuItem_Click);
            // 
            // decomposeOnToolStripMenuItem
            // 
            this.decomposeOnToolStripMenuItem.Name = "decomposeOnToolStripMenuItem";
            this.decomposeOnToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.decomposeOnToolStripMenuItem.Text = "Decompose on triangles and tetragon";
            this.decomposeOnToolStripMenuItem.Click += new System.EventHandler(this.decomposeOnToolStripMenuItem_Click);
            // 
            // decomposeWithStarToolStripMenuItem
            // 
            this.decomposeWithStarToolStripMenuItem.Name = "decomposeWithStarToolStripMenuItem";
            this.decomposeWithStarToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.decomposeWithStarToolStripMenuItem.Text = "Decompose with star";
            this.decomposeWithStarToolStripMenuItem.Click += new System.EventHandler(this.decomposeWithStarToolStripMenuItem_Click);
            // 
            // CurveMenuStrip
            // 
            this.CurveMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.bezierToolStripMenuItem});
            this.CurveMenuStrip.Name = "CurveMenuStrip";
            this.CurveMenuStrip.Size = new System.Drawing.Size(106, 48);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.lineToolStripMenuItem.Text = "line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // bezierToolStripMenuItem
            // 
            this.bezierToolStripMenuItem.Name = "bezierToolStripMenuItem";
            this.bezierToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.bezierToolStripMenuItem.Text = "bezier";
            this.bezierToolStripMenuItem.Click += new System.EventHandler(this.bezierToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.CurveMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem Build;
        private System.Windows.Forms.ToolStripMenuItem Clear;
        private System.Windows.Forms.ToolStripTextBox Quality;
        private System.Windows.Forms.ContextMenuStrip CurveMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bezierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pentagonOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decomposeOnTrianglesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decomposeOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decomposeWithStarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

