using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicForm.Attributes.Panel
{
    public class DynamicFormAttribute : DynamicDisplayAttribute
    {
        public InputType InputType { get; set; }

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
        Date,
        DateTime,
        Text,
        TextArea,
        Number,
        Select
    }
}
