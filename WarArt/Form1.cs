using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarArt
{
    public partial class TelaPrincipal : Form
    {
        List<State> StateList = new List<State>();
        int currentState = 0;
        Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(10, 70);
            this.TopMost = true;
            this.BackColor = Color.FromName("SlateBlue");

            StateList.Add(new State("Paused", 0, Color.FromName("AliceBlue"), Color.FromName("Black"))); // White
            StateList.Add(new State("War", 1, Color.FromName("Crimson"), Color.FromName("White"))); // Red
            StateList.Add(new State("Art", 2, Color.FromName("Blue"), Color.FromName("White"))); // Blue
            StateList.Add(new State("Half", 3, Color.FromName("SlateBlue"), Color.FromName("White"))); // Purple
            loadState();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentState++;
            if(currentState >= StateList.Count)
            {
                currentState = 0;
            }
            loadState();
        }

        private void loadState()
        {
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            
            button1.Text = StateList[currentState].name + " - " + elapsedMs.ToString();
            button1.BackColor = StateList[currentState].backColor;
            button1.ForeColor = StateList[currentState].foreColor;

            watch = System.Diagnostics.Stopwatch.StartNew();
        }

    }

    public  class State
    {
        public string name;
        public int code;
        public Color backColor;
        public Color foreColor;

        public State(string name, int code, Color color, Color frontColor)
        {
            this.name = name;
            this.code = code;
            this.backColor = color;
            this.foreColor = frontColor;
        }
    }

}
