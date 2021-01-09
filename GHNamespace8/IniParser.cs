using GuitarHero.Songlist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GHNamespace8
{
    public static class IniParser
    {
        public static Gh3Song ParseIni(string file, Gh3Song gH3Song)
        {
            if (File.Exists(file + "\\song.ini"))
            {
                string[] iniContents = File.ReadAllLines(file + "\\song.ini");
                foreach (string line in iniContents)
                {
                    if (line.StartsWith("name"))
                    {
                        gH3Song.Title = line.Remove(0, line.IndexOf('=') + 1).Trim();
                    }
                    else if (line.StartsWith("artist"))
                    {
                        gH3Song.Artist = line.Remove(0, line.IndexOf('=') + 1).Trim();
                    }
                    else if (line.StartsWith("year"))
                    {
                        gH3Song.Year = line.Remove(0, line.IndexOf('=') + 1).Trim();
                        if(gH3Song.Year.Length > 4)
                        {
                            gH3Song.Year = "";
                        }
                    }
                }
            }
            return gH3Song;
        }
    }
}
