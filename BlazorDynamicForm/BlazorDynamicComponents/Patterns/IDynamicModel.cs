using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Patterns
{
    public interface IDynamicModel
    {
        string Id { get; set; }
        Dictionary<int, string> Columns { get; set; }
    }
}
