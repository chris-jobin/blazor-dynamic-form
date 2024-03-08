using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Panel
{
    public partial class DynamicPanelSourcedComponent<TModel>
    {
        [Parameter]
        public string Header { get; set; }
    }
}
