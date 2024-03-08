using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Attributes.Validation
{
    public abstract class DynamicValidationAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        public abstract bool Validate(object value);
    }
}
