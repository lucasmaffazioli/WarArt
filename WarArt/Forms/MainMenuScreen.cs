using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarArt.Forms;

namespace WarArt
{
    public partial class MainMenuScreen : Form
    {
        MonitorScreen monitorScreen = new MonitorScreen();

        public MainMenuScreen()
        {

            InitializeComponent();
#if DEBUG
            this.Text = "DEBUG";
#endif
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monitorScreen.Show();
        }

        private void buttonResults_Click(object sender, EventArgs e)
        {
            ResultsScreen resultsScreen = new ResultsScreen();
            resultsScreen.Show();
        }
    }
}
