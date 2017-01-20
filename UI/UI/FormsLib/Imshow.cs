using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
        /// get the color of the pixel under the mouse pointer
        /// </summary>
        Color mousePixelColor =Color.Black;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new instance of the Imshow form
        /// </summary>
        public Imshow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Shows the Bitmap in a imshow like form
        /// </summary>
        /// <param name="image">Input bitmap to be previewed</param>
        public Imshow(Bitmap image)
        {
            InitializeComponent();
            pictureBox.Image = image;
        }
        #endregion

        #region EventHandlers

        #region FormEventHandlers
        /// <summary>
        /// Tick handler
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            //need work here for pixel location
            mousePixelColor = GetColorAt(MousePosition.X, MousePosition.Y);
            toolStripPixelInfo.Text = "X:" + MousePosition.X + ",Y:" + MousePosition.Y + "Red:" + mousePixelColor.R.ToString() + ",Green" + mousePixelColor.G.ToString() + ",Blue:" + mousePixelColor.B.ToString();
            toolStripPixelInfo.BackColor = mousePixelColor;
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
        #endregion

        #endregion

        #region FunctionalMethods
        /// <summary>
        /// open a new image in the imshow form
        /// </summary>
        private void open()
        {
            OpenFileDialog openDial = new OpenFileDialog();
            openDial.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            string fileName = "";
            if (openDial.ShowDialog() == DialogResult.OK)
            {
                fileName = openDial.FileName;
                pictureBox.Image = new Bitmap(fileName);
            }
        }
        /// <summary>
        /// Saves the existing image to the form
        /// </summary>
        private void Save()
        {
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
        private Color GetColorAt(int x, int y)
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }
        #endregion

    }

}
