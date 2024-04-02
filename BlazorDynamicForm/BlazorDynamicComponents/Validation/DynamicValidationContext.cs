using BlazorDynamicComponents.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Validation
{
    public class DynamicValidationContext
    {
        public object Model { get; set; }
        public List<DynamicValidationItem> Items { get; set; }

        public DynamicValidationContext(object model)
        {
            Model = model;
            Items = GetItems(model);
        }

        private List<DynamicValidationItem> GetItems(object model)
        {
            var properties = model
                .GetType()
                .GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(DynamicValidationAttribute)))
                .ToList();

            return properties.Select(x => new DynamicValidationItem
            {
                Model = model,
                Property = x,
                Attribtues = x.GetCustomAttributes().ToList()
            }).ToList();
        }

        public bool Validate()
        {
            var isValid = true;

            foreach (var item in Items)
            {
                isValid = item.Validate() && isValid;
            }

            return isValid;
        }

        public bool ValidateProperty(PropertyInfo property)
        {
            var item = Items.SingleOrDefault(x => x.Property == property);
            if (item.Validated)
            {
                return item.Validate();
            }
            else
            {
                return false;
            }
        }
    }
}
