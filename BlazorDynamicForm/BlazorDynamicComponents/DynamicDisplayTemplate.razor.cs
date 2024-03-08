using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents
{
    public partial class DynamicDisplayTemplate
    {
        [Parameter]
        public RenderFragment Title { get; set; }
        [Parameter]
        public RenderFragment Control { get; set; }
        [Parameter]
        public int TitleWidth { get; set; } = 4;
    }
}
