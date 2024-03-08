using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Sourced
{
    public partial class SourcedContent<TModel>
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public ISourcedComponent<TModel> Source { get; set; }
    }
}
