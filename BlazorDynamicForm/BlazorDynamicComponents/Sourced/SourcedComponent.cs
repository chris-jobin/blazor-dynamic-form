using BlazorDynamicComponents.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDynamicComponents.Sourced
{
    public class SourcedComponent<TModel> : ComponentBase, ISourcedComponent<TModel>
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public string GetLocation { get; set; }

        [Parameter]
        public string SetLocation { get; set; }

        [Parameter]
        public EventCallback BeforeGet { get; set; }

        [Parameter]
        public EventCallback AfterGet { get; set; }

        [Parameter]
        public EventCallback BeforeSet { get; set; }

        [Parameter]
        public EventCallback AfterSet { get; set; }

        public TModel Model { get; set; }
        public bool IsOperating { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Get();
        }

        public void Engage()
        {
            IsOperating = true;
            StateHasChanged();
        }
        public void DisEngage()
        {
            IsOperating = false;
            StateHasChanged();
        }

        public async Task Get()
        {
            if (BeforeGet.HasDelegate)
            {
                await BeforeGet.InvokeAsync();
            }

            Engage();

            try
            {
                Model = await Http.GetFromJsonAsync<TModel>(GetLocation);
            }
            catch
            {
            }

            DisEngage();

            if (AfterGet.HasDelegate)
            {
                await AfterGet.InvokeAsync();
            }
        }

        public async Task<bool> Set()
        {
            var result = new ResultModel();

            if (BeforeSet.HasDelegate)
            {
                await BeforeSet.InvokeAsync();
            }

            Engage();

            try
            {
                var request = await Http.PostAsJsonAsync(SetLocation, Model);
                result = await request.Content.ReadFromJsonAsync<ResultModel>();
            }
            catch
            {
                result = new ResultModel { IsError = true };
            }

            DisEngage();

            if (AfterSet.HasDelegate)
            {
                await AfterSet.InvokeAsync();
            }

            return !result.IsError;
        }
    }
}
