﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Display
{
    public partial class DynamicDisplayTemplateColumn
    {
        [CascadingParameter(Name = nameof(DynamicDisplayTemplate))]
        public DynamicDisplayTemplate DisplayTemplate { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }
    }
}
