using System; 
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FormsLib
{
    /// <summary>
    /// Imshow Like interface to view images in dotnet
    /// </summary>  
    public partial class Imshow : Form
    {
     
        #region User32 dll imports
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);
        #endregion

        #region Property definitions

        public string fileName { get; set; }

        /// <summary>
        /// Image to be displayed in imshow
        /// </summary>
        public Bitmap Image { get; set; }
        
        /// <summary>
        /// picture box that displays the image
        /// </summary>
        PictureBox pictureBox =new PictureBox(); 
        
        /// <summary>
        /// get the color of the pixel under the mouse pointer
        /// </summary>
        Color mousePixelColor =new Color();
        
        /// <summary>
        /// check is image is movable
        /// </summary>
        public bool Ismovable { get; set; }

        /// <summary>
        /// gives the last recorded location of the cursor
        /// </summary>
        Point lastKloc=new Point();

        public bool IscontrolDown { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Creates new instance of the Imshow form
        /// </summary>
        public Imshow()
        {
            InitializeComponent();
            initi();
        }
        
        /// <summary>
        /// Shows the Bitmap in a imshow like form
        /// </summary>
        /// <param name="image">Input bitmap to be previewed</param>
        public Imshow(Bitmap image)
        {
            InitializeComponent();
            fileName = "Default";
            initi();
            Image = image;
            pictureBox.Image = Image;
            resize();
        }

        public Imshow(Bitmap image, string windowName)
        {
            InitializeComponent();
            fileName = windowName;
            initi();
            Image = image;
            pictureBox.Image = Image;
            resize();
        }
        #endregion

        #region EventHandlers
        
        /// <summary>
        /// Adds event anddlers to suscriptions 
        /// </summary>
        private void addeventhandlers()
        {
            pictureBox.MouseDown += Imshow_MouseDown;
            pictureBox.MouseUp += Imshow_MouseUp;
            Resize += Imshow_Resize;
            KeyDown += Imshow_KeyDown;
            KeyUp += Imshow_KeyUp;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
        }

        #region FormEventHandlers

        /// <summary>
        /// Tick handler
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            Point point =pixelLocationInImageUnderthePointer();
            mousePixelColor = GetColorAt(MousePosition.X, MousePosition.Y);
            toolStripPixelInfo.Text = (
                    ((point.X >=0 && point.Y >=0) && 
                    (point.X < Image.Width-1 && point.Y < Image.Height-1))? 
                        String.Format("X:" + point.X + ",Y:" + point.Y): 
                        ("Cursor out of picture")) 
                    + "Red:" + mousePixelColor.R.ToString() + 
                    ",Green" + mousePixelColor.G.ToString() + 
                    ",Blue:" + mousePixelColor.B.ToString();
            PixelColor.BackColor=mousePixelColor;
        }

        private void Imshow_Resize(object sender, EventArgs e)
        {
            resize();
            recenter();
        }

        private void Imshow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.P:
                    movepanToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.S:
                    if (IscontrolDown)
                    {
                        Save();
                    }
                    break;
                case Keys.O:
                    if (IscontrolDown)
                    {
                        open();
                    }
                    break;
                case Keys.F:
                    resize();
                    recenter();
                    break;
                case Keys.Up:
                    movepictureboxarround(new Point(0, 1));
                    break;
                case Keys.Down:
                    movepictureboxarround(new Point(0, -1));
                    break;
                case Keys.Right:
                    movepictureboxarround(new Point(-1, 0));
                    break;
                case Keys.Left:
                    movepictureboxarround(new Point(1, 0));
                    break;
                case Keys.Add:
                    zoomIn();
                    break;
                case Keys.Subtract:
                    zoomOut();
                    break;
                case Keys.ControlKey:
                    IscontrolDown = true;
                    break;
                default:
                    break;
            }
        }
        
        private void Imshow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    IscontrolDown = false;
                    break;
                default:
                    break;
            }
        }
        
        #endregion

        #region MenuStripClickHandlers

        /// <summary>
        /// Occurs when Open button is clicked on the menu tool strip
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }
        
        /// <summary>
        /// Occurs when Open button is clicked on the menu tool strip
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        /// <summary>
        /// Enables picture box movement
        /// </summary>
        private void movepanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ismovable)
            {
                toolStripArrow_Click(sender, e);
            }
            else
            {
                toolStripButtonMove_Click(sender, e);
            }
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomIn();
        }

        private void outToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomOut();
        }

        private void fitToScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resize();
        }

        #endregion

        #region Tool strip eventhandlers

        /// <summary>
        /// Opens new image file
        /// </summary>
        private void toolStripOpenImage_Click(object sender, EventArgs e)
        {
            open();
        }

        /// <summary>
        /// save image to as file as 
        /// </summary>
        private void toolStripSaveAs_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// Switch to normal mode from zoom or move mode
        /// </summary>
        private void toolStripArrow_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
            Ismovable = false;
        }

        /// <summary>
        /// Enables picture box movement
        /// </summary>
        private void toolStripButtonMove_Click(object sender, EventArgs e)
        {
            Cursor=Cursors.SizeAll;
            Ismovable = true;
        }

        /// <summary>
        /// Fits the image to the window
        /// </summary>
        private void toolStripFittoScreen_Click(object sender, EventArgs e)
        {
            resize();
        }

        /// <summary>
        /// Zooms into the image
        /// </summary>
        private void toolStripZoomIn_Click(object sender, EventArgs e)
        {
            zoomIn();
        }

        /// <summary>
        /// Zooms out ofthe image
        /// </summary>
        private void toolStripZoomOut_Click(object sender, EventArgs e)
        {
            zoomOut();
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            new AboutBoxImshow().Show();
        }
        #endregion

        #region PictureBoxeventhandlers

        private void Imshow_MouseUp(object sender, MouseEventArgs e)
        {
            if (Ismovable)
            {
                lastKloc.X = lastKloc.X - e.X;
                lastKloc.Y = lastKloc.Y - e.Y;
                movepictureboxarround(lastKloc);
            }
        }

        private void Imshow_MouseDown(object sender, MouseEventArgs e)
        {
            if (Ismovable)
            {
                lastKloc = e.Location;
            }
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta>0)
            {
                for (int i = 0; i < e.Delta; i++)
                {
                    zoomIn();
                }
            }
            else
            {
                for (int i = 0; i > e.Delta; i--)
                {
                    zoomOut();
                }
            }
        }

        #endregion

        #endregion
        
        #region FunctionalMethods
        
        /// <summary>
        /// open a new image in the imshow form
        /// </summary>
        void open()
        {
            //need work here
            OpenFileDialog openDial = new OpenFileDialog();
            openDial.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openDial.ShowDialog() == DialogResult.OK)
            {
                fileName = openDial.FileName;
                Image= new Bitmap(fileName); 
                pictureBox.Image = Image;
            }
            resize();
        }
        
        /// <summary>
        /// Saves the existing image to the form
        /// </summary>
        void Save()
        {
            //need work here
            SaveFileDialog saveDial = new SaveFileDialog();
            string fileName = "";
            if (saveDial.ShowDialog() == DialogResult.OK)
            {
                fileName=saveDial.FileName;
                new Bitmap(pictureBox.Image).Save(fileName, ImageFormat.Png);
            }
        }
        
        /// <summary>
        /// Gets the colour of the pixel located at the give point on the screen
        /// </summary>
        /// <param name="x">zero indexed pixel location from right to left</param>
        /// <param name="y">zero indexed pixel location from top to bottom</param>
        /// <returns></returns>
        Color GetColorAt(int x, int y)
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }
        
        /// <summary>
        /// setup picture bpx control
        /// </summary>
        void setuppicturebox()
        {
            pictureBox.Dock = DockStyle.None;
            pictureBox.Name = "pictureBox";
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(10, 50);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Add malually created controls to form
        /// </summary>
        void addcontrols()
        {
            this.Controls.Add(pictureBox);
        }

        /// <summary>
        /// initialise manual components
        /// </summary>
        void initi()
        {
            this.Text = fileName + "-Imshow";
            addeventhandlers();
            setuppicturebox();
            addcontrols();
            addeventhandlers();
        }

        /// <summary>
        /// gets the spatial coordinate of the image pixel under the cursor 
        /// </summary>
        /// <returns></returns>
        Point pixelLocationInImageUnderthePointer()
        {
            int x = MousePosition.X-9-Location.X-pictureBox.Location.X;
            x = (int)(x * (double)((double) Image.Width/(double)pictureBox.Width));
            int y = MousePosition.Y -32- Location.Y-pictureBox.Location.Y;
            y = (int)(y * (double)((double)Image.Height / (double)pictureBox.Height));
            return new Point(x, y);
        }

        /// <summary>
        /// resize picture box
        /// </summary>
        void resize()
        {
            setuppicturebox();
            #region oldcode

            //int width = Image.Width;
            //int height = Image.Height;
            //int windowWidth = Width ;
            //int windowheight = Height ;
            //double aspectRatio = width / height;
            //double widthRatio = (double)width / (double)windowWidth;
            //double heightRatio = (double)height / (double)windowheight;
            //if (widthRatio > heightRatio)
            //{
            //    if (widthRatio > 1)
            //    {
            //        pictureBox.Width = (int)((double)width * (widthRatio-1));
            //    }
            //    else
            //    {
            //        pictureBox.Width = (int)((double)width * (widthRatio));
            //    }
            //    pictureBox.Height = (int)((double)pictureBox.Width / aspectRatio);
            //}
            //else
            //{
            //    if (heightRatio > 1)
            //    {
            //        pictureBox.Height = (int)((double)height * (heightRatio-1));
            //    }
            //    else
            //    {
            //        pictureBox.Height = (int)((double)height * (heightRatio));
            //    }
            //    pictureBox.Width = (int)((double)pictureBox.Height * aspectRatio);
            //}
            #endregion
            double aspectRatio = (double)Width / (double)Height;
            double aspectRatioImage = (double)Image.Width / (double)Image.Height;
            if (aspectRatio < aspectRatioImage)
            {
                pictureBox.Width = (int)((double)Image.Width * (double)((double)Width / (double)Image.Width))-125;
                pictureBox.Height = (int)((double)pictureBox.Width / aspectRatioImage);
            }
            else
            {
                pictureBox.Height = (int)((double)Image.Height * (double)((double)Height / (double)Image.Height))-125;
                pictureBox.Width = (int)((double)pictureBox.Height * aspectRatioImage);
            }
            recenter();
        }

        void recenter()
        {
            pictureBox.Location = new Point(
                ((Width - pictureBox.Width) / 2), 
                ((Height - pictureBox.Height) / 2));
        }
        /// <summary>
        /// move picture box
        /// </summary>
        /// <param name="offset">defines the offset to move the picturebox</param>
        void movepictureboxarround(Point offset)
        {
            pictureBox.Location  = new Point(pictureBox.Location.X - offset.X, pictureBox.Location.Y - offset.Y );
        }

        /// <summary>
        /// Increases the width and height of the picture box by 1.1
        /// </summary>
        void zoomIn()
        {
            pictureBox.Width = (int)((double)pictureBox.Width * (double)1.1);
            pictureBox.Height = (int)((double)pictureBox.Height * (double)1.1);
        }

        /// <summary>
        /// Reduces the width and height of the picture box by 0.9
        /// </summary>
        void zoomOut()
        {
            pictureBox.Width = (int)((double)pictureBox.Width * (double)0.9);
            pictureBox.Height = (int)((double)pictureBox.Height * (double)0.9);
        }
        #endregion

    }

}
