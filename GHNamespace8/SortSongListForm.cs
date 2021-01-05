using System;
using System.Windows.Forms;

namespace GHNamespace8
{
    public partial class SortSongListForm : Form
    {
        public enum SortBy
        {
            Setlist,
            Artist
        };
        public SortBy sortBy;

        public SortSongListForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sortBy = SortBy.Setlist;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sortBy = SortBy.Artist;
            this.Close();
        }
    }
}
