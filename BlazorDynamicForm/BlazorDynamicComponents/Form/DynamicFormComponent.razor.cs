using BlazorDynamicComponents.Attributes.Panel;
using BlazorDynamicComponents.Patterns;
using BlazorDynamicComponents.Validation;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Form
{
    public partial class DynamicFormComponent<TModel>
    {
        [Parameter]
        public TModel Model { get; set; }

        private DynamicValidationContext Context;
        private Dictionary<int, List<PropertyInfo>> Columns;

        protected override void OnInitialized()
        {
            Columns = GetColumns();
            Context = new DynamicValidationContext(Model);
        }

        private Dictionary<int, List<PropertyInfo>> GetColumns()
        {
            return Model
                .GetType()
                .GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(DynamicFormAttribute)))
                .OrderBy(x => x.GetCustomAttribute<DynamicFormAttribute>().Index)
                .GroupBy(x => x.GetCustomAttribute<DynamicFormAttribute>().ColumnIndex)
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

        public bool Validate()
        {
            var isValid = Context.Validate();
            StateHasChanged();
            return isValid;
        }
    }
}
