using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NotifyService : INotifyService
    {
        private List<Notify> errorList = new List<Notify>();

        public NotifyService() { }

        public void AddError(string error)
        {
            errorList.Add(new Notify(error));
        }

        public IEnumerable<Notify> AllErrors()
        {
            return errorList;
        }

        public bool HasError()
        {
            return errorList.Any();
        }
    }
}
