using FormsLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imageShow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="image">Image to be shown</param>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenFileDialog openDial = new OpenFileDialog();
            openDial.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            string fileName ="";
    again:  if(openDial.ShowDialog() == DialogResult.OK)
            {
                fileName = openDial.FileName;
            }
            else
                goto again;
            Application.Run(new Imshow(new Bitmap(fileName)));
        }
    }
}
