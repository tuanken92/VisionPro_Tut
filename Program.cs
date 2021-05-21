using Cognex.VisionPro;
using System;
using System.Windows.Forms;

namespace VisionPro_Tut
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            //Releasing framegrabbers
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            for (int i = 0; i < frameGrabbers.Count; i++)
            {
                frameGrabbers[i].Disconnect(false);
            }
        }


    }
}
