using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarArt.Models;
using static System.Windows.Forms.ListView;

namespace WarArt
{
    class Controller
    {
        List<State> StateList = new List<State>();
        public List<string> getAllDays()
        {
            List<string> list = new List<string> { };
            DataTable dt = DalHelper.GetDailySummary();

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                list.Add(dt.Rows[x].Field<string>("date") + " - " + dt.Rows[x].Field<string>("state") + " - " + dt.Rows[x].Field<string>("totalTime").ToString());
            }

            return list;
        }
    }
}
