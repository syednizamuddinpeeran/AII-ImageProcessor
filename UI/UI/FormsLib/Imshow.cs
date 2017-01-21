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
        Color mousePixelColor =Color.Black;
        
        /// <summary>
        /// check is image is movable
        /// </summary>
        public bool Ismovable { get; set; }
        
        /// <summary>
        /// check if the mouse button is down
        /// </summary>
        public bool IsmouseDown { get; set; }
      
        /// <summary>
        /// gives the last recorded location of the cursor
        /// </summary>
        Point lastKloc;

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
            initi();
            Image = image;
            pictureBox.Image = Image;
            resize();
        }
        
        #endregion

        #region EventHandlers

        #region FormEventHandlers
        
        /// <summary>
        /// Tick handler
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            //need work
            Point point =pixelLocationInImageUnderthePointer();
            mousePixelColor = GetColorAt(MousePosition.X, MousePosition.Y);
            toolStripPixelInfo.Text = "X:" + point.X + ",Y:" + point.Y + "Red:" + mousePixelColor.R.ToString() + ",Green" + mousePixelColor.G.ToString() + ",Blue:" + mousePixelColor.B.ToString();
            PixelColor.BackColor=mousePixelColor;
        }

        /// <summary>
        /// Adds event anddlers to suscriptions 
        /// </summary>
        private void addeventhandlers()
        {
            pictureBox.MouseMove += Imshow_MouseMove;
            pictureBox.MouseDown += Imshow_MouseDown;
            pictureBox.MouseUp += Imshow_MouseUp;
            Resize += Imshow_Resize;
        }

        private void Imshow_Resize(object sender, EventArgs e)
        {
            resize();
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
            Cursor = Cursors.SizeAll;
            Ismovable = true;
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

        #endregion

        #region PictureBoxeventhandlers
        private void Imshow_MouseUp(object sender, MouseEventArgs e)
        {
            Ismovable = false;
        }

        private void Imshow_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("mouse down");
            Ismovable = true;
            lastKloc = e.Location;
        }

        private void Imshow_MouseMove(object sender, MouseEventArgs e)
        {
            if (Ismovable)
            {
                lastKloc.X = lastKloc.X - e.X;
                lastKloc.Y = lastKloc.Y - e.Y;
                movepictureboxarround(lastKloc);
                lastKloc = e.Location;
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
            string fileName = "";
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
            addeventhandlers();
            setuppicturebox();
            addcontrols();
            addeventhandlers();
        }

        Point pixelLocationInImageUnderthePointer()
        {
            //need work
            int x = -this.Location.X + pictureBox.Location.X+MousePosition.X;
            int y = -this.Location.Y + pictureBox.Location.Y+MousePosition.Y;
            return new Point(x, y);
        }
         
        /// <summary>
        /// resize picture box
        /// </summary>
        void resize()
        {
            setuppicturebox();
            int width=Image.Width;   
            int height = Image.Height;
            int windowWidth = Width-5;
            int windowheight= Height-55;
            double aspectRatio = width / height;
            double widthRatio =(double) width / (double)windowWidth;
            double heightRatio = (double )height / (double)windowheight;
            if (aspectRatio>1)
            {
                if (widthRatio > 1)
                {
                    pictureBox.Width = (int)((double)width / (widthRatio));
                }
                else
                {
                    pictureBox.Width = (int)((double)width * (1+widthRatio));
                }
                pictureBox.Height = (int)((double)pictureBox.Width / aspectRatio);
            }
            else
            {
                if (heightRatio > 1)
                {
                    pictureBox.Height = (int)((double)height / (heightRatio));
                } 
                else
                {
                    pictureBox.Height = (int)((double)height * (1+heightRatio));
                }
                pictureBox.Width = (int)((double)pictureBox.Height * aspectRatio);
            }
        } 

        /// <summary>
        /// move picture box
        /// </summary>
        /// <param name="offset">defines the offset to move the picturebox</param>
        void movepictureboxarround(Point offset)
        {
            offset = new Point(pictureBox.Location.X - offset.X, pictureBox.Location.Y - offset.Y );
            pictureBox.Location = offset;
        }

        void zoomIn()
        {
            pictureBox.Width = (int)((double)pictureBox.Width * (double)1.1);
            pictureBox.Height = (int)((double)pictureBox.Height * (double)1.1);
        }

        void zoomOut()
        {
            pictureBox.Width = (int)((double)pictureBox.Width * (double)0.9);
            pictureBox.Height = (int)((double)pictureBox.Height * (double)0.9);
        }
        #endregion

    }

}
