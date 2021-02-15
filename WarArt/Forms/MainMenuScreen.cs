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
        Controller controller = new Controller();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete all data?",
                                     "Reset",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                controller.resetData();
            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}
