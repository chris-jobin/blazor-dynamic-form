using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicForm.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class DynamicDisplayAttribute : Attribute
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public int ColumnIndex { get; set; }
        public int Width { get; set; } = 1;
    }
}
