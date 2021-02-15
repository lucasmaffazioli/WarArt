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
using WarArt.Models;

namespace WarArt
{
    public partial class MonitorScreen : Form
    {
        List<State> StateList = new List<State>();
        string lastOperation = "";
        int currentState = 0;
        int elapsedSeconds = 0;
        DateTime start = DateTime.Now;
        DateTime end;
        Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

        public MonitorScreen()
        {
            InitializeComponent();
#if DEBUG
            this.Text = "DEBUG";
#endif
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(10, 70);
            this.BackColor = Color.FromName("SlateBlue");

            StateList.Add(new State("Paused", Color.FromName("AliceBlue"), Color.FromName("Black"))); // White
            StateList.Add(new State("War", Color.FromName("Crimson"), Color.FromName("White"))); // Red
            StateList.Add(new State("Art", Color.FromName("Blue"), Color.FromName("White"))); // Blue
            StateList.Add(new State("Half", Color.FromName("SlateBlue"), Color.FromName("White"))); // Purple
            loadState();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            switch (me.Button)
            {
                case MouseButtons.Left:
                    Console.WriteLine("left");
                    changeState(true);
                    break;
                case MouseButtons.Right:
                    Console.WriteLine("right");
                    changeState(false);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            loadState();
        }

        private void changeState(bool save)
        {
            watch.Stop();
            elapsedSeconds = (int)watch.ElapsedMilliseconds / 1000;

            end = DateTime.Now;

            // Console.WriteLine(currentState.ToString() + "  a  " + StateList[currentState].name);
            if (save && currentState != 0 && elapsedSeconds > 3) // Só grava no banco se ficou mais de 3 segundos na atividade
            {
                lastOperation = "Saved to db!";
                DalHelper.Add(new Models.Historico(0, StateList[currentState].name, elapsedSeconds, start, end));
            }
            else
            {
                lastOperation = "Ignored";
            }
            ////////////////////////////////
            watch = System.Diagnostics.Stopwatch.StartNew();
            start = DateTime.Now;
            currentState++;
            if (currentState >= StateList.Count)
            {
                currentState = 0;
            }
        }

        private void loadState()
        {
            button1.Text = StateList[currentState].name + Environment.NewLine + Environment.NewLine + "Last streak:" + Environment.NewLine + lastOperation + " - " + elapsedSeconds.ToString() + "s";
            button1.BackColor = StateList[currentState].backColor;
            button1.ForeColor = StateList[currentState].foreColor;
        }
    }

}
