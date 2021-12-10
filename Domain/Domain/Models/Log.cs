using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string Operation { get; set; }


        protected Log()
        {
        }

        public Log(string user, string op)
        {
            User = user;
            Operation = op;
            Date = DateTime.Now;
        }

        public Log(string user, string op, DateTime dt) : this(user, op)
        {
            Date = dt;
        }
    }
}
