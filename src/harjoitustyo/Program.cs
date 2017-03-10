using System;

namespace KeyRegisterApp
{
    /// <summary>
    /// Main program of the KeyRegister application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main ()
        {
            Gtk.Application.Init ();
            //KeyRegisterWindow gui = 
            new MainApplicationWindow ();
            Gtk.Application.Run ();
        }
    }
}