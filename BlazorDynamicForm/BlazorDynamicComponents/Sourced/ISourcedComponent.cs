using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Sourced
{
    public interface ISourcedComponent<TModel>
    {
        TModel Model { get; set; }
        bool IsOperating { get; set; }
        Task Get();
        Task<bool> Set();
    }
}
