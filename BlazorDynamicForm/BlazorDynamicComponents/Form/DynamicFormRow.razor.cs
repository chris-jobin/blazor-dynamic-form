using BlazorDynamicComponents.Attributes.Panel;
using BlazorDynamicComponents.Modals;
using BlazorDynamicComponents.Validation;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Form
{
    public partial class DynamicFormRow<TModel>
    {
        [Parameter]
        public TModel Model { get; set; }

        [Parameter]
        public PropertyInfo Property { get; set; }

        [Parameter]
        public DynamicValidationContext Context { get; set; }

        private int GetLabelWidth()
        {
            var panelAttribute = Property.GetCustomAttribute<DynamicPanelAttribute>();
            var formAttribute = Property.GetCustomAttribute<DynamicFormAttribute>();
            return panelAttribute?.Width ?? formAttribute?.Width ?? 0;
        }

        private string GetLabel()
        {
            var panelAttribute = Property.GetCustomAttribute<DynamicPanelAttribute>();
            var formAttribute = Property.GetCustomAttribute<DynamicFormAttribute>();
            return panelAttribute?.Name ?? formAttribute?.Name ?? Property.Name;
        }
    }
}
