using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicForm.Attributes.Panel
{
    public class DynamicPanelAttribute : DynamicDisplayAttribute
    {
        public DynamicPanelAttribute(string name)
        {
            Name = name;
        }
    }
}
