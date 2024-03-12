using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Attributes.Panel
{
    public class DynamicFormAttribute : DynamicDisplayAttribute
    {
        public InputType InputType { get; set; }
        public bool Readonly { get; set; }

        public DynamicFormAttribute(string name, InputType inputType)
        {
            Name = name;
            InputType = inputType;
        }

        public DynamicFormAttribute(InputType inputType)
        {
            InputType = inputType;
        }
    }

    public enum InputType
    {
        None,
        Date,
        DateTime,
        Text,
        TextArea,
        Number,
        Select
    }
}
