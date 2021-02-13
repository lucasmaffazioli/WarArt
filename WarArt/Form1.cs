using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;


namespace WarArt
{
    public partial class TelaPrincipal : Form
    {
        List<State> StateList = new List<State>();
        int currentState = 0;

        public TelaPrincipal()
        {
            StateList.Add(new State("Paused",   0, Color.FromName("AliceBlue"))); // White
            StateList.Add(new State("War",      1, Color.FromName("Crimson"))); // Red
            StateList.Add(new State("Art",      2, Color.FromName("Blue"))); // Blue
            StateList.Add(new State("Half",     3, Color.FromName("SlateBlue"))); // Purple


            InitializeComponent();
            this.TopMost = true;
            this.BackColor = Color.FromName("SlateBlue");
            loadState();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = "aaaaa";
            currentState++;
            if(currentState >= StateList.Count)
            {
                currentState = 0;
            }
            loadState();
        }

        private void loadState()
        {
            button1.Text = StateList[currentState].name;
            button1.BackColor = StateList[currentState].color;
        }


    }

    public  class State
    {

        public string name;
        public int code;
        public Color color;

        public State(string name, int code, Color color)
        {
            this.name = name;
            this.code = code;
            this.color = color;
        }
    }

}
