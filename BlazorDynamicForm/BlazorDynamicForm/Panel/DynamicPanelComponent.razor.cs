using BlazorDynamicForm.Attributes.Panel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicForm.Panel
{
    public partial class DynamicPanelComponent<TModel>
    {
        [Parameter]
        public TModel Model { get; set; }

        private Dictionary<int, List<PropertyInfo>> Columns;

        protected override void OnInitialized()
        {
            Columns = GetColumns();
        }

        private Dictionary<int, List<PropertyInfo>> GetColumns()
        {
            return Model
                .GetType()
                .GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(DynamicPanelAttribute)))
                .OrderBy(x => x.GetCustomAttribute<DynamicPanelAttribute>().Index)
                .GroupBy(x => x.GetCustomAttribute<DynamicPanelAttribute>().ColumnIndex)
                .ToDictionary(x => x.Key, y => y.ToList());
        }

        private int GetTitleWidth(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<DynamicPanelAttribute>();
            return attribute?.Width ?? 0;
        }

        private string GetLabel(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<DynamicPanelAttribute>();
            return attribute?.Name ?? property.Name;
        }
    }
}
