/*
Tehtävänanto:
Tehdään ohjelma, joka lukee vaihtelevapituisesta ja -nimisestä tiedostosta
käyttäjien pistetietoja. Tiedosto annetaan ohjelmalle komentoriviparametri-
na. Tiedoston formaatti on seuraava:
 - Yhden käyttäjän tiedot yhdellä rivillä (erotin \n).
 - Käyttäjätietojen erottimena pystyviiva (|). Käyttäjän nimi ensimmäisess
   'solussa' ja pisteet seuraavissa.
 - Pisteitä voi olla eri käyttäjillä eri määrä.

Ohjelma käsittelee tiedot ja tulostaa ne ruudulle, sekä tiedostoon. Ohjelma myös
ilmoittaa käyttäjälle mahdollisista virheistä, mutta jatkaa niistä huolimatta
suorituksen loppuun.

Ohjelman täytyy:
 - Lukea tiedot tiedostosta ja käsitellä mahdolliset poikkeukset.
 - Ohittaa tyhjät rivit ilman toimenpiteitä.
 - Laskea käyttäjän pisteet yhteen. Muunnossta käytettävä int.Parse(string)-metodia.
 - Ohittaa epäkelvot pisteet ja jatkaa eteenpäin.
 - Kirjoittaa käyttäjien nimet ja pisteet tiedostoon out.txt suoritushakemistoon
   muodossa "nimi|pisteet\nnimi|pisteet\nnimi|pisteet" käyttäjät erotettuna
   rivinvaihdolla ja käyttäjän nimi erotettuna pisteistä pystyviivalla.

*/

using System;
using System.IO;

namespace H07T01
{
    class Program
    {
        public static void Main (String[] args)
        {
            string file = null;
            string[] arrayOfLines = null;
            
            // Parsing command line arguments. Using IndexOutOfRangeException to
            // identify if user hadn't provided filename as argument.
            try
            {
                file = args[0];
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine ("Not enough arguments");
                Console.WriteLine ("Usage: Program.exe fileTeRead.txt");
                Environment.Exit (0);
            }
            
            // Reading file. Throws FileNotFoundException if file could not be
            // found in which case we tell user the situation and exit.
            try
            {
                arrayOfLines = System.IO.File.ReadAllLines (file);
            }
            catch (System.IO.FileNotFoundException)
            {
                printError ("File '" + file + "' could not be found");
                Environment.Exit (0);
            }
            catch (System.UnauthorizedAccessException)
            {
                printError ("Received UnauthorizedAccessException when trying to read file '" + file + "'.");
                Environment.Exit (0);
            }
            
            // Trying to open output.txt
            System.IO.StreamWriter outFile = null;
            try
            {
                outFile = new System.IO.StreamWriter("out.txt");
            }
            catch (System.UnauthorizedAccessException)
            {
                printError ("Received UnauthorizedAccessException when trying to open output file.");
                Environment.Exit (0);
            }
            
            // Iterating through each line (user) and writing information to
            // screen and out.txt.
            string allInfo = "";
            for (int j = 0; j < arrayOfLines.Length - 1; j++)
            {
                // Further splitting at vertical bar.
                string[] details = arrayOfLines[j].Split ('|');
                
                // Detecting empty lines and printing warning message.
                if (details[0].Length <= 0)
                {
                    printWarning ("Empty line at [" + (j + 1) + "]. Ignoring...");
                    continue;
                }
                int points = 0;
                allInfo += details[0] + " has collected total of ";
                
                // Iterating through points and counting them if they are valid.
                for (int i = 1; i < details.Length; i++)
                {
                    try
                    {
                        points += int.Parse (details[i]);
                    }
                    catch (System.FormatException)
                    {
                        printWarning (details[0] +
                                      " had some incorrect point value(s)! " +
                                      "Incorrect values were ignored (not " +
                                      "counted).");
                    }
                }
                outFile.WriteLine (details[0] + "|" + points);
                allInfo += points + " points.\n";
            }
            outFile.Close ();
            Console.WriteLine ("\n" + allInfo);
        }
        
        // 
        private static void printError (string text)
        {
            Console.WriteLine ("[ERROR]: " + text);
        }
        
        private static void printWarning (string text)
        {
            Console.WriteLine ("[WARNING]: " + text);
        }
    }
}
