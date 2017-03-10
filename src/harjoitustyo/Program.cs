// To compile using mono C# compiler (mcs) run command
// mcs -pkg:gtk-sharp-3.0 -reference:System.Xml *.cs UserInterfaceGtk/*.cs -out:KeyRegisterApp.exe
// at directory containing Program.cs (this file). Command generates executable named
// KeyRegisterApp.exe to that same directory. Comiling requires gtk-sharp-3.0.

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