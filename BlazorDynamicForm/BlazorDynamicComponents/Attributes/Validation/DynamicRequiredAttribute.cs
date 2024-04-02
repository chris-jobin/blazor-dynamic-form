using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Attributes.Validation
{
    public class DynamicRequiredAttribute : DynamicValidationAttribute
    {
        public override bool Validate(object value)
        {
            if (value is null)
            {
                return false;
            }

            return value switch
            {
                var v when v is string val => !string.IsNullOrEmpty(val),
                _ => true
            };
        }
    }
}
