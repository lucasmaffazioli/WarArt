using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarArt.Models
{
    public class Historico
    {
        public int? Id { get; set; }
        public string state { get; set; }
        public int seconds { get; set; }
        public DateTime start{ get; set; }
        public DateTime end { get; set; }

        public Historico(int Id, string state, int seconds, DateTime start, DateTime end)
        {
            this.Id = Id;
            this.state = state;
            this.seconds = seconds;
            this.start = start;
            this.end = end;
        }
    }
    public class State
    {
        public string name;
        public int code;
        public Color backColor;
        public Color foreColor;

        public State(string name, Color color, Color frontColor)
        {
            this.name = name;
            this.backColor = color;
            this.foreColor = frontColor;
        }
    }
}
