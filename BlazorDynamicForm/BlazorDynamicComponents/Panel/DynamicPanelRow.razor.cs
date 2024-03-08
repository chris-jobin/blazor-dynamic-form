using BlazorDynamicComponents.Attributes.Panel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Panel
{
    public partial class DynamicPanelRow<TModel>
    {
        [Parameter]
        public TModel Model { get; set; }

        [Parameter]
        public PropertyInfo Property { get; set; }

        private int GetLabelWidth()
        {
            var attribute = Property.GetCustomAttribute<DynamicPanelAttribute>();
            return attribute?.Width ?? 0;
        }

        private string GetLabel()
        {
            var attribute = Property.GetCustomAttribute<DynamicPanelAttribute>();
            return attribute?.Name ?? Property.Name;
        }
    }
}
