using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Notify
    {
        public string Error { get; private set; }

        public Notify(string error)
        {
            Error = error;
        }
    }
}
