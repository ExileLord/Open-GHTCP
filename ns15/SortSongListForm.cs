using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ns15
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
