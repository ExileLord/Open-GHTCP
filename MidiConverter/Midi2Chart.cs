using mid2chart;
using ns15;
using ns9;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidiConverter
{
    class Midi2Chart
    {

        public static ChartParser getMidiSong(string fileName, bool forceRB3)
        {
            Song song = MidReader.ReadMidi(fileName);
            String chartFile = ChartWriter.writeChart(song, "", false, false, forceRB3).ToString();
            ChartParser chartParser = new ChartParser(chartFile, false);
            return chartParser;
        }

    }
}
