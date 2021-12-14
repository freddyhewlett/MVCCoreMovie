using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INotifyService
    {
        void AddError(string error);

        bool HasError();

        IEnumerable<Notify> AllErros();
    }
}
