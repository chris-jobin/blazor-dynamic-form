using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Form
{
    public partial class DynamicFormSourcedComponent<TModel>
    {
        private DynamicFormComponent<TModel> FormRef;

        public bool Validate()
        {
            return FormRef.Validate();
        }
    }
}
