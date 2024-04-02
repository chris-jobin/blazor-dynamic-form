using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Validation
{
    public partial class DynamicValidationMessage
    {
        [Parameter]
        public DynamicValidationContext Context { get; set; }

        [Parameter]
        public PropertyInfo Property { get; set; }

        private DynamicValidationItem Item;

        protected override void OnInitialized()
        {
            Item = Context.Items.SingleOrDefault(x => x.Property == Property);
        }
    }
}
