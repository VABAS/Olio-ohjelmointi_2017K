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

            // Getting settings.
            SettingsHandler sh = new SettingsHandler ();
            // Setting KeyRegister object to represent some of the implemented data sources. New
            // sources can be easily added by first inheriting from KeyRegister-class and
            // implementing the required methods. Then adding it here, will make it available.
            KeyRegister kr;
            if (sh.Settings["RegisterType"].ToUpper() == "XML")
            {
                kr = new KeyRegisterXml(sh.Settings["RegisterXmlFileLocation"]);
            }
            else
            {
                throw new SettingsHandler.InvalidSettingValue ("Invalid register type '" +
                                                               sh.Settings["RegisterType"] +
                                                               "' specified");
            }

            // Starting Gtk-application.
            Gtk.Application.Init ();
            new MainApplicationWindow (kr, sh);
            Gtk.Application.Run ();
        }
    }
}