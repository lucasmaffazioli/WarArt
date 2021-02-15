using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarArt.Forms
{
    public partial class ResultsScreen : Form
    {
        Controller controller = new Controller();
        public ResultsScreen()
        {
            InitializeComponent();

            List<string> listSummary = controller.getAllDays();
            foreach (var summary in listSummary)
            {
                listView.Items.Add(summary);
            }
        }

    }
}
