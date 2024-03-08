using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Display
{
    public partial class DynamicDisplayTemplate
    {
        [Parameter]
        public RenderFragment Columns { get; set; }

        [Parameter]
        public RenderFragment Rows { get; set; }
    }
}
