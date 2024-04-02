using BlazorDynamicComponents.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Validation
{
    public class DynamicValidationItem
    {
        public object Model { get; set; }
        public PropertyInfo Property { get; set; }
        public List<Attribute> Attribtues { get; set; }
        public List<string> ErrorMessages { get; set; } = [];
        public bool Validated { get; set; }

        public bool Validate()
        {
            ErrorMessages = [];

            var attributes = Property
                .GetCustomAttributes()
                .Where(x => x is DynamicValidationAttribute)
                .ToList();

            var isValid = true;

            foreach (var attribute in attributes)
            {
                var attr = attribute as DynamicValidationAttribute;
                var value = Property.GetValue(Model, null);
                var isValidAttribute = attr.Validate(value);

                if (!isValidAttribute)
                {
                    ErrorMessages.Add(attr.ErrorMessage);
                }

                isValid = isValidAttribute && isValid;
            }

            Validated = true;

            return isValid;
        }
    }
}
