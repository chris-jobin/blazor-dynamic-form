using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Panel
{
    public partial class DynamicPanelControl<TModel>
    {
        [Parameter]
        public TModel Model { get; set; }
        [Parameter]
        public PropertyInfo Property { get; set; }

        private string GetValue()
        {
            var value = Property.GetValue(Model, null);

            return value switch
            {
                var v when v is DateTime val => val.ToString("d MMMM yyyy"),
                _ => value?.ToString()
            };
        }
    }
}
