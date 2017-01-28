namespace FormsLib
{
    partial class Imshow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Imshow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movepanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.PixelColor = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripPixelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOpenImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripArrow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripFittoScreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1001, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movepanToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.fitToScreenToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // movepanToolStripMenuItem
            // 
            this.movepanToolStripMenuItem.Name = "movepanToolStripMenuItem";
            this.movepanToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.movepanToolStripMenuItem.Text = "Move/pan";
            this.movepanToolStripMenuItem.Click += new System.EventHandler(this.movepanToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inToolStripMenuItem,
            this.outToolStripMenuItem});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // inToolStripMenuItem
            // 
            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
            this.inToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.inToolStripMenuItem.Text = "In";
            this.inToolStripMenuItem.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
            // 
            // outToolStripMenuItem
            // 
            this.outToolStripMenuItem.Name = "outToolStripMenuItem";
            this.outToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.outToolStripMenuItem.Text = "Out";
            this.outToolStripMenuItem.Click += new System.EventHandler(this.outToolStripMenuItem_Click);
            // 
            // fitToScreenToolStripMenuItem
            // 
            this.fitToScreenToolStripMenuItem.Name = "fitToScreenToolStripMenuItem";
            this.fitToScreenToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.fitToScreenToolStripMenuItem.Text = "Fit to screen";
            this.fitToScreenToolStripMenuItem.Click += new System.EventHandler(this.fitToScreenToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenImage,
            this.toolStripSaveAs,
            this.toolStripSeparator1,
            this.toolStripArrow,
            this.toolStripButtonMove,
            this.toolStripSeparator2,
            this.toolStripFittoScreen,
            this.toolStripZoomIn,
            this.toolStripZoomOut,
            this.toolStripSeparator3,
            this.toolStripButton6,
            this.toolStripSeparator4,
            this.toolStripButtonAbout});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1001, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PixelColor,
            this.toolStripPixelInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 459);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1001, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // PixelColor
            // 
            this.PixelColor.Name = "PixelColor";
            this.PixelColor.Size = new System.Drawing.Size(19, 17);
            this.PixelColor.Text = "    ";
            // 
            // toolStripPixelInfo
            // 
            this.toolStripPixelInfo.Enabled = false;
            this.toolStripPixelInfo.Name = "toolStripPixelInfo";
            this.toolStripPixelInfo.Size = new System.Drawing.Size(38, 17);
            this.toolStripPixelInfo.Text = "R:G:B:";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripOpenImage
            // 
            this.toolStripOpenImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOpenImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpenImage.Image")));
            this.toolStripOpenImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpenImage.Name = "toolStripOpenImage";
            this.toolStripOpenImage.Size = new System.Drawing.Size(23, 22);
            this.toolStripOpenImage.Text = "OpenImage";
            this.toolStripOpenImage.Click += new System.EventHandler(this.toolStripOpenImage_Click);
            // 
            // toolStripSaveAs
            // 
            this.toolStripSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSaveAs.Image")));
            this.toolStripSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSaveAs.Name = "toolStripSaveAs";
            this.toolStripSaveAs.Size = new System.Drawing.Size(23, 22);
            this.toolStripSaveAs.Text = "SaveAs";
            this.toolStripSaveAs.Click += new System.EventHandler(this.toolStripSaveAs_Click);
            // 
            // toolStripArrow
            // 
            this.toolStripArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripArrow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripArrow.Image")));
            this.toolStripArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripArrow.Name = "toolStripArrow";
            this.toolStripArrow.Size = new System.Drawing.Size(23, 22);
            this.toolStripArrow.Text = "Arrow";
            this.toolStripArrow.Click += new System.EventHandler(this.toolStripArrow_Click);
            // 
            // toolStripButtonMove
            // 
            this.toolStripButtonMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMove.Image")));
            this.toolStripButtonMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMove.Name = "toolStripButtonMove";
            this.toolStripButtonMove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMove.Text = "Move";
            this.toolStripButtonMove.Click += new System.EventHandler(this.toolStripButtonMove_Click);
            // 
            // toolStripFittoScreen
            // 
            this.toolStripFittoScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFittoScreen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFittoScreen.Image")));
            this.toolStripFittoScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFittoScreen.Name = "toolStripFittoScreen";
            this.toolStripFittoScreen.Size = new System.Drawing.Size(23, 22);
            this.toolStripFittoScreen.Text = "FittoScreen";
            this.toolStripFittoScreen.Click += new System.EventHandler(this.toolStripFittoScreen_Click);
            // 
            // toolStripZoomIn
            // 
            this.toolStripZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripZoomIn.Image")));
            this.toolStripZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripZoomIn.Name = "toolStripZoomIn";
            this.toolStripZoomIn.Size = new System.Drawing.Size(23, 22);
            this.toolStripZoomIn.Text = "ZoomIn";
            this.toolStripZoomIn.Click += new System.EventHandler(this.toolStripZoomIn_Click);
            // 
            // toolStripZoomOut
            // 
            this.toolStripZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripZoomOut.Image")));
            this.toolStripZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripZoomOut.Name = "toolStripZoomOut";
            this.toolStripZoomOut.Size = new System.Drawing.Size(23, 22);
            this.toolStripZoomOut.Text = "ZoomOut";
            this.toolStripZoomOut.Click += new System.EventHandler(this.toolStripZoomOut_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAbout.Text = "About";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // Imshow
            // 
            this.AccessibleDescription = "Imshow Preview";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1001, 481);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Imshow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Imshow";
            this.TopMost = true;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripPixelInfo;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel PixelColor;
        private System.Windows.Forms.ToolStripButton toolStripButtonMove;
        private System.Windows.Forms.ToolStripMenuItem movepanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripOpenImage;
        private System.Windows.Forms.ToolStripButton toolStripSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripArrow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripFittoScreen;
        private System.Windows.Forms.ToolStripButton toolStripZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem fitToScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
    }
}

