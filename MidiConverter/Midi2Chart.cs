using mid2chart;
using ns15;
using ns9;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MidiConverter
{
    class Midi2Chart
    {

        public static QBCParser getMidiSong(string fileName, bool forceRB3)
        {
            QBCParser qbc = null;
            Song song = null;
            try {
                song = MidReader.ReadMidi(fileName);
                String chartFile = ChartWriter.writeChart(song, "", false, forceRB3).ToString();
                ChartParser chartParser = new ChartParser(chartFile, "midi");
                qbc = chartParser.method_3();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error using the new MIDI import method.\nReverting to original GHTCP method. \n\n" + e.ToString(), "MIDI Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qbc = new MIDIParser(fileName).method_0().method_3();
            }
            return qbc;
        }

    }
}
