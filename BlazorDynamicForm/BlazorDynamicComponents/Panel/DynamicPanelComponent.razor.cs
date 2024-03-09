using BlazorDynamicComponents.Attributes.Panel;
using BlazorDynamicComponents.Patterns;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Panel
{
    public partial class DynamicPanelComponent<TModel>
    {
        [Parameter]
        public TModel Model { get; set; }

        [Parameter]
        public string Header { get; set; }

        private bool HasContent => !string.IsNullOrEmpty(GetModelId());

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

        private string GetColumnTitle(int columnIndex)
        {
            if (Model is not IDynamicModel dynamicModel || dynamicModel.Columns == null)
            {
                return string.Empty;
            }

            var columnTitle = dynamicModel.Columns.TryGetValue(columnIndex, out var result) ? result : string.Empty;

            return columnTitle;
        }

        private string GetModelId()
        {
            if (Model is not IDynamicModel dynamicModel)
            {
                return string.Empty;
            }

            return dynamicModel.Id;
        }
    }
}
