using BlazorDynamicComponents.Attributes.Panel;
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
    public partial class DynamicFormControl
    {
        [Parameter]
        public object Model { get; set; }

        [Parameter]
        public PropertyInfo Property { get; set; }

        [Parameter]
        public DynamicValidationContext Context { get; set; }

        private InputType InputType;
        private bool Readonly;

        protected override void OnInitialized()
        {
            var attribute = Property.GetCustomAttribute<DynamicFormAttribute>();

            InputType = attribute.InputType;
            Readonly = attribute.Readonly;
        }

        private object GetValue()
        {
            return Property.GetValue(Model, null);
        }

        private void SetValue(object value)
        {
            Property.SetValue(Model, value);
            _ = Context.ValidateProperty(Property);
        }
    }
}
