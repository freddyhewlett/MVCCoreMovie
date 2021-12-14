using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string Operation { get; set; }


        protected LogViewModel()
        {
        }

        public LogViewModel(string user, string op)
        {
            User = user;
            Operation = op;
            Date = DateTime.Now;
        }

        public LogViewModel(string user, string op, DateTime dt) : this(user, op)
        {
            Date = dt;
        }
    }
}
