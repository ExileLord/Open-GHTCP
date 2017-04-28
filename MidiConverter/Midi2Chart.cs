using System;
using System.Windows.Forms;
using mid2chart;
using ns15;
using ns9;

namespace MidiConverter
{
    class Midi2Chart
    {

        public static QBCParser LoadMidiSong(string fileName, bool forceRB3)
        {
            QBCParser qbc = null;
            Song song = null;
            try {
                song = MidReader.ReadMidi(fileName);
                var chartFile = ChartWriter.writeChart(song, "", false, forceRB3).ToString();
                var chartParser = new ChartParser(chartFile, false);
                qbc = chartParser.ConvertToQBC();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error using the new MIDI importer.\nReverting to original GHTCP method. \n\n" + e, "MIDI Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qbc = new MIDIParser(fileName).LoadMidi().ConvertToQBC();
            }
            return qbc;
        }

    }
}
