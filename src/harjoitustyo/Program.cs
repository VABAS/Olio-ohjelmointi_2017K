// To compile using mono C# compiler (mcs) run command
// mcs -pkg:gtk-sharp-3.0 -reference:System.Xml *.cs UserInterfaceGtk/*.cs -out:KeyRegisterApp.exe
// at directory containing Program.cs (this file). Command generates executable named
// KeyRegisterApp.exe to that same directory. Comiling requires gtk-sharp-3.0.

using System;
using System.Collections.Generic;

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
        public static void Main (string[] args)
        {
            // Deciding wether to start gui or CLI. CLI is started if arguments are present.
            if (args.Length > 0) {
                CliApplication cli = new CliApplication ();
                string command = args [0];
                List<string> commandArgs = new List<string> (args);
                commandArgs.RemoveAt (0);
                cli.runCommand (command, commandArgs.ToArray ());
            }
            else
            {
                // Starting Gtk-application.
                Gtk.Application.Init ();
                new MainApplicationWindow ();
                Gtk.Application.Run ();
            }
        }
    }
}