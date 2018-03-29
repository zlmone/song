using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Controls;

namespace WSH.Tools.Internet
{
    public partial class InternetMain : BaseMdiForm
    {
        public InternetMain()
        {
            InitializeComponent();

        }

        private void menuFateUser_Click(object sender, EventArgs e)
        {
            InternetFate.FateMain fate = new InternetFate.FateMain();
            ShowChildForm(fate);
        }

        private void menuMovie365_Click(object sender, EventArgs e)
        {
            Movie.MovieMain movie = new Movie.MovieMain();
            ShowChildForm(movie);
        }
    }
}
