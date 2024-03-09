using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Modals
{
    public partial class Modal
    {
        [Inject]
        public IJSRuntime Js { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Header { get; set; }

        private bool IsOpen;
        private ElementReference DialogRef;

        public async Task Open()
        {
            await Js.InvokeVoidAsync("openModal", DialogRef);
            IsOpen = true;
        }

        public async Task Close()
        {
            await Js.InvokeVoidAsync("closeModal", DialogRef);
            IsOpen = false;
        }
    }
}
