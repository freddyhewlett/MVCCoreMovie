using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Error
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public int StatusCode { get; set; }
    }
}
