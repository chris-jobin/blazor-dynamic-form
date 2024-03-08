using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents
{
    public partial class DynamicDisplayTemplateRow
    {
        [Parameter]
        public RenderFragment Label { get; set; }
        [Parameter]
        public RenderFragment Control { get; set; }
        [Parameter]
        public int LabelWidth { get; set; } = 4;
    }
}
